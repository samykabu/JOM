#region System Refrences

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using InterActiveMap;
using MapMenu.EntryForms;

#endregion

namespace MapMenu
{
    /// <summary>
    /// Interaction logic for ConstructionDetails.xaml
    /// </summary>
    public partial class ConstructionDetails : Window
    {
        private readonly MetaData cMetadata;
        //private readonly InterActiveMap.InterActiveMap iMap;
        private readonly double zLevel;
        private DateTime CurSelectedDate;
        private Point TP;
        private bool zoneNotregion;
        private Guid? zoneregionID;
        private bool Show3DButton = false;
        ///<summary>
        ///</summary>
        public ConstructionDetails()
        {
            InitializeComponent();
        }

        ///<summary>
        ///</summary>
        ///<param name="ZoomFactor"></param>
        ///<param name="Translationpoint"></param>
        ///<param name="ZoneNotRegion"></param>
        ///<param name="ZoneRegionID"></param>
        ///<param name="CurselectedDate"></param>
        ///<param name="Map"></param>
        public ConstructionDetails(double ZoomFactor, Point Translationpoint, bool ZoneNotRegion, Guid? ZoneRegionID,
                                   DateTime CurselectedDate)
        {
            if (ZoneRegionID == null)
                Close();

            InitializeComponent();

            zLevel = ZoomFactor;
            TP = Translationpoint;
            CurSelectedDate = CurselectedDate;

            zoneregionID = ZoneRegionID;
            zoneNotregion = ZoneNotRegion;

            if (zoneNotregion)
            {
                IQueryable<Zone> zon = from zz in App.ActiveDatabase.DatabaseEntities.Zone
                                       where zz.ID == ZoneRegionID
                                       select zz;
                ZoneNameLBL.Content = zon.First().ArName;
            }
            else
            {
                IQueryable<Region> zon = from zz in App.ActiveDatabase.DatabaseEntities.Region
                                         where zz.ID == ZoneRegionID
                                         select zz;
                ZoneNameLBL.Content = zon.First().ArName;
            }

            ySelector.SetSelectionTo(CurSelectedDate);
        }


        private void ySelector_DateChanged(int Year, int Month)
        {
            CurSelectedDate = new DateTime(Year, Month, 1);
            Show3DButton = false;
            IQueryable<Category> Categories = from category in App.ActiveDatabase.DatabaseEntities.Category
                                              where category.Sections.SectionID == Util.ConstructionGuid
                                              select category;
            if (zoneNotregion)
            {
                IQueryable<Zone> zon = from zz in App.ActiveDatabase.DatabaseEntities.Zone
                                       where zz.ID == zoneregionID
                                       select zz;
                ZoneNameLBL.Content = zon.First().ArName;
            }
            else
            {
                IQueryable<Region> zon = from zz in App.ActiveDatabase.DatabaseEntities.Region
                                         where zz.ID == zoneregionID
                                         select zz;
                ZoneNameLBL.Content = zon.First().ArName;
            }

            wPanel.Children.Clear();
            foreach (Category category in Categories)
            {
                if (category.CategoryID == Util.SynopImageCat || category.CategoryID == Util.SynopVideoCat)
                    continue;
                IQueryable<DataRecord> drecords = from query in App.ActiveDatabase.DatabaseEntities.DataRecord
                                                  where
                                                      query.Category.CategoryID == category.CategoryID &&
                                                      query.ParentObjectID == zoneregionID &&
                                                      query.DataEntryDate == CurSelectedDate
                                                  select query;
                int d = drecords.Count();

                //ff59cdda-93aa-4cf0-96c1-d5c391bd37d8
                if (d > 0)
                {
                    Button bt = new Button();
                    bt.Template = (ControlTemplate)FindResource("GlassButton");
                    bt.FontFamily = new FontFamily("Simplified Arabic");
                    bt.FontSize = 20;
                    bt.Foreground = Brushes.White;
                    bt.FontWeight = FontWeights.Bold;
                    bt.Width = 310;
                    bt.Height = 35;
                    bt.Tag = category;

                    if (App.CurLanguage == App.Language.Arabic)
                        bt.Content = category.ArName;
                    else
                        bt.Content = category.EnName;

                    if ((category.CategoryID == Util.Construction3DViewVirtual || category.CategoryID == Util.Construction3DViewReal))
                    {
                        if (!Show3DButton)
                            Show3DButton = true;
                        else
                            continue;

                        if (App.CurLanguage == App.Language.Arabic)
                            bt.Content = "المنظور المتحرك الثلاثي الأبعاد";
                        else
                            bt.Content = "3D View";

                    }

                    bt.Click += new RoutedEventHandler(ShowCategoryDetails);
                    wPanel.Children.Add(bt);
                }
            }
            wPanel.InvalidateVisual();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void ShowCategoryDetails(object sender, RoutedEventArgs e)
        {
            Category btcat = (Category)((Button)sender).Tag;
            IQueryable<DataRecord> dr = from query in App.ActiveDatabase.DatabaseEntities.DataRecord
                                        where
                                            query.Category.CategoryID == btcat.CategoryID &&
                                            query.ParentObjectID == zoneregionID &&
                                            query.DataEntryDate.Year == CurSelectedDate.Year &&
                                            query.DataEntryDate.Month == CurSelectedDate.Month
                                        orderby query.EntryDateTime descending
                                        select query;
            List<DataRecord> records = new List<DataRecord>();
            foreach (DataRecord record in dr)
            {
                records.Add(record);
            }
            if (records.Count > 0)
            {
                DataTypes dtype = (DataTypes)btcat.DType;
                switch (dtype)
                {
                    case DataTypes.Image: //Image Page View Galary                    
                        ImageGalaryPageView ImageGPageView = new ImageGalaryPageView(records,
                                                                                    btcat.HeaderImageFile);
                        ImageGPageView.ShowDialog();
                        if (ImageGPageView.DataChanged)
                            ySelector_DateChanged(CurSelectedDate.Year, CurSelectedDate.Month);
                        break;

                    case DataTypes.ImageGalary: //Image Gallary
                        ImageGalary ImageView = new ImageGalary(records);
                        ImageView.ShowDialog();
                        if (ImageView.DataChanged)
                            ySelector_DateChanged(CurSelectedDate.Year, CurSelectedDate.Month);

                        break;
                    case DataTypes.Video: // Video Galary
                        VideoGalary VideoView = new VideoGalary(records, btcat.HeaderImageFile);
                        VideoView.ShowDialog();
                        if (VideoView.DataChanged)
                            ySelector_DateChanged(CurSelectedDate.Year, CurSelectedDate.Month);
                        break;
                    case DataTypes.Folder: // 3D View 
                        _3DView view = new _3DView(CurSelectedDate.Year, CurSelectedDate.Month, Util.Construction3DViewReal, Util.Construction3DViewVirtual, zoneregionID.Value);
                        view.ShowDialog();
                        if (view.DataChanged)
                            ySelector_DateChanged(CurSelectedDate.Year, CurSelectedDate.Month);
                        break;
                }

                records.Clear();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            zpCanvas.SetZoom(zLevel);
            zpCanvas.SetPan(TP.X, TP.Y);
        }

        private void RefreshButtons()
        {
            DateTime dt = DateTime.Parse(ySelector.DateString);
            ySelector_DateChanged(dt.Year, dt.Month);
        }

        private void ExitApplication(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CloseThisWindow(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void ChangeLanguage(object sender, MouseButtonEventArgs e)
        {
            if (App.CurLanguage == App.Language.Arabic)
                App.CurLanguage = App.Language.English;
            else
                App.CurLanguage = App.Language.Arabic;

            sysVar.Instance.isEnglish =! sysVar.Instance.isEnglish;

            ySelector_DateChanged(CurSelectedDate.Year, CurSelectedDate.Month);
        }

    }
}