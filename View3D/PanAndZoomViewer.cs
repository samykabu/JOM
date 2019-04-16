namespace View3D
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;

    public class PanAndZoomViewer : ContentControl
    {
        public double DefaultZoomFactor
        {
            get { return (double) GetValue(DefaultZoomFactorProperty); }
            set { SetValue(DefaultZoomFactorProperty, value); }
        }

        public static readonly DependencyProperty DefaultZoomFactorProperty =
            DependencyProperty.Register("DefaultZoomFactor", typeof (double), typeof (PanAndZoomViewer), new UIPropertyMetadata(1.4));

        public static readonly DependencyProperty IsFreezedProperty =
            DependencyProperty.Register("IsFreezed", typeof(bool), typeof(PanAndZoomViewer), new UIPropertyMetadata(true));

        public bool IsFreezed
        {
            get { return (bool)GetValue(IsFreezedProperty); }
            set { SetValue(IsFreezedProperty, value); }
        }

        private FrameworkElement source;
        private Point ScreenStartPoint = new Point(0, 0);
        private TranslateTransform translateTransform;
        private ScaleTransform zoomTransform;
        private TransformGroup transformGroup;
        private Point startOffset;
        private bool isSetup = false;

        public delegate void ZoomChangedDlg(double ZoomLevel);
        public event ZoomChangedDlg OnZoomChanged;

        public PanAndZoomViewer()
        {
            this.DefaultZoomFactor = 1.4;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Setup(this);
        }

        void Setup(FrameworkElement control)
        {
            isSetup = true;
            this.source = VisualTreeHelper.GetChild(this, 0) as FrameworkElement;

            this.translateTransform = new TranslateTransform();
            this.zoomTransform = new ScaleTransform();
            this.transformGroup = new TransformGroup();
            this.transformGroup.Children.Add(this.zoomTransform);
            this.transformGroup.Children.Add(this.translateTransform);
            this.source.RenderTransform = this.transformGroup;
            this.Focusable = true;
            this.KeyDown += new KeyEventHandler(source_KeyDown);
            //this.MouseMove += new MouseEventHandler(control_MouseMove);
            //this.MouseDown += new MouseButtonEventHandler(source_MouseDown);
            //this.MouseUp += new MouseButtonEventHandler(source_MouseUp);
            this.MouseWheel += new MouseWheelEventHandler(source_MouseWheel);
        }

        void source_KeyDown(object sender, KeyEventArgs e)
        {
            // hit escape to reset everything
            if (e.Key==Key.Escape) Reset();
        }

        void source_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            // zoom into the content.  Calculate the zoom factor based on the direction of the mouse wheel.
            double zoomFactor = this.DefaultZoomFactor;
            if (e.Delta <= 0) zoomFactor = 1.0 / this.DefaultZoomFactor;
            // DoZoom requires both the logical and physical location of the mouse pointer            
            var physicalPoint = e.GetPosition(this);            
            DoZoom( zoomFactor, this.transformGroup.Inverse.Transform(physicalPoint),physicalPoint);
            RaisZoomChanged(zoomFactor);

        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            if (!IsFreezed && this.IsMouseCaptured)
            {
                // we're done.  reset the cursor and release the mouse pointer
                this.Cursor = Cursors.Arrow;
                this.ReleaseMouseCapture();
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            // Save starting point, used later when determining how much to scroll.
            if (!IsFreezed)
            {
                this.ScreenStartPoint = e.GetPosition(this);

                this.startOffset = new Point(this.translateTransform.X, this.translateTransform.Y);
                this.CaptureMouse();
                this.Cursor = Cursors.ScrollAll;
            }

        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!IsFreezed  && this.IsMouseCaptured)
            {
                // if the mouse is captured then move the content by changing the translate transform.  
                // use the Pan Animation to animate to the new location based on the delta between the 
                // starting point of the mouse and the current point.
                var physicalPoint = e.GetPosition(this);
                this.translateTransform.BeginAnimation(TranslateTransform.XProperty, CreatePanAnimation(physicalPoint.X - this.ScreenStartPoint.X + this.startOffset.X));
                this.translateTransform.BeginAnimation(TranslateTransform.YProperty, CreatePanAnimation(physicalPoint.Y - this.ScreenStartPoint.Y + this.startOffset.Y));
            }
        }


        /// <summary>Helper to create the panning animation for x,y coordinates.</summary>
        /// <param name="toValue">New value of the coordinate.</param>
        /// <returns>Double animation</returns>
        private DoubleAnimation CreatePanAnimation(double toValue)
        {
            var da = new DoubleAnimation(toValue, new Duration(TimeSpan.FromMilliseconds(300)));
            da.AccelerationRatio = 0.1;
            da.DecelerationRatio = 0.9;
            da.FillBehavior = FillBehavior.HoldEnd;
            da.Freeze();
            return da;
        }


        /// <summary>Helper to create the zoom double animation for scaling.</summary>
        /// <param name="toValue">Value to animate to.</param>
        /// <returns>Double animation.</returns>
        private DoubleAnimation CreateZoomAnimation(double toValue)
        {
            var da = new DoubleAnimation(toValue, new Duration(TimeSpan.FromMilliseconds(500)));
            da.AccelerationRatio = 0.1;
            da.DecelerationRatio = 0.9;
            da.FillBehavior = FillBehavior.HoldEnd;
            da.Freeze();
            return da;
        }

        private void RaisZoomChanged(double ZValue)
        {
            if (OnZoomChanged!=null)
                OnZoomChanged(ZValue);
        }
        /// <summary>Zoom into or out of the content.</summary>
        /// <param name="deltaZoom">Factor to mutliply the zoom level by. </param>
        /// <param name="mousePosition">Logical mouse position relative to the original content.</param>
        /// <param name="physicalPosition">Actual mouse position on the screen (relative to the parent window)</param>
        public void DoZoom(double deltaZoom, Point mousePosition, Point physicalPosition)
        {
            if (isSetup)
            {
                double currentZoom = this.zoomTransform.ScaleX;
                currentZoom *= deltaZoom;
                if (currentZoom < 1.0)
                {
                    currentZoom = 1.0;
                    RaisZoomChanged(currentZoom);
                }
                if (currentZoom > 3.0)
                {
                    currentZoom = 3.0;
                    RaisZoomChanged(currentZoom);
                }

                this.translateTransform.BeginAnimation(TranslateTransform.XProperty,
                                                       CreateZoomAnimation(-1*
                                                                           (mousePosition.X*currentZoom -
                                                                            physicalPosition.X)));
                this.translateTransform.BeginAnimation(TranslateTransform.YProperty,
                                                       CreateZoomAnimation(-1*
                                                                           (mousePosition.Y*currentZoom -
                                                                            physicalPosition.Y)));
                this.zoomTransform.BeginAnimation(ScaleTransform.ScaleXProperty, CreateZoomAnimation(currentZoom));
                this.zoomTransform.BeginAnimation(ScaleTransform.ScaleYProperty, CreateZoomAnimation(currentZoom));
            }
        }
        public void DoZoom(double deltaZoom)
        {
            if (isSetup)
            {
                double currentZoom = deltaZoom;               
                this.zoomTransform.BeginAnimation(ScaleTransform.ScaleXProperty, CreateZoomAnimation(currentZoom));
                this.zoomTransform.BeginAnimation(ScaleTransform.ScaleYProperty, CreateZoomAnimation(currentZoom));
            }
        }
        /// <summary>Reset to default zoom level and centered content.</summary>
        public void Reset()
        {
            this.translateTransform.BeginAnimation(TranslateTransform.XProperty, CreateZoomAnimation(0));
            this.translateTransform.BeginAnimation(TranslateTransform.YProperty, CreateZoomAnimation(0));
            this.zoomTransform.BeginAnimation(ScaleTransform.ScaleXProperty, CreateZoomAnimation(1));
            this.zoomTransform.BeginAnimation(ScaleTransform.ScaleYProperty, CreateZoomAnimation(1));
        }
    }
}

