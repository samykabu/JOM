#region System Refrences

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Xml;
using InterActiveMap;
using MapMenu.EntryForms;

#endregion

namespace MapMenu
{
    /// <summary>
    /// Interaction logic for ConstructionMain.xaml
    /// </summary>
    public partial class ConstructionMain : Window
    {
        private readonly DispatcherTimer ShowSynopTimer;
        private bool HasImgSynop, HasVidSynop;
        private bool IsZone;
        private int Month = 1;
        private Guid? SelectedObjGUID;
        private int Year = 2009;
        private bool inImageMode = false;
        private string imgTitle, vidTitle;
        ///<summary>
        ///</summary>
        public ConstructionMain()
        {
            try
            {
                InitializeComponent();

                if (App.IsInEditMode)
                    EditIcon.Visibility = Visibility.Visible;
                ShowSynopTimer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 500), DispatcherPriority.Normal, ShowSynop,
                                                     Dispatcher);

                ShowSynopTimer.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            FillSurfaces();
            ZonesList_OnZoneClicked(new Guid("{e7ebfad6-83fe-4a4c-a5be-4bc358f62a38}"), "");
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

            IQueryable<Region> zreg = from region in App.ActiveDatabase.DatabaseEntities.Region select region;
            foreach (Region item in zreg)
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(item.PolyData);
                XmlNodeList xList = xdoc.SelectNodes("//Point");
                MapViewer.PolygonSurface nregion = new MapViewer.PolygonSurface();
                nregion.GUID = item.ID;
                nregion.Type = 1;
                nregion.Name = item.EnName;
                nregion.SurfaceID = item.RegionID;
                nregion.ZoomFactor = (double)item.ZoomFactor;
                nregion.TranslateFactor = new Point((double)item.TranslateX, (double)item.TranslateY);
                nregion.FillColor = Color.FromRgb((byte)item.FillColorR, (byte)item.FillColorG, (byte)item.FillColorB);

                foreach (XmlNode xpoint in xList)
                {
                    nregion.Points.AddLast(new Point(double.Parse(xpoint.SelectSingleNode("X").InnerText),
                                                     double.Parse(xpoint.SelectSingleNode("Y").InnerText)));
                }
                MapViewer1.PolygonSurfaces.AddLast(nregion);
            }
            MapViewer1.Refresh();
        }

        ///<summary>
        ///</summary>
        ///<param name="PlayIt"></param>
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

        private void ySelector_DateChanged(int year, int month)
        {
            Year = year;
            Month = month;
            SynopImg.Visibility = Visibility.Visible;
            ImageIconBT.Visibility = Visibility.Collapsed;
            VideoIconBT.Visibility = Visibility.Collapsed;
            VideoSynopElm.Visibility = Visibility.Collapsed;
            HasImgSynop = false;
            HasVidSynop = false;
            ShowSynop(null, null);
        }

        private void ChangeInterface(object sender, RoutedEventArgs e)
        {
            InterfaceUI.Visibility = Visibility.Visible;
            Introv.Visibility = Visibility.Collapsed;
        }


        private void ExitApplication(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CloseThisWindow(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void ShowMetadataDialog(object sender, MouseButtonEventArgs e)
        {
            if (SelectedObjGUID != null)
            {
                DataUpload ent = new DataUpload(Util.ApplicationRoot, IsZone, SelectedObjGUID, Util.ConstructionGuid,
                                                new DateTime(Year, Month, 1));
                ent.ShowDialog();
            }
        }

        private void ZoomOut(object sender, MouseButtonEventArgs e)
        {
            InterActiveMap.SetZoom(InterActiveMap.ZoomLevel - 0.1);
        }

        private void Zoomin(object sender, MouseButtonEventArgs e)
        {
            InterActiveMap.SetZoom(InterActiveMap.ZoomLevel + 0.1);
        }


        private void ShowDetailsDialog(object sender, MouseButtonEventArgs e)
        {
            if (SelectedObjGUID != null)
            {
                ConstructionDetails CD = new ConstructionDetails(InterActiveMap.ZoomLevel, InterActiveMap.TPoint,
                                                                 IsZone, SelectedObjGUID, new DateTime(Year, Month, 1));
                CD.ShowDialog();
            }
        }

        private void ShowZoneRegionSynop()
        {
            SynopTitle.Content = "";

            IOrderedQueryable<DataRecord> ImageSynops =
                from dataRecord in App.ActiveDatabase.DatabaseEntities.DataRecord
                where
                    dataRecord.ParentObjectID == SelectedObjGUID && dataRecord.Category.CategoryID == Util.SynopImageCat && dataRecord.DataEntryDate.Year == Year && dataRecord.DataEntryDate.Month == Month
                orderby dataRecord.EntryDateTime descending
                select dataRecord;

            if (ImageSynops.Count() > 0)
            {
                imgTitle = ImageSynops.First().Title;
                SynopImg.Source = Util.LoadImage(ImageSynops.First().DataFile, UriKind.Absolute);
                HasImgSynop = true;
            }
            else
            {
                HasImgSynop = false;
            }

            IOrderedQueryable<DataRecord> VideoSynops =
                from dataRecord in App.ActiveDatabase.DatabaseEntities.DataRecord
                where
                    dataRecord.ParentObjectID == SelectedObjGUID && dataRecord.Category.CategoryID == Util.SynopVideoCat && dataRecord.DataEntryDate.Year == Year && dataRecord.DataEntryDate.Month == Month
                orderby dataRecord.EntryDateTime descending
                select dataRecord;

            if (VideoSynops.Count() > 0)
            {
                vidTitle = VideoSynops.First().Title;
                VideoSynopElm.Source = new Uri(VideoSynops.First().ThumbnailFile);
                HasVidSynop = true;
            }
            else
            {
                HasVidSynop = false;
            }
            SynopTitle.Content = SynopTitlestr(imgTitle);
        }


        private void ShowSynop(object sender, EventArgs e)
        {
            ShowSynopTimer.IsEnabled = false;

            SynopImg.Source = null;
            VideoSynopElm.Source = null;

            try
            {
                VideoSynopElm.Stop();
            }
            catch (Exception)
            {

            }

            if (SelectedObjGUID != null)
            {

                ShowZoneRegionSynop();
                if (HasVidSynop)
                {
                    VideoIconBT.Visibility = Visibility.Visible;
                }
                SynopImg.Visibility = Visibility.Visible;
                VideoSynopElm.Visibility = Visibility.Collapsed;

                if (HasVidSynop || HasImgSynop)
                {
                    Storyboard bStoryBoard = (Storyboard)Resources["ShowSynop"];
                    if (bStoryBoard != null && SynopCanvas.Visibility != Visibility.Visible)
                        bStoryBoard.Begin();
                    else
                        SynopCanvas.Visibility = Visibility.Visible;
                }
                else
                {
                    Storyboard bStoryBoard = (Storyboard)Resources["HideSynop"];
                    if (bStoryBoard != null && SynopCanvas.Visibility != Visibility.Collapsed)
                        bStoryBoard.Begin();
                    else
                        SynopCanvas.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                Storyboard bStoryBoard = (Storyboard)Resources["HideSynop"];
                if (bStoryBoard != null && SynopCanvas.Visibility != Visibility.Collapsed)
                    bStoryBoard.Begin();
                else
                    SynopCanvas.Visibility = Visibility.Collapsed;
            }

            if (HasVidSynop && !HasImgSynop)
                ShowVideoSynop(null, null);
            VideoSynopElm.InvalidateVisual();
            SynopImg.InvalidateVisual();
        }


        private void MoveView(double ZoomFactor, double X, double Y)
        {
            InterActiveMap.SetPan(X, Y);
            InterActiveMap.SetZoom(ZoomFactor);
            InvalidateVisual();
        }

        private void ZonesList_OnZoneClicked(Guid cat, string ZoneName)
        {

            var szone = from zz in App.ActiveDatabase.DatabaseEntities.Zone where zz.ID == cat select zz;
            var zone = szone.FirstOrDefault();
            MoveView((double)zone.ZoomFactor, (double)zone.TranslateX, (double)zone.TranslateY);
            MoveView((double)zone.ZoomFactor, (double)zone.TranslateX, (double)zone.TranslateY);
            //5MapViewer1.SelectSurface(cat);
            //OnMapViewSelectionChanged(true, cat);

        }

        private void ShowImageSynop(object sender, MouseButtonEventArgs e)
        {
            inImageMode = true;
            SynopTitle.Content = SynopTitlestr(imgTitle);
            if (HasVidSynop)
            {
                VideoIconBT.Visibility = Visibility.Visible;
                VideoSynopElm.Visibility = Visibility.Collapsed;
                VideoSynopElm.Stop();
            }
            SynopImg.Visibility = Visibility.Visible;
            ImageIconBT.Visibility = Visibility.Collapsed;

        }

        private string SynopTitlestr(string iTitle)
        {
            if (iTitle != null && iTitle.Length > 0 && iTitle.IndexOf('|') > 0)
            {
                string[] title;
                title = iTitle.Split('|');
                if (title.Length > 1 && App.CurLanguage == App.Language.English)
                    return title[1];
                else
                    return title[0];
            }
            else
            {
                if (iTitle == null)
                    return string.Empty;
                return iTitle.Replace("|", "");
            }
        }
        private void ChangeLanguage(object sender, MouseButtonEventArgs e)
        {
            if (App.CurLanguage == App.Language.Arabic)
                App.CurLanguage = App.Language.English;
            else
                App.CurLanguage = App.Language.Arabic;
            sysVar.Instance.isEnglish = !sysVar.Instance.isEnglish;
        }
        private void ShowVideoSynop(object sender, MouseButtonEventArgs e)
        {
            inImageMode = false;
            SynopTitle.Content = SynopTitlestr(vidTitle);
            try
            {
                VideoSynopElm.Stop();
            }
            catch (Exception)
            {

            }
            VideoIconBT.Visibility = Visibility.Collapsed;
            SynopImg.Visibility = Visibility.Hidden;
            VideoSynopElm.Visibility = Visibility.Visible;
            VideoSynopElm.Play();
            if (HasImgSynop)
            {
                ImageIconBT.Visibility = Visibility.Visible;
            }

        }

        private void VideoSynopElm_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (VideoSynopElm.Visibility == Visibility.Visible)
            {
                VideoSynopElm.Stop();
                VideoSynopElm.Play();
            }
        }

        private void OnMapViewSelectionChanged(bool zone, Guid guid)
        {
            SelectedObjGUID = guid;
            IsZone = zone;
            SynopImg.Visibility = Visibility.Visible;
            ImageIconBT.Visibility = Visibility.Collapsed;
            VideoIconBT.Visibility = Visibility.Collapsed;
            VideoSynopElm.Visibility = Visibility.Collapsed;
            HasImgSynop = false;
            HasVidSynop = false;
            ShowSynop(null, null);
        }

        private void OnMapViewSelectionClear()
        {
            Storyboard bStoryBoard = (Storyboard)Resources["HideSynop"];
            if (bStoryBoard != null && SynopCanvas.Visibility == Visibility.Visible)
            {
                ImageIconBT.Visibility = Visibility.Collapsed;
                VideoIconBT.Visibility = Visibility.Collapsed;
                bStoryBoard.Begin();
            }
            else
                SynopCanvas.Visibility = Visibility.Collapsed;

            SelectedObjGUID = null;
            IsZone = false;
        }
    }
}