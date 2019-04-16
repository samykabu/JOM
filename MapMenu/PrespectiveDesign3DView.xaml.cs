#region System Refrences

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using InterActiveMap;
using System.Linq;
using MapMenu.EntryForms;

#endregion

namespace MapMenu
{
    /// <summary>
    /// Interaction logic for ConstructionDetails.xaml
    /// </summary>
    public partial class PrespectiveDesign3DView
    {
        private int CMonth;
        private int CYear;
        private DispatcherTimer dTimer;
        private bool Fullscreen;
        private DataRecord CurSelectionRecord;
        private Guid? CatID;

        //private DispatcherTimer StopPlayTime;


        public PrespectiveDesign3DView()
        {
            InitializeComponent();
            if (App.IsInEditMode)
            {
                EditIcon.Visibility = Visibility.Visible;
                DeleteItemIcon.Visibility = Visibility.Visible;
            }
            dTimer = new DispatcherTimer(DispatcherPriority.Normal, Dispatcher);
            dTimer.Tick += dTimer_Tick;
            View3D.Visibility = Visibility.Collapsed;

            //StopPlayTime = new DispatcherTimer(DispatcherPriority.Normal, this.Dispatcher);
            //StopPlayTime.Interval = TimeSpan.FromSeconds(6);
            //StopPlayTime.Tick += new EventHandler(StopPlayTime_Tick);
            ////StopPlayTime.IsEnabled = true;            
            dTimer.IsEnabled = true;
        }

        public PrespectiveDesign3DView(int Year, int Month)
            : this()
        {
            ShowDataReal(Year, Month);
            CYear = Year;
            CMonth = Month;
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

        private void ChangeInterface(object sender, RoutedEventArgs e)
        {
            InterfaceUI.Visibility = Visibility.Visible;
            Introv.Visibility = Visibility.Collapsed;
        }

        //void StopPlayTime_Tick(object sender, EventArgs e)
        //{
        //    StopPlayTime.IsEnabled = false;
        //    View3D.Stop();
        //}

        private void dTimer_Tick(object sender, EventArgs e)
        {
            dTimer.IsEnabled = false;
            ShowDataReal(CYear, CMonth);
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
            dTimer.IsEnabled = false;
            dTimer.Interval = new TimeSpan(0, 0, 0, 0, 350);
            dTimer.IsEnabled = true;
        }


        private void ShowDataReal(int Year, int Month)
        {
            DateTime CurSelectedDate = new DateTime(Year, Month, 1);
            var preCat = from objectQuery in App.ActiveDatabase.DatabaseEntities.Category
                         where objectQuery.Sections.SectionID == Util.PrespectiveGuid
                         select objectQuery;

            CatID = preCat.FirstOrDefault().CategoryID;

            IQueryable<DataRecord> drecords = from query in App.ActiveDatabase.DatabaseEntities.DataRecord
                                              where
                                                  query.Category.CategoryID == CatID &&
                                                  query.DataEntryDate == CurSelectedDate
                                              select query;
            int d = drecords.Count();


            if (d > 0)
            {
                CurSelectionRecord = drecords.FirstOrDefault();
                if (App.CurLanguage == App.Language.Arabic)
                    label1.Content = string.Format("مطابقة تنفيذ العمل للمخطط الزمني     " + "%{0}", CurSelectionRecord.Title);
                else
                    label1.Content = string.Format("Project progress percentage " + "%{0}", CurSelectionRecord.Title);

                View3D.ViewFolder = CurSelectionRecord.DataFile;
                View3D.Visibility = Visibility.Visible;
                View3D.InvalidateVisual();
            }
            else
            {
                CurSelectionRecord = null;
                View3D.Visibility = Visibility.Collapsed;
                label1.Content = " ";
            }

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

        private void ShowMetadataDialog(object sender, MouseButtonEventArgs e)
        {
            DataUpload dentry = new DataUpload(Util.ApplicationRoot, true, null, Util.PrespectiveGuid, new DateTime(CYear, CMonth, 1));
            dentry.ShowDialog();
            ShowDataReal(CYear, CMonth);
        }


        private void DeleteCurrentItem(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult dResult = MessageBox.Show("Are you sure you want to delete the selected View",
                                                      "Delete 3D View",
                                                      MessageBoxButton.OKCancel);
            if (dResult == MessageBoxResult.OK)
            {
                View3D.Stop();
                ViewContainer.Visibility = Visibility.Collapsed;
                App.ActiveDatabase.DatabaseEntities.DeleteObject(CurSelectionRecord);
                if (App.ActiveDatabase.DatabaseEntities.SaveChanges() > 0)
                {
                    Util.DeleteDir(CurSelectionRecord.DataFile);
                    ShowDataReal(CYear, CMonth);
                    Close();
                }

            }
        }
    }
}