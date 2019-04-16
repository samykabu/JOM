#region System Refrences

using System;
using System.Collections.Generic;
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
    public partial class Design3DView
    {        
        public DataRecord Selected3DView;
        private bool Fullscreen;
        private DispatcherTimer StopPlayTime;
        public bool DataChanged = false;
        private bool ShowCustomLabel = true;

        public Design3DView()
        {
            InitializeComponent();
            if (App.IsInEditMode)
                DeleteItemIcon.Visibility = Visibility.Visible;
        }

        public Design3DView(DataRecord selected3DView):this()
        {                       

            View3D.Visibility = Visibility.Collapsed;
            Selected3DView = selected3DView;            
            View3D.Play();
            ShowData();
            
            StopPlayTime = new DispatcherTimer(DispatcherPriority.Normal, Dispatcher);
            StopPlayTime.Interval = TimeSpan.FromSeconds(6);
            StopPlayTime.Tick += StopPlayTime_Tick;
            StopPlayTime.IsEnabled = true;
        }
        public Design3DView(DataRecord selected3DView,bool ShowCustLabel)
            : this(selected3DView)
        {
            ShowCustomLabel = ShowCustLabel;
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

        private void ShowData()
        {
            if (ShowCustomLabel)
            {
                label1.Content = string.Format("مطابقة تنفيذ العمل للمخطط المقترح     " + "%{0}", Selected3DView.Title);    
            }
            else
            {
                label1.Content = Selected3DView.Title;
            }
            
            View3D.ViewFolder = Selected3DView.DataFile;
            View3D.Visibility = Visibility.Visible;
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
                View3D.Height = 620.133;
                FullCanvas.Visibility = Visibility.Collapsed;
                Fullscreen = false;
            }
        }

        private void DeleteView(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult dResult = MessageBox.Show("Are you sure you want to delete the selected View",
                                                       "Delete 3D View",
                                                       MessageBoxButton.OKCancel);
            if (dResult == MessageBoxResult.OK)
            {
                View3D.Stop();
                View3D = null;
                ViewContainer.Visibility = Visibility.Collapsed;
                App.ActiveDatabase.DatabaseEntities.DeleteObject(Selected3DView);
                if (App.ActiveDatabase.DatabaseEntities.SaveChanges() > 0)
                {
                    Util.DeleteDir(Selected3DView.DataFile);
                    DataChanged = true;
                    Close();
                }                            
                
            }
        }
    }
}