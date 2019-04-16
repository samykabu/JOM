#region System Refrences

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using FluidKit.Controls;

#endregion

namespace MapMenu
{
    /// <summary>
    /// Interaction logic for ImageGalary.xaml
    /// </summary>
    public partial class ImageGalary : Window
    {
        private DispatcherTimer ChangeImage;
        public bool DataChanged;
        private bool FullScreenEnabled;
        internal List<DataRecord> imageFiles;
        private int indx;

        public ImageGalary()
        {
            InitializeComponent();
            if (App.IsInEditMode)
                DeleteItemIcon.Visibility = Visibility.Visible;
            ImageListBar.CurrentView = new CoverFlow();
        }

        public ImageGalary(List<DataRecord> ImageFiles) : this() //,string BaseURL)
        {
            ImageListBar.CurrentView = new CoverFlow();
            if (App.IsInEditMode)
                DeleteItemIcon.Visibility = Visibility.Visible;

            imageFiles = ImageFiles;
            StartDataBinding();
        }

        private void GoPreviouse(object sender, MouseButtonEventArgs e)
        {
            if ((ImageListBar.SelectedIndex - 1) >= 0)
                ImageListBar.SelectedIndex--;
        }

        private void GoNext(object sender, MouseButtonEventArgs e)
        {
            if ((ImageListBar.SelectedIndex + 1) < ImageListBar.Children.Count)
                ImageListBar.SelectedIndex++;
        }

        private void ExitApplication(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void StartSlideShow(object sender, MouseButtonEventArgs e)
        {
            FullScreenEnabled = true;
            indx = 0;
            ImageSource imgs = Util.LoadImage(imageFiles[indx].DataFile);
            SlideImage.Source = imgs;
            GC.Collect();

            SlideShowCanvas.Visibility = Visibility.Visible;
            ChangeImage = new DispatcherTimer(new TimeSpan(0, 0, 3), DispatcherPriority.Normal, ChangeSlideImage,
                                              Dispatcher);
        }

        private void ChangeSlideImage(object sender, EventArgs e)
        {
            ChangeImage.IsEnabled = false;
            if ((indx + 1) >= imageFiles.Count)
                indx = 0;
            else
                indx++;

            ImageSource imgs = Util.LoadImage(imageFiles[indx].DataFile);
            SlideImage.Source = imgs;
            GC.Collect();
            ChangeImage.IsEnabled = true;
        }

        private void StopFullScreenMode(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape & FullScreenEnabled)
            {
                if (ChangeImage != null)
                    ChangeImage.IsEnabled = false;
                FullScreenEnabled = false;
                SlideShowCanvas.Visibility = Visibility.Collapsed;
                return;
            }
            switch (e.Key)
            {
                case Key.Right:
                    GoNext(null, null);
                    break;
                case Key.Left:
                    GoPreviouse(null, null);
                    break;
            }
        }

        private void ShowSelectedFull(object sender, MouseButtonEventArgs e)
        {
            int cindx = ImageListBar.SelectedIndex;
            if ((cindx >= -1) && cindx <= (imageFiles.Count - 1))
            {
                FullScreenEnabled = true;
                SlideShowCanvas.Visibility = Visibility.Visible;
                ImageSource imgs = Util.LoadImage(imageFiles[cindx].DataFile);
                SlideImage.Source = imgs;
                GC.Collect();
            }
        }

        private void DeleteCurrentItem(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult dResult = MessageBox.Show("Are you sure you want to delete the selected item",
                                                       "Delete Item",
                                                       MessageBoxButton.OKCancel);
            if (dResult == MessageBoxResult.OK)
            {
                App.ActiveDatabase.DatabaseEntities.DeleteObject(imageFiles[indx]);
                if (App.ActiveDatabase.DatabaseEntities.SaveChanges() > 0)
                {
                    Util.DeleteFile(imageFiles[indx].DataFile);
                    ImageListBar.Children.RemoveAt(ImageListBar.SelectedIndex);
                    imageFiles.RemoveAt(indx);
                    DataChanged = true;
                }

                if (imageFiles.Count == 0)
                    Close();
            }
        }

        private void StartDataBinding()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Background, new NoArgdelg(FillImageList));
        }

        private void FillImageList()
        {
            ImageListBar.SelectedIndex = 0;
            foreach (DataRecord file in imageFiles)
            {
                ImageSource imgs = Util.LoadImage(file.DataFile);
                Image img = new Image();
                img.Source = imgs;
                img.Stretch = Stretch.Fill;
                img.Width = 640;
                img.Height = 360;
                img.Tag = file;
                ImageListBar.Children.Add(img);
                ImageListBar.InvalidateVisual();

                Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Background, new NoArgdelg(delegate { }));
            }
        }

        #region Nested type: NoArgdelg

        private delegate void NoArgdelg();

        #endregion
    }
}