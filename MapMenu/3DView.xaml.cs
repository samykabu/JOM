#region System Refrences

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using InterActiveMap;

#endregion

namespace MapMenu
{
    /// <summary>
    /// Interaction logic for ConstructionDetails.xaml
    /// </summary>
    public partial class _3DView
    {
        private Guid _RealViewCategoryID, _VirtualViewCategoryID;
        private Guid _ZoneRegionID;
        private int CMonth;
        private int CYear;
        private bool Fullscreen;
        private DataRecord SelectedViews;
        private DispatcherTimer StopPlayTime;
        public bool DataChanged = false;

        private bool Virtual = true;

        public _3DView()
        {
            InitializeComponent();
            if (App.IsInEditMode)
            {
                DeleteItemIcon.Visibility = Visibility.Visible;
            }
        }

        public _3DView(int Year, int Month, Guid RealViewCategoryID, Guid VirtualViewCategoryID, Guid ZoneRegionID)
            : this()
        {
            StopPlayTime = new DispatcherTimer(DispatcherPriority.Normal, Dispatcher);
            StopPlayTime.Interval = TimeSpan.FromSeconds(6);
            StopPlayTime.Tick += StopPlayTime_Tick;
            View3D.Visibility = Visibility.Collapsed;

            _RealViewCategoryID = RealViewCategoryID;
            _VirtualViewCategoryID = VirtualViewCategoryID;
            _ZoneRegionID = ZoneRegionID;

            CYear = Year;
            CMonth = Month;
            Canvas.GetLeft(View3D);
            Canvas.GetTop(View3D);
            Panel.GetZIndex(View3D);

            RealBT.Source = Util.LoadImage(@"Images\3DStatusTab-RealBtn-Hilit.png", UriKind.Relative);
            VirtualBT.Source = Util.LoadImage(@"Images\3DStatusTab-VirtualBtn-Hilit.png", UriKind.Relative);

            RealView(null, null);
            ySelector.SetSelectionTo(new DateTime(Year, Month, 1));
            //StopPlayTime.IsEnabled = true;
        }

        private void StopPlayTime_Tick(object sender, EventArgs e)
        {
            StopPlayTime.IsEnabled = false;
            View3D.Stop();
        }

        private void CloseThisWindow(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void ExitApplication(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ySelector_DateChanged(int Year, int Month)
        {
            CYear = Year;
            CMonth = Month;

            if (Virtual)
                ShowVirtualData(Year, Month);
            else
                ShowRealData(Year, Month);
        }

        private void ShowVirtualData(int Year, int Month)
        {
            DateTime LookFoDate = new DateTime(Year, Month, 1);
            var VirtData = from query in App.ActiveDatabase.DatabaseEntities.DataRecord
                           where
                               query.Category.CategoryID == _VirtualViewCategoryID &&
                               query.ParentObjectID == _ZoneRegionID &&
                               query.DataEntryDate == LookFoDate
                           orderby query.EntryDateTime descending
                           select query;


            if (VirtData.Count() > 0)
                SelectedViews = VirtData.FirstOrDefault();
            else
            {
                SelectedViews = null;
            }

            if (SelectedViews != null)
            {
                if (App.CurLanguage == App.Language.Arabic)
                    label1.Content = string.Format("مطابقة تنفيذ العمل للمخطط المقترح من قبل المقاول    " + "%{0}", SelectedViews.Title);
                else
                    label1.Content = string.Format("Contractor project progress " + "%{0}", SelectedViews.Title);

                View3D.ViewFolder = SelectedViews.DataFile;
                View3D.Visibility = Visibility.Visible;
            }
            else
            {
                View3D.Visibility = Visibility.Collapsed;
                label1.Content = " ";
            }
        }

        private void ShowRealData(int Year, int Month)
        {
            DateTime LookFoDate = new DateTime(Year, Month, 1);
            var realv = from query in App.ActiveDatabase.DatabaseEntities.DataRecord
                        where
                            query.Category.CategoryID == _RealViewCategoryID &&
                            query.ParentObjectID == _ZoneRegionID &&
                            query.DataEntryDate == LookFoDate
                        orderby query.EntryDateTime descending
                        select query;

            if (realv.Count() > 0)
                SelectedViews = realv.FirstOrDefault();
            else
            {
                SelectedViews = null;
            }

            if (SelectedViews != null)
            {
                label1.Content = string.Format("مطابقة تنفيذ العمل للمخطط المقترح     " + "%{0}", SelectedViews.Title);
                View3D.ViewFolder = SelectedViews.DataFile;
                View3D.Visibility = Visibility.Visible;
            }
            else
            {
                View3D.Visibility = Visibility.Collapsed;
                label1.Content = " ";
            }
        }

        private void RealView(object sender, MouseButtonEventArgs e)
        {
            Panel.SetZIndex(RealBT, 8);
            Panel.SetZIndex(VirtualBT, 7);
            Virtual = false;
            ShowRealData(CYear, CMonth);
        }

        private void VirtualView(object sender, MouseButtonEventArgs e)
        {
            Panel.SetZIndex(RealBT, 7);
            Panel.SetZIndex(VirtualBT, 8);
            Virtual = true;
            ShowVirtualData(CYear, CMonth);
        }

        private void PlayRotation(object sender, MouseButtonEventArgs e)
        {
            View3D.Play();
        }

        private void StopRotation(object sender, MouseButtonEventArgs e)
        {
            View3D.Stop();
        }

        private void FullScreen(object sender, MouseButtonEventArgs e)
        {
            ViewContainer.Children.Remove(View3D);
            FullCanvas.Children.Add(View3D);
            View3D.Width = 1280;
            View3D.Height = 720;
            FullCanvas.Visibility = Visibility.Visible;
            Fullscreen = true;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (Fullscreen && e.Key == Key.Escape)
            {
                FullCanvas.Children.Remove(View3D);
                ViewContainer.Children.Add(View3D);
                View3D.Width = 1268;
                View3D.Height = 489.622;
                FullCanvas.Visibility = Visibility.Collapsed;
                Fullscreen = false;
            }
        }

        private void deleteItem(object sender, MouseButtonEventArgs e)
        {
            //TODO: add folder delete
            App.ActiveDatabase.DatabaseEntities.DeleteObject(SelectedViews);
            if (App.ActiveDatabase.DatabaseEntities.SaveChanges() > 0)
            {
                DataChanged = true;
                SelectedViews = null;
                if (Virtual)
                    ShowVirtualData(CYear, CMonth);
                else
                {
                    ShowRealData(CYear, CMonth);
                }
            }
        }
    }
}