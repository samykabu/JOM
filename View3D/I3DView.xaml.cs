using System;
using System.IO;
using System.Net.Cache;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using MouseGestures;
using MouseGesture = MouseGestures.MouseGesture;

namespace View3D
{
    /// <summary>
    /// Interaction logic for I3DView.xaml
    /// </summary>
    public partial class I3DView : UserControl
    {
        public static readonly DependencyProperty ViewFolderProperty =
            DependencyProperty.Register("ViewFolder", typeof(string), typeof(I3DView),
                                        new UIPropertyMetadata("", OnUriChanged));

        public ImageSource FirstFrameImage
        {
            get { return (ImageSource)GetValue(FirstFrameImageProperty); }
            set { SetValue(FirstFrameImageProperty, value); }
        }

        public static readonly DependencyProperty FirstFrameImageProperty =
            DependencyProperty.Register("FirstFrameImage", typeof(ImageSource), typeof(I3DView), new UIPropertyMetadata(null));

        private Point DownPosition;
        //private TimeSpan Elapsedtime;
        private long exetime;
        private string[,] ImagesList;
        private int indx;
        private int indy;
        private MouseGestures.MouseGestures mouseGesturesTest;
        private bool MouseisDown;
        private bool paused = true;
        private DispatcherTimer UpdateImage;
        private int xmov = 1;
        private int ymov;

        public I3DView()
        {
            InitializeComponent();
        }

        public string ViewFolder
        {
            get { return (string)GetValue(ViewFolderProperty); }
            set { SetValue(ViewFolderProperty, value); }
        }

        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        private static void OnUriChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var curView = (I3DView)d;
            curView.IntializeContent((string)e.NewValue);
        }

        internal void IntializeContent(string FolderPath)
        {
           
            var reader = new ImageGridReader(FolderPath);
            if (reader.Validate3Dfolder(16))
            {
                ImagesList = reader._Images;
                InitializeComponent();
                mouseGesturesTest = new MouseGestures.MouseGestures(true);
                mouseGesturesTest.Gesture += mouseGesturesTest_Gesture;

                BitmapImage image = LoadImage(ImagesList[0, 0]);

                FirstFrameImage = image;
                Animated3DView.Source = image;
                exetime = DateTime.Now.Ticks;
                UpdateImage = new DispatcherTimer(DispatcherPriority.Render);
                UpdateImage.Interval = TimeSpan.FromMilliseconds(200.0);
                UpdateImage.Tick += UpdateImage_Tick;
                UpdateImage.IsEnabled = true;
            }
           
        }

        public static BitmapImage LoadImage(string ImageFile)
        {
            byte[] buffer = File.ReadAllBytes(ImageFile);
            MemoryStream ms = new MemoryStream(buffer);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = ms;
            image.EndInit();
            image.Freeze();
            return image;
        }

        private void mouseGesturesTest_Gesture(object sender, MouseGestureEventArgs e)
        {
            switch (e.Gesture)
            {
                case MouseGesture.UpRight:
                    xmov = 1;
                    ymov = -1;
                    break;

                case MouseGesture.Down:
                    xmov = 0;
                    ymov = 1;
                    break;

                case MouseGesture.Up:
                    xmov = 0;
                    ymov = -1;
                    break;

                case MouseGesture.Right:
                    xmov = 1;
                    ymov = 0;
                    break;

                case MouseGesture.DownRight:
                    xmov = 1;
                    ymov = 1;
                    break;

                case MouseGesture.Left:
                    xmov = -1;
                    ymov = 0;
                    break;

                case MouseGesture.UpLeft:
                    xmov = -1;
                    ymov = -1;
                    break;

                case MouseGesture.DownLeft:
                    xmov = -1;
                    ymov = 1;
                    break;
            }
        }

        private void UpdateImage_Tick(object sender, EventArgs e)
        {
            UpdateImage.IsEnabled = false;

            if (!paused)
            {
                indx += xmov;
            }

            if (indx >= ImagesList.GetLength(1))
            {
                indx = 0;
            }
            if (indx < 0)
            {
                indx = ImagesList.GetLength(1) - 1;
            }
            if (indy >= ImagesList.GetLength(0))
            {
                indy = ImagesList.GetLength(0) - 1;
            }
            if (indy < 0)
            {
                indy = 0;
            }
            if (ImagesList[indy, indx] != null)
            {
                var decoder = new JpegBitmapDecoder(new Uri(ImagesList[indy, indx], UriKind.Absolute),
                                                    BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                ImageSource source = decoder.Frames[0];
                Animated3DView.Source = source;
                Animated3DView.InvalidateVisual();

                decoder = null;
                source = null;
            }
            //GC.Collect();
            Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Background, new NoArgdelg(delegate { }));
            UpdateImage.IsEnabled = true;
        }
        private delegate void NoArgdelg();
        private void AnimatedImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DownPosition = e.MouseDevice.GetPosition(Animated3DView);
            MouseisDown = true;
            xmov = 0;
            ymov = 0;
        }

        private void AnimatedImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseisDown && ((DateTime.Now.Ticks - exetime) > TimeSpan.FromSeconds(0.1).Ticks))
            {
                Point position = e.MouseDevice.GetPosition(Animated3DView);
                double num = position.X - DownPosition.X;
                double num2 = position.Y - DownPosition.Y;
                if (Math.Abs(num) > Math.Abs(num2))
                {
                    if (num > 0.0)
                    {
                        xmov = -1;
                    }
                    else
                    {
                        xmov = 1;
                    }
                }
                else if (num2 > 0.0)
                {
                    ymov = 1;
                }
                else
                {
                    ymov = -1;
                }
                if (!paused)
                {
                    paused = true;
                }
                indx += xmov;
                indy += ymov;
                exetime = DateTime.Now.Ticks;
            }
            DownPosition = e.MouseDevice.GetPosition(Animated3DView);
        }

        private void AnimatedImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseisDown = false;
        }

        public void Stop()
        {
            paused = true;
            xmov = 1;
        }
        public void Play()
        {
            paused = false;
            xmov = 1;
        }
        public void Reset()
        {
            PanZoomView.Reset();
        }

        private void MoveDown(object sender, MouseButtonEventArgs e)
        {
            indy += 1;
        }

        private void MoveUP(object sender, MouseButtonEventArgs e)
        {
            indy -= 1;
        }

        private void MoveRight(object sender, MouseButtonEventArgs e)
        {
            indx += 1;
        }

        private void MoveLeft(object sender, MouseButtonEventArgs e)
        {
            indx -= 1;
        }

        private void ResetView(object sender, MouseButtonEventArgs e)
        {
            this.Reset();
        }
        //private void SetSlider(double val)
        //{
        //    slider1.Value = val;
        //}
        //private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    PanZoomView.DoZoom(((Slider)sender).Value);
        //}
    }
}