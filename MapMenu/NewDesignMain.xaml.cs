#region System Refrences
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Xml;
using System.Linq;
using InterActiveMap;
using MapMenu.EntryForms;
#endregion

namespace MapMenu
{
    /// <summary>
    /// Interaction logic for ConstructionMain.xaml
    /// </summary>
    public partial class NewDesignMain : Window
    {
        public int Month = 1;
        private Guid? SelectedZoneID;
        public int Year = 2009;

        public NewDesignMain()
        {
            InitializeComponent();
            if (App.IsInEditMode)
                EditIcon.Visibility = Visibility.Visible;
            FillSurfaces();
            
           // OnZoneSelected(new Guid("{e7ebfad6-83fe-4a4c-a5be-4bc358f62a38}"),"");
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

        public void SetAnimation(bool PlayIt)
        {
            if (PlayIt)
            {
                Introv.Visibility = Visibility.Visible;
                InterfaceUI.Opacity = 0;
                Storyboard Movi = (Storyboard)Resources["GlobeIntro2_wmv"];
                if (Movi != null) Movi.Begin();
            }
            else
            {
                Introv.Visibility = Visibility.Collapsed;
                InterfaceUI.Opacity = 1;
            }
        }
        private void InterActiveMap_PosChanged(double x, double y, double ZoomLevel)
        {
            if (ZoomLevel == 1)
            {
                Canvas.SetLeft(ZoomedMap, x);
                Canvas.SetTop(ZoomedMap, y);
                ZoomedMap.Width = 668;
                ZoomedMap.Height = 456;
            }
            else
            {
                Canvas.SetLeft(ZoomedMap, x / ZoomLevel);
                Canvas.SetTop(ZoomedMap, y / ZoomLevel);
                ZoomedMap.Width = 668 * (1 / ZoomLevel);
                ZoomedMap.Height = 456 * (1 / ZoomLevel);
            }

            VVV.InvalidateArrange();
            VVV.InvalidateVisual();
        }    

        private void ExitApplication(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void CloseThisWindow(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
        private void ZoomOut(object sender, MouseButtonEventArgs e)
        {
            InterActiveMap.SetZoom(InterActiveMap.ZoomLevel - 0.1);
        }
        private void Zoomin(object sender, MouseButtonEventArgs e)
        {
            InterActiveMap.SetZoom(InterActiveMap.ZoomLevel + 0.1);
        }

        private void ShowMetadataDialog(object sender, MouseButtonEventArgs e)
        {           
            if (SelectedZoneID != null)
            {
                DataUpload ent = new DataUpload(Util.ApplicationRoot, true, SelectedZoneID, Util.DesignGuid,
                                                new DateTime(Year, Month, 1));
                ent.DisableDateSelection();
                ent.ShowDialog();
            }
        }



        private void ShowDetailsDialog(object sender, MouseButtonEventArgs e)
        {
            if (SelectedZoneID!=null)
            {
                var CD = new DesignMain(InterActiveMap.ZoomLevel, InterActiveMap.TPoint,true,SelectedZoneID,new DateTime(2009,1,1));
                CD.ShowDialog();
            }
        }


        private void ChangeInterface(object sender, RoutedEventArgs e)
        {
            InterfaceUI.Visibility = Visibility.Visible;
            Introv.Visibility = Visibility.Collapsed;
        }

        private void MoveView(double ZoomFactor, double X, double Y)
        {
            InterActiveMap.SetPan(X, Y);
            InterActiveMap.SetZoom(ZoomFactor);
            InvalidateVisual();
        }

        private void OnMapSelectionChanged(bool zone, Guid guid)
        {
            SelectedZoneID = guid;
        }

        private void OnZoneSelected(Guid cat, string ZoneName)
        {
            MapViewer1.SelectSurface(cat);
            var szone = from zz in App.ActiveDatabase.DatabaseEntities.Zone where zz.ID == cat select zz;
            var zone = szone.FirstOrDefault();
            MoveView((double)zone.ZoomFactor, (double)zone.TranslateX, (double)zone.TranslateY);
            MoveView((double)zone.ZoomFactor, (double)zone.TranslateX, (double)zone.TranslateY);
        }

        private void ClearZoneSelection()
        {
            SelectedZoneID = null;
        }


    }
}