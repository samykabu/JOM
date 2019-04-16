using System.Windows;
using System.Windows.Controls;

namespace DataEntryList
{
    /// <summary>
    /// Interaction logic for DragDropEntry.xaml
    /// </summary>
    public partial class DragDropEntry : UserControl
    {
        public ImageList Files
        {
            get { return (ImageList)GetValue(FilesProperty); }
            set { SetValue(FilesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Files.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilesProperty =
            DependencyProperty.Register("Files", typeof(ImageList), typeof(DragDropEntry), new UIPropertyMetadata(null));

        public DragDropEntry()
        {
            Files = new ImageList();
            InitializeComponent();
        }

        public DragDropEntry(string CategoryName)
            : base()
        {
            lbCategoryName.Content = CategoryName;
        }
        private void NewFilesDropedIn(object sender, DragEventArgs e)
        {
            object Formats = e.Data.GetData("FileDrop");
            if (Formats != null)
            {
                string[] FileNames = (string[])Formats;
                foreach (string fileName in FileNames)
                {
                    ImageFile imf = new ImageFile(fileName, "No Title", 0);
                    Files.Add(imf);
                }
            }
            System.Diagnostics.Debug.WriteLine("Test");
        }

        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            ImageFile img = (ImageFile)bt.DataContext;
            Files.Remove(img);
        }
    }
}
