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
    /// Interaction logic for ImageGalary.xaml
    /// </summary>
    public partial class ImageGalaryPageView : Window
    {
        public bool DataChanged;
        internal List<DataRecord> imageFiles;
        private int indx;

        public ImageGalaryPageView()
        {
            InitializeComponent();
            if (App.IsInEditMode)
                DeleteItemIcon.Visibility = Visibility.Visible;
        }

        public ImageGalaryPageView(List<DataRecord> ImageFiles, string HeadrTitleImage) //,string BaseURL)
        {
            InitializeComponent();

            //TODO: Validate that the english name get parsed correctly [ImageGalaryPageView].
            TitleImage.EnImage = null;
            TitleImage.AraImage = Util.LoadImage(("/Images/" + HeadrTitleImage), UriKind.Relative);
            //TitleImage.EnImage = Util.LoadImage(("/Images/" + HeadrTitleImage.Replace(".","EN.")), UriKind.Relative);

            TitleImage.Width = 1280;
            TitleImage.Height = 108;
            if (ImageFiles.Count == 0)
                return;

            if (App.IsInEditMode)
                DeleteItemIcon.Visibility = Visibility.Visible;

            imageFiles = ImageFiles;

            Image img = new Image();
            ImageSource imgsrc = Util.LoadImage(imageFiles[indx].DataFile);
            img.Source = imgsrc;
            img.Stretch = Stretch.Fill;
            img.Width = 1164;
            img.Height = 480;
            PageView.Children.Add(img);
            ImageTitle.Content = imageFiles[indx].Title;
            ImageNumber.Content = "1/" + imageFiles.Count;

            if (imageFiles.Count > 1)
                NextImage.Visibility = Visibility.Visible;
        }


        private void ExitApplication(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
         
            Close();
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
                    if (imageFiles[indx] != null)
                        imageFiles.RemoveAt(indx);
                    DataChanged = true;
                }

                if (imageFiles.Count > 0)
                {
                    indx = 0;
                    showimage();
                }
                else
                {
                    Close();
                }
            }
        }

        private void showimage()
        {
            PageView.Children.Clear();
            Image img = new Image();
            ImageSource imgsrc = Util.LoadImage(imageFiles[indx].DataFile);
            img.Source = imgsrc;
            img.Stretch = Stretch.Fill;
            img.Width = 1164;
            img.Height = 480;
            PageView.Children.Add(img);
            ImageTitle.Content = imageFiles[indx].Title;
        }

        private void GoPreviouse(object sender, MouseButtonEventArgs e)
        {
            if (imageFiles.Count == 0)
                return;

            indx--;
            if (indx < 0)
            {
                indx = 0;
                PreviousImage.Visibility = Visibility.Collapsed;
            }
            if (imageFiles.Count > 1)
                NextImage.Visibility = Visibility.Visible;
            else
            {
                NextImage.Visibility = Visibility.Collapsed;
            }

            ImageNumber.Content = (indx + 1) + "/" + imageFiles.Count;
            showimage();
        }

        private void GoNext(object sender, MouseButtonEventArgs e)
        {
            if (imageFiles.Count == 0)
                return;

            indx++;
            if (indx >= imageFiles.Count)
            {
                indx = imageFiles.Count - 1;
                NextImage.Visibility = Visibility.Collapsed;
            }
            if (indx > 0)
                PreviousImage.Visibility = Visibility.Visible;

            ImageNumber.Content = (indx + 1) + "/" + imageFiles.Count;
            showimage();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    GoPreviouse(null, null);
                    break;

                case Key.Right:
                    GoNext(null, null);
                    break;
            }
        }
    }
}