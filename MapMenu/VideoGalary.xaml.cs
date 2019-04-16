#region System Refrences

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

#endregion

namespace MapMenu
{
    /// <summary>
    /// Interaction logic for VideoGalary.xaml
    /// </summary>
    public partial class VideoGalary : Window
    {
        //private readonly DispatcherTimer ShowVideoPlayerTimer;
        public bool DataChanged;
        private bool FullScreenEnabled;
        //private int indx;
        internal List<DataRecord> VideoFiles;
        private bool videoPlay;

        public VideoGalary()
        {
            InitializeComponent();
            if (App.IsInEditMode)
                DeleteItemIcon.Visibility = Visibility.Visible;
            //ShowVideoPlayerTimer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, ShowVideoPlayer,
            //Dispatcher);
            //ShowVideoPlayerTimer.IsEnabled = false;
        }

        public VideoGalary(List<DataRecord> videoFiles, string HeadrTitleImage) //,string BaseURL)
        {
            InitializeComponent();

            //TODO: Validate that the english name get parsed correctly [VideoGalary].
            TitleImage.EnImage = null;
            TitleImage.AraImage = Util.LoadImage(("/Images/" + HeadrTitleImage), UriKind.Relative);


            if (App.IsInEditMode)
                DeleteItemIcon.Visibility = Visibility.Visible;

            VideoFiles = videoFiles;

            foreach (DataRecord file in videoFiles)
            {
                ImageSource imgs = Util.LoadImage(file.DataFile);
                Image img = new Image();
                img.Source = imgs;
                img.Stretch = Stretch.Fill;
                img.Width = 640;
                img.Height = 360;
                img.Tag = file;
                ImageListBar.Children.Add(img);
            }
            ImageListBar.SelectedIndex = 0;
            VideoPlayElmFull.MediaEnded += VideoPlayElmFull_MediaEnded;
            //ShowVideoPlayerTimer = new DispatcherTimer(new TimeSpan(0, 0, 2), DispatcherPriority.Normal, ShowVideoPlayer, Dispatcher);
            //ShowVideoPlayerTimer.IsEnabled = true;
        }

        private void VideoPlayElmFull_MediaEnded(object sender, RoutedEventArgs e)
        {
            VideoPlayElmFull.Stop();
            videoPlay = false;
        }

        private void GoPreviouse(object sender, MouseButtonEventArgs e)
        {
            //VideoPlayerCanvas.Visibility = Visibility.Collapsed;
            //SlideShowCanvas.Visibility = Visibility.Collapsed;
            VideoPlayElmFull.Source = null;
            if (ImageListBar.SelectedIndex - 1 >= 0)
                ImageListBar.SelectedIndex--;
            //ShowVideoPlayerTimer.IsEnabled = false;
            //ShowVideoPlayerTimer.IsEnabled = true;
        }

        private void GoNext(object sender, MouseButtonEventArgs e)
        {
            //VideoPlayerCanvas.Visibility = Visibility.Collapsed;
            //SlideShowCanvas.Visibility = Visibility.Collapsed;
            VideoPlayElmFull.Source = null;
            if (ImageListBar.SelectedIndex + 1 < ImageListBar.Children.Count)
                ImageListBar.SelectedIndex++;

            //ShowVideoPlayerTimer.IsEnabled = false;
            //ShowVideoPlayerTimer.IsEnabled = true;
        }

        private void ExitApplication(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void ShowVideoPlayer(object sender, EventArgs e)
        {
            //ShowVideoPlayerTimer.IsEnabled = false;


            int cindx = ImageListBar.SelectedIndex;
            VideoPlayerCanvas.Visibility = Visibility.Visible;
            SlideShowCanvas.Visibility = Visibility.Visible;
            VideoPlayElmFull.Source = new Uri(VideoFiles[cindx].ThumbnailFile);
            VideoPlayElmFull.Play();
            videoPlay = true;
            GC.Collect();
        }

        private void StartSlideShow(object sender, MouseButtonEventArgs e)
        {
            FullScreenEnabled = true;
            VideoPlayElmFull.Width = 1280;
            VideoPlayElmFull.Height = 720;
            if (!videoPlay)
            {
                VideoPlayElmFull.Source = new Uri(VideoFiles[ImageListBar.SelectedIndex].ThumbnailFile);
                SlideShowCanvas.Visibility = Visibility.Visible;
                VideoPlayElmFull.Play();
                videoPlay = true;
            }
            else
            {
                VideoPlayElmFull.Play();
            }
            Canvas.SetTop(VideoPlayElmFull, 0);
            Canvas.SetLeft(VideoPlayElmFull, 0);
            GC.Collect();
        }


        private void StopFullScreenMode(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape & FullScreenEnabled)
            {
                // Height="370" Width="645" Canvas.Left="315" Canvas.Top="156"
                VideoPlayElmFull.Width = 645;
                VideoPlayElmFull.Height = 370;
                Canvas.SetTop(VideoPlayElmFull, 156);
                Canvas.SetLeft(VideoPlayElmFull, 315);
                FullScreenEnabled = false;
                //SlideShowCanvas.Visibility = Visibility.Collapsed;
                e.Handled = true;
            }
        }

        private void DeleteCurrentItem(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult dResult = MessageBox.Show("Are you sure you want to delete the selected item",
                                                       "Delete Item",
                                                       MessageBoxButton.OKCancel);
            if (dResult == MessageBoxResult.OK)
            {
                int cindx = ImageListBar.SelectedIndex;
                VideoPlayElmFull.Stop();
                videoPlay = false;

                App.ActiveDatabase.DatabaseEntities.DeleteObject(VideoFiles[cindx]);
                if (App.ActiveDatabase.DatabaseEntities.SaveChanges() > 0)
                {
                    Util.DeleteFile(VideoFiles[cindx].DataFile);
                    Util.DeleteFile(VideoFiles[cindx].ThumbnailFile);

                    VideoFiles.RemoveAt(cindx);
                    DataChanged = true;
                    GC.Collect();
                }


                ImageListBar.Children.RemoveAt(ImageListBar.SelectedIndex);

                if (ImageListBar.SelectedIndex - 1 < 0 && ImageListBar.Children.Count == 0)
                {
                    Close();
                }
                else
                {
                    ImageListBar.SelectedIndex = 0;
                }
            }
        }

        private void ImageListBar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //VideoPlayerCanvas.Visibility = Visibility.Collapsed;
            if (videoPlay)
            {
                VideoPlayElmFull.Stop();
                SlideShowCanvas.Visibility = Visibility.Collapsed;
                videoPlay = false;
            }

            //ShowVideoPlayerTimer.IsEnabled = false;
            //ShowVideoPlayerTimer.IsEnabled = true;
        }

        private void PlayOrPause(object sender, MouseButtonEventArgs e)
        {
            if (!videoPlay)
            {
                VideoPlayElmFull.Source = new Uri(VideoFiles[ImageListBar.SelectedIndex].ThumbnailFile);
                VideoPlayElmFull.Play();
                SlideShowCanvas.Visibility = Visibility.Visible;
                videoPlay = true;
            }
        }

        private void StopPlay(object sender, MouseButtonEventArgs e)
        {
            if (videoPlay)
            {
                VideoPlayElmFull.Stop();
                SlideShowCanvas.Visibility = Visibility.Collapsed;
                videoPlay = false;
            }
        }
    }
}