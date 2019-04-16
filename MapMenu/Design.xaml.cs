#region System Refrences

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using InterActiveMap;
using System.Linq;
using MapMenu.EntryForms;

#endregion

namespace MapMenu
{
    /// <summary>
    /// Interaction logic for ConstructionDetails.xaml
    /// </summary>
    public partial class DesignMain
    {
        private DateTime CurDate = new DateTime(2009, 1, 1);
        private bool NorthSelected;
        private Guid? SelectedZoneID;

        public DesignMain()
        {
            InitializeComponent();
            FillSurfaces();
        }

        private void FillSurfaces()
        {
            MapViewer1.PolygonSurfaces = new LinkedList<MapViewer.PolygonSurface>();

            IQueryable<Zone> zoner = from zones in App.ActiveDatabase.DatabaseEntities.Zone select zones;


            foreach (Zone item in zoner)
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(item.PolyData);
                XmlNodeList xList = xdoc.SelectNodes("//Point");

                MapViewer.PolygonSurface nzone = new MapViewer.PolygonSurface();
                nzone.GUID = item.ID;
                nzone.Name = item.EnName;
                nzone.Type = 0;
                nzone.SurfaceID = item.ZoneID;
                nzone.ZoomFactor = (double)item.ZoomFactor;
                nzone.TranslateFactor = new Point((double)item.TranslateX, (double)item.TranslateY);
                nzone.FillColor = Color.FromRgb((byte)item.FillColorR, (byte)item.FillColorG, (byte)item.FillColorB);

                foreach (XmlNode xpoint in xList)
                {
                    nzone.Points.AddLast(new Point(double.Parse(xpoint.SelectSingleNode("X").InnerText),
                                                   double.Parse(xpoint.SelectSingleNode("Y").InnerText)));
                }
                MapViewer1.PolygonSurfaces.AddLast(nzone);
            }
            MapViewer1.Refresh();
        }

        public DesignMain(double ZoomFactor, Point Translationpoint, bool ZoneNotRegion, Guid? ZoneRegionID,
                                    DateTime CurselectedDate)
            : this()
        {
            InterActiveMap.SetZoom(ZoomFactor);
            InterActiveMap.SetPan(Translationpoint.X, Translationpoint.Y);
            MapViewer1.SelectSurface(ZoneRegionID.Value);
            SelectedZoneID = ZoneRegionID;
            ShowButtons();
        }



        private void ShowButtons()
        {
            DateTime CurSelectedDate = new DateTime(2009, 1, 1);
            IQueryable<Category> Categories = from category in App.ActiveDatabase.DatabaseEntities.Category
                                              where category.Sections.SectionID == Util.DesignGuid
                                              select category;

            wPanel.Children.Clear();
            foreach (Category category in Categories)
            {
                if (category.CategoryID == Util.SynopImageCat || category.CategoryID == Util.SynopVideoCat)
                    continue;
                IQueryable<DataRecord> drecords = from query in App.ActiveDatabase.DatabaseEntities.DataRecord
                                                  where
                                                      query.Category.CategoryID == category.CategoryID &&
                                                      query.ParentObjectID == SelectedZoneID
                                                  orderby query.EntryDateTime descending
                                                  select query;
                int d = drecords.Count();

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
                    if (App.CurLanguage == App.Language.Arabic)
                        bt.Content = category.ArName;
                    else
                        bt.Content = category.EnName;

                    bt.Tag = category;
                    bt.Click += new RoutedEventHandler(ShowCategoryDetails);
                    wPanel.Children.Add(bt);
                }
            }
            wPanel.InvalidateVisual();
        }
        private void ShowCategoryDetails(object sender, RoutedEventArgs e)
        {
            Category btcat = (Category)((Button)sender).Tag;
            IQueryable<DataRecord> dr = from query in App.ActiveDatabase.DatabaseEntities.DataRecord
                                        where
                                            query.Category.CategoryID == btcat.CategoryID &&
                                            query.ParentObjectID == SelectedZoneID
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
                            ShowButtons();
                        break;

                    case DataTypes.ImageGalary: //Image Gallary
                        ImageGalary ImageView = new ImageGalary(records);
                        ImageView.ShowDialog();
                        if (ImageView.DataChanged)
                            ShowButtons();

                        break;
                    case DataTypes.Video: // Video Galary
                        VideoGalary VideoView = new VideoGalary(records, btcat.HeaderImageFile);
                        VideoView.ShowDialog();
                        if (VideoView.DataChanged)
                            ShowButtons();
                        break;
                    case DataTypes.Folder: // 3D View                         
                        Design3DView view = new Design3DView(records[0]);
                        view.ShowDialog();
                        if (view.DataChanged)
                            ShowButtons();
                        break;
                }

                records.Clear();
            }
        }

        private void CloseThisWindow(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void ExitApplication(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}