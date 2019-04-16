#region System Refrences

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;


using DexterLib;

#endregion

namespace MapMenu.EntryForms
{
    /// <summary>
    /// Interaction logic for DataUpload.xaml
    /// </summary>
    public partial class DataUpload : Window
    {
        public static readonly DependencyProperty FilesProperty =
            DependencyProperty.Register("Files", typeof(ImageList), typeof(DataUpload), new UIPropertyMetadata(null));

        private readonly string SavePathURL;
        private readonly bool ZoneNotRegion;
        private int DisplayFormDataType;
        private bool isZone;
        private Guid SelectedSectionID;
        private Guid? SelectedZoneRegionID;
        private Guid? SelectedCategoryID;


        public DataUpload()
        {
            Files = new ImageList();
            InitializeComponent();
        }

        public DataUpload(string SavePath, bool IsZone, Guid? ZoneRegionID, Guid SectionID, DateTime CurDate)
            : this()
        {
            SavePathURL = SavePath;


            isZone = IsZone;
            SelectedSectionID = SectionID;
            SelectedZoneRegionID = ZoneRegionID;

            IQueryable<Category> SecCategories = from query in App.ActiveDatabase.DatabaseEntities.Category
                                                 where query.Sections.SectionID == SectionID 
                                                 select query;
            comboBox1.ItemsSource = SecCategories;
            comboBox1.DisplayMemberPath = "ArName";
            //comboBox1.SelectedValuePath = "CategoryID";
  
            Month.SelectedIndex = CurDate.Month - 1;
            Year.SelectedIndex = CurDate.Year - 2009;
        }
        public void DisableDateSelection()
        {
            Year.Visibility = System.Windows.Visibility.Hidden;
            Month.Visibility = System.Windows.Visibility.Hidden;
            label4.Visibility = System.Windows.Visibility.Hidden;
        }
        public ImageList Files
        {
            get { return (ImageList)GetValue(FilesProperty); }
            set { SetValue(FilesProperty, value); }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
        private void RemoveItem(object sender, RoutedEventArgs e)
        {
           
            Button bt = (Button)sender;
            ImageFile img = (ImageFile)bt.DataContext;
            
            if (!img.InDatabase)
                Files.Remove(img);
            else
            {
                //TODO Delete the File From the database.
                DeleteDatabaseRecord(img.ImageFileID.Value);
                Files.Remove(img);
            }
        }



        private void SaveContent(object sender, RoutedEventArgs e)
        {
            SaveBT.Visibility = Visibility.Hidden;
            ClearList.Visibility = Visibility.Hidden;
            CancelBT.Visibility = Visibility.Hidden;

            string DirectoryBase;
            string NewFileName;
            int idx, count;
            idx = 1;
            count = Files.Count;
            foreach (ImageFile imageFile in Files.Reverse())
            {
                App.DoEvents();
                if (!imageFile.InDatabase)
                {
                    switch (imageFile.Datatype)
                    {
                        case DataTypes.Image:
                        case DataTypes.ImageGalary:
                            DirectoryBase = Path.Combine(SavePathURL, SelectedSectionID + @"\" + imageFile.CatigotyID +
                                                                      @"\Images\" +
                                                                      imageFile.SelectionDate.Year + @"\" +
                                                                      imageFile.SelectionDate.Month + @"\");
                            if (CopyFileToDir(DirectoryBase, imageFile.FileName, out NewFileName))
                            {
                                imageFile.FileName = DirectoryBase + NewFileName;
                            }
                            break;
                        case DataTypes.Video:
                            DirectoryBase = Path.Combine(SavePathURL, SelectedSectionID + @"\" + imageFile.CatigotyID +
                                                                      @"\Videos\" +
                                                                      imageFile.SelectionDate.Year + @"\" +
                                                                      imageFile.SelectionDate.Month + @"\");
                            string thumfilename;
                            if (CopyFileToDir(DirectoryBase, imageFile.FileName, out NewFileName) &&
                                CopyFileToDir(DirectoryBase, imageFile.ThumbNailPath, out thumfilename))
                            {
                                imageFile.FileName = DirectoryBase + NewFileName;
                                imageFile.ThumbNailPath = DirectoryBase + thumfilename;
                            }
                            break;
                        case DataTypes.Folder:
                            DirectoryBase = Path.Combine(SavePathURL,
                                                         SelectedSectionID + @"\" + imageFile.CatigotyID + @"\Views\" +
                                                         imageFile.SelectionDate.Year + @"\" +
                                                         imageFile.SelectionDate.Month + @"\" + Guid.NewGuid());

                            CopyDirToDir(imageFile.ThumbNailPath, DirectoryBase);
                            imageFile.ThumbNailPath = DirectoryBase;
                            break;
                    }
                    if (SaveEntryTODB(imageFile))
                    {
                        SavingInfo.Content = "File [" + idx + " of " + count + "] Succedded";
                        InvalidateVisual();
                    }
                    else
                    {
                        SavingInfo.Content = "Saving File [" + idx + " of " + count + "] Failed";
                        InvalidateVisual();
                        break;
                    }
                    idx++;
                }
                else
                {
                    //TODO  This the database files that need to be updated
                    IQueryable<DataRecord> records = from rec in App.ActiveDatabase.DatabaseEntities.DataRecord where rec.RecordID == imageFile.ImageFileID.Value select rec;

                    DataRecord drecord = records.FirstOrDefault();
                    drecord.Title = imageFile.Title;
                    //App.ActiveDatabase.DatabaseEntities.Attach(drecord);

                }
                int updated=App.ActiveDatabase.DatabaseEntities.SaveChanges();
            }
            CancelBT.Content = "OK";
            CancelBT.Visibility = Visibility.Visible;
        }

        private bool SaveEntryTODB(ImageFile fileinfo)
        {
            DataRecord drec = new DataRecord();
            drec.Title = fileinfo.Title.Replace("No Title", "");
            drec.RecordID = Guid.NewGuid();
            drec.DataFile = fileinfo.FileName;
            drec.BelongToZone = isZone;
            drec.Caption = fileinfo.Title;
            drec.Category =
                App.ActiveDatabase.DatabaseEntities.Category.FirstOrDefault(c => c.CategoryID == fileinfo.CatigotyID);
            drec.DataEntryDate = fileinfo.SelectionDate;
            drec.ParentObjectID = fileinfo.ZoneRegionID;
            drec.EntryDateTime = DateTime.Now;
            if (fileinfo.Datatype == DataTypes.Video)
                drec.ThumbnailFile = fileinfo.ThumbNailPath;

            if (fileinfo.Datatype == DataTypes.Folder)
                drec.DataFile = fileinfo.ThumbNailPath;

            App.ActiveDatabase.DatabaseEntities.AddToDataRecord(drec);
            if (App.ActiveDatabase.DatabaseEntities.SaveChanges() > 0)
                return true;
            return false;
        }

        private void ClearListBT(object sender, RoutedEventArgs e)
        {
            Files.Clear();
           
        }

        private void CatChanged(object sender, SelectionChangedEventArgs e)
        {
            Files.Clear();
            if (comboBox1.SelectedValue != null)
            {
                SelectedCategoryID = ((Category)comboBox1.SelectedValue).CategoryID;
                GetDataFromDataBase();
            }
        }

        private void GetDataFromDataBase()
        {
            if (SelectedCategoryID == null)
                return;
            int m = int.Parse(((ComboBoxItem)Month.SelectedValue).Content.ToString());
            int y = int.Parse(((ComboBoxItem)Year.SelectedValue).Content.ToString());

            IQueryable<DataRecord> dbFiles;
            if(SelectedZoneRegionID==null)
               dbFiles= from dbfiles in App.ActiveDatabase.DatabaseEntities.DataRecord where dbfiles.Category.CategoryID == SelectedCategoryID && dbfiles.DataEntryDate.Year == y && dbfiles.DataEntryDate.Month == m select dbfiles;
            else
                dbFiles = from dbfiles in App.ActiveDatabase.DatabaseEntities.DataRecord where dbfiles.Category.CategoryID == SelectedCategoryID && dbfiles.DataEntryDate.Year == y && dbfiles.DataEntryDate.Month == m && dbfiles.ParentObjectID.Value == SelectedZoneRegionID.Value select dbfiles;
            
            foreach (DataRecord ditem in dbFiles)
            {
                ImageFile imf = new ImageFile(ditem.DataFile, ditem.Title, ((Category)comboBox1.SelectedValue).CategoryID, ditem.ParentObjectID, ditem.EntryDateTime, (DataTypes)Enum.Parse(typeof(DataTypes), ditem.RecordDataType.ToString()), ((Category)comboBox1.SelectedValue).ArName, ditem.ThumbnailFile, ditem.RecordID, true);
                Files.Add(imf);
            }
        }

        private void DeleteDatabaseRecord(Guid DataRecordID)
        {
            IQueryable<DataRecord> records = from rec in App.ActiveDatabase.DatabaseEntities.DataRecord where rec.RecordID == DataRecordID select rec;

            if (records.Count() > 0)
            {
                string filename = records.FirstOrDefault().DataFile;
                string thumnail = records.FirstOrDefault().ThumbnailFile;

                MessageBoxResult dResult = MessageBox.Show("Are you sure you want to delete the selected item from Databae",
                                                         "Delete Item",
                                                         MessageBoxButton.OKCancel);
                if (dResult == MessageBoxResult.OK)
                {
                    App.ActiveDatabase.DatabaseEntities.DeleteObject(records.FirstOrDefault());

                    if (App.ActiveDatabase.DatabaseEntities.SaveChanges() > 0)
                    {
                        Util.DeleteFile(filename);
                    }  
                }
              
            }
        }
        private void NewFilesDropedIn(object sender, DragEventArgs e)
        {
            object Formats = e.Data.GetData("FileDrop");
            Category curCat = (Category)comboBox1.Items[comboBox1.SelectedIndex];
            DataTypes catType = (DataTypes)curCat.DType;
            int M = int.Parse(((ComboBoxItem)Month.SelectedValue).Content.ToString());
            int Y = int.Parse(((ComboBoxItem)Year.SelectedValue).Content.ToString());
            DateTime seld = new DateTime(Y, M, 1);
            if (Formats != null)
            {
                string[] FileNames = (string[])Formats;                
                
                foreach (string fileName in FileNames)
                {
                    App.DoEvents();
                    if ((catType == DataTypes.Image || catType == DataTypes.ImageGalary) && isAllowed(fileName, catType))
                    {
                        ImageFile imf = new ImageFile(fileName, "No Title", curCat.CategoryID, SelectedZoneRegionID,
                                                      seld, catType, curCat.ArName);
                        Files.Add(imf);
                    }
                    else if (catType == DataTypes.Video && isAllowed(fileName, catType))
                    {
                        string thumb = ExtractVideoThumbnail(fileName);
                        if (thumb != string.Empty)
                        {
                            ImageFile imf = new ImageFile(thumb, "No Title", curCat.CategoryID, SelectedZoneRegionID,
                                                          seld, catType, curCat.ArName, fileName);
                            Files.Add(imf);
                        }
                    }
                    else if (Directory.Exists(fileName) && catType == DataTypes.Folder && Validate3Dfolder(fileName,16))
                    {
                        ImageFile imf = new ImageFile("/Images/3DView_Seq.png", "3D View Directory", curCat.CategoryID,
                                                      SelectedZoneRegionID, seld, catType, curCat.ArName, fileName);
                        Files.Add(imf);
                    }
                }
            }
            Debug.WriteLine("Test");
        }

        private string ExtractVideoThumbnail(string VideoFileName)
        {
            MediaDetClass md = new MediaDetClass();
            md.Filename = VideoFileName;
            md.CurrentStream = 0;
            string fBitmapName = Path.Combine(Path.GetDirectoryName(VideoFileName),
                                              Path.GetFileNameWithoutExtension(VideoFileName) + ".bmp");
            FileInfo fin = new FileInfo(fBitmapName);
            if (fin.Exists)
                fin.Delete();
            md.WriteBitmapBits(0, 512, 360, fBitmapName);
            fin = new FileInfo(fBitmapName);
            if (fin.Exists)
            {
                JpegBitmapEncoder jpg = new JpegBitmapEncoder();
                jpg.Frames.Add(BitmapFrame.Create(new Uri(fBitmapName)));
                string jpgfname = fBitmapName.Replace(".bmp", ".jpg");
                FileStream fs = File.Open(jpgfname, FileMode.OpenOrCreate);
                jpg.Save(fs);
                fs.Flush();
                fs.Close();
                jpg = null;
                fs = null;
                GC.Collect();
                //fin.Delete();
                fin = new FileInfo(jpgfname);
                if (fin.Exists)
                    return jpgfname;
            }
            return string.Empty;
        }

        private bool isAllowed(string Filename, DataTypes Checkfor)
        {
            string ext = Path.GetExtension(Filename);

            if (Checkfor == DataTypes.Image || Checkfor == DataTypes.ImageGalary)
            {
                switch (ext.ToLower())
                {
                    case ".gif":
                    case ".png":
                    case ".jpg":
                    case ".bmp":
                        return true;
                        break;
                }
                return false;
            }
            if (Checkfor == DataTypes.Video)
            {
                switch (ext.ToLower())
                {
                    case ".avi":
                    case ".wmv":
                    case ".mpg":
                        return true;
                }
                return false;
            }
            return false;
        }

        private bool CopyDirToDir(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest, true);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyDirToDir(folder, dest);
            }

            return true;
        }

        private bool CopyFileToDir(string Directory, string OrgFile, out string NewFileName)
        {
            DirectoryInfo oDir;
            FileInfo FilePath;
            FilePath = new FileInfo(OrgFile);
            oDir = new DirectoryInfo(Directory);
            NewFileName = Guid.NewGuid() + Path.GetExtension(OrgFile);
            if (oDir.Exists == false)
                oDir.Create();

            FileInfo NewFile = FilePath.CopyTo(Path.Combine(oDir.FullName, NewFileName), true);
            return NewFile.Exists;
        }
        private bool Validate3Dfolder(string BaseURL,int Rows)
        {
            DirectoryInfo info = new DirectoryInfo(BaseURL);
            if (info.Exists)
            {
                DirectoryInfo[] directories = info.GetDirectories();
                int rows = directories.Length;
                if (rows < Rows)
                {
                    Debug.WriteLine("Error in the file row counts in selected folder ");
                    SavingInfo.Content = "Error in the file row counts in selected folder ";
                   
                    return false;
                }
                string[,] Images = new string[rows, 30];
                int num = 0;
                foreach (DirectoryInfo info2 in directories)
                {
                    FileInfo[] files = info2.GetFiles("*.jpg");
                    int num2 = 0;
                    foreach (FileInfo info3 in files)
                    {
                        Images[num, num2] = info3.FullName;
                        num2++;
                    }
                    if (num2 < 30)
                    {
                        Debug.WriteLine("Error in the file count in folder " + info2.Name);
                         SavingInfo.Content ="Error in the file count in folder " + info2.Name;
                        return false;
                    }
                    num++;
                }
                Debug.Write("Done");
                return true;
            }
            return false;
        }
    }


    public class ImagePathConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            // value contains the full path to the image
            BitmapImage image = new BitmapImage();
            try
            {
string path = (string)value;

            // load the image, specify CacheOption so the file is not locked
            
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            try
            {
                image.UriSource = new Uri(path);
            }
            catch (Exception)
            {
                image.UriSource = new Uri(Util.BasePath() + path);
            }
            image.EndInit();
            }
            catch (Exception)
            {

                return null;
            }
            return image;
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        #endregion
    }

    public class ImageFile : INotifyPropertyChanged
    {
        private Guid _CatigotyID;
        private DataTypes _Datatype;
        private Visibility _HasValidTitle;
        private string _ImageFileName;
        private DateTime _SelectionDate;
        private string _ThumbNailPath;
        private string _Title;
        private Guid? _ZoneRegionID;
        private string _CatName;
        private Guid? _ImageFileID;
        private bool _InDataBase=false;

        public ImageFile(string ImgFileName, string title, Guid CategoryID, Guid? ZoneRegionID, DateTime CurSelDate,
                         DataTypes dataTypes, string CatName)
        {
            _ImageFileName = ImgFileName;
            _Title = title;
            _ZoneRegionID = ZoneRegionID;
            _SelectionDate = CurSelDate;
            _CatigotyID = CategoryID;
            _ZoneRegionID = ZoneRegionID;
            _Datatype = dataTypes;
            _CatName = CatName;
        }

        public ImageFile(string ImgFileName, string title, Guid CategoryID, Guid? ZoneRegionID, DateTime CurSelDate,
                         DataTypes dataTypes, string CatName, string Thumbnail)
            : this(ImgFileName, title, CategoryID, ZoneRegionID, CurSelDate, dataTypes, CatName)
        {
            _ThumbNailPath = Thumbnail;
        }

        public ImageFile(string ImgFileName, string title, Guid CategoryID, Guid? ZoneRegionID, DateTime CurSelDate,
                         DataTypes dataTypes, string CatName, string Thumbnail,Guid ImageFileID,bool indatabase):this(ImgFileName, title, CategoryID, ZoneRegionID, CurSelDate, dataTypes, CatName,Thumbnail)
        {
            if (indatabase)
            {
                _InDataBase = true;
                _ImageFileID = ImageFileID;
            }
        }

        public Visibility HasValidTitle
        {
            get
            {
                if (_Title == string.Empty ||
                    (_Title.Trim().Length > 0 && (_Title.ToLower() == "na" || _Title.ToLower() == "no title")))
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }

        public Visibility IsInDataBase
        {
            get
            {
                if (_InDataBase)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }
        public string FileName
        {
            get { return _ImageFileName; }
            set
            {
                _ImageFileName = value;
                Notify("FileName");
            }
        }

        public string CatName
        {
            get { return _CatName; }
            set
            {
                _CatName = value;
                Notify("CatName");
            }
        }
        public string ThumbNailPath
        {
            get { return _ThumbNailPath; }
            set
            {
                _ThumbNailPath = value;
                Notify("ThumbNailPath");
            }
        }

        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                Notify("Title");
                Notify("HasValidTitle");
            }
        }

        public Guid CatigotyID
        {
            get { return _CatigotyID; }
            set
            {
                _CatigotyID = value;
                Notify("CatigotyID");
            }
        }

        public Guid? ZoneRegionID
        {
            get { return _ZoneRegionID; }
            set
            {
                _ZoneRegionID = value;
                Notify("ZoneRegionID");
            }
        }

        public DateTime SelectionDate
        {
            get { return _SelectionDate; }
            set
            {
                _SelectionDate = value;
                Notify("SelectionDate");
            }
        }

        public DataTypes Datatype
        {
            get { return _Datatype; }
            set
            {
                _Datatype = value;
                Notify("Datatype");
            }
        }

        public Guid? ImageFileID { get { return _ImageFileID; } set { _ImageFileID = value; Notify("ImageFileID"); } }
        public bool InDatabase { get { return _InDataBase; } set { _InDataBase = value; Notify("InDatabase"); } }
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void Notify(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }

    public class ImageList : ObservableCollection<ImageFile>
    {
    }

    public enum DataTypes
    {
        Image = 0,
        ImageGalary = 1,
        Video = 2,
        Folder = 3
    }
}