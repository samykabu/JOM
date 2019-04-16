using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfZommPanCanvas
{
    public class ZPCanvas : Canvas
    {
        #region Delegates

        public delegate void OnPosChange(double x, double y, double ZoomFactor);

        #endregion

        public static readonly DependencyProperty CurrentXProperty =
            DependencyProperty.Register("CurrentX", typeof (double), typeof (ZPCanvas), new UIPropertyMetadata(0.0));

        public static readonly DependencyProperty CurrentYProperty =
            DependencyProperty.Register("CurrentY", typeof (double), typeof (ZPCanvas), new UIPropertyMetadata(0.0));

        public static readonly DependencyProperty FullCanvasSizeProperty =
            DependencyProperty.Register("FullCanvasSize", typeof (Size), typeof (ZPCanvas),
                                        new UIPropertyMetadata(new Size(3890, 6717)));

        public static readonly DependencyProperty IsFreezedProperty =
            DependencyProperty.Register("IsFreezed", typeof (bool), typeof (ZPCanvas), new UIPropertyMetadata(false));

        public static readonly DependencyProperty TPointProperty =
            DependencyProperty.Register("TPoint", typeof (Point), typeof (ZPCanvas),
                                        new UIPropertyMetadata(new Point(0, 0)));

        public static readonly DependencyProperty ViewBoxHightProperty =
            DependencyProperty.Register("ViewBoxHight", typeof (double), typeof (ZPCanvas),
                                        new UIPropertyMetadata(465.0));

        public static readonly DependencyProperty ViewBoxWidthProperty =
            DependencyProperty.Register("ViewBoxWidth", typeof (double), typeof (ZPCanvas),
                                        new UIPropertyMetadata(668.0));

        public static readonly DependencyProperty ZoomLevelProperty =
            DependencyProperty.Register("ZoomLevel", typeof (double), typeof (ZPCanvas), new UIPropertyMetadata(1.0));

        private double bottom;

        public Canvas ContainerCanv = new Canvas();
        public Canvas HolderCanvas = new Canvas();
        private double left;

        private bool mbMouseDown;
        private bool modifyLeftOffset, modifyTopOffset;
        private Point mpBegin;

        private double right;
        private double top;
        private double xorg, yorg;

        static ZPCanvas()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (ZPCanvas), new FrameworkPropertyMetadata(typeof (ZPCanvas)));
        }

        public ZPCanvas():base()
        {
            this.SnapsToDevicePixels = false;
            SetZoom(ZoomLevel);
        }

        public bool IsFreezed
        {
            get { return (bool) GetValue(IsFreezedProperty); }
            set { SetValue(IsFreezedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsFreezed.  This enables animation, styling, binding, etc...


        // Dependancy Property for Description
        public double ViewBoxWidth
        {
            get { return (double) GetValue(ViewBoxWidthProperty); }
            set { SetValue(ViewBoxWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewBoxWidth.  This enables animation, styling, binding, etc...

        // Dependancy Property for Zoom Factor
        public double ZoomLevel
        {
            get { return (double) GetValue(ZoomLevelProperty); }
            set { SetValue(ZoomLevelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ZoomLevel.  This enables animation, styling, binding, etc...

        // Dependancy Property for Description
        public double ViewBoxHight
        {
            get { return (double) GetValue(ViewBoxHightProperty); }
            set { SetValue(ViewBoxHightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewBoxHight.  This enables animation, styling, binding, etc...


        // Dependancy Property for Description
        public Size FullCanvasSize
        {
            get { return (Size) GetValue(FullCanvasSizeProperty); }
            set { SetValue(FullCanvasSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FullCanvasSize.  This enables animation, styling, binding, etc...

        // Dependancy Property for Description
        public double CurrentX
        {
            get { return (double) GetValue(CurrentXProperty); }
            set { SetValue(CurrentXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentX.  This enables animation, styling, binding, etc...

        public double CurrentY
        {
            get { return (double) GetValue(CurrentYProperty); }
            set { SetValue(CurrentYProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentX.  This enables animation, styling, binding, etc...


        public Point TPoint
        {
            get { return (Point) GetValue(TPointProperty); }
            set { SetValue(TPointProperty, value); }
        }

        public new UIElementCollection Children
        {
            get { return ContainerCanv.Children; }
        }

        public event OnPosChange PosChanged;

        // Using a DependencyProperty as the backing store for TPoint.  This enables animation, styling, binding, etc...


        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            HolderCanvas.Children.Add(ContainerCanv);
            base.Children.Add(HolderCanvas);
        }

        public void SetPan(double X, double Y)
        {
            xorg = 0;
            yorg = 0;
            Pan(-X, -Y);
        }

        public void SetZoom(double Zlevel)
        {
            
            if (Zlevel > 2.0)
                ZoomLevel = 2.0;
            else ZoomLevel = Zlevel <= .2 ? .2 : Zlevel;

            System.Diagnostics.Debug.WriteLine("Zoom="+ZoomLevel.ToString());

            var st = new ScaleTransform(ZoomLevel, ZoomLevel);
            ContainerCanv.LayoutTransform = st;


            left = GetLeft(ContainerCanv);
            right = GetRight(ContainerCanv);
            top = GetTop(ContainerCanv);
            bottom = GetBottom(ContainerCanv);
            xorg = ResolveOffset(left, right, out modifyLeftOffset);
            yorg = ResolveOffset(top, bottom, out modifyTopOffset);

            if (Math.Abs(xorg) >= Math.Abs(FullCanvasSize.Width - ViewBoxWidth - (1 - ZoomLevel)*343*10))
                SetLeft(ContainerCanv, -(FullCanvasSize.Width - ViewBoxWidth - (1 - ZoomLevel)*343*10));

            if (Math.Abs(yorg) >= Math.Abs(FullCanvasSize.Height - ViewBoxHight - (1 - ZoomLevel)*538*10))
                SetTop(ContainerCanv, -(FullCanvasSize.Height - ViewBoxHight - (1 - ZoomLevel)*538*10));


            left = GetLeft(ContainerCanv);
            right = GetRight(ContainerCanv);
            top = GetTop(ContainerCanv);
            bottom = GetBottom(ContainerCanv);
            xorg = ResolveOffset(left, right, out modifyLeftOffset);
            yorg = ResolveOffset(top, bottom, out modifyTopOffset);
            SetValue(CurrentXProperty, -xorg);
            SetValue(CurrentYProperty, -yorg);
            SetValue(TPointProperty, new Point(CurrentX, CurrentY));
            
            InvalidateVisual();
            
            if (PosChanged != null)
                PosChanged(-xorg, -yorg, ZoomLevel);
            
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            if (!IsFreezed)
            {
                if (e.Delta > 0)
                {
                    ZoomLevel *= 1.05;              
                }
                else
                {
                    ZoomLevel *= .95;                  
                }
                SetZoom(ZoomLevel);
            }
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            if (!IsFreezed && mbMouseDown && mpBegin != e.GetPosition(this))
            {
                Point bNew = e.GetPosition(this);
                Pan(bNew.X - mpBegin.X, bNew.Y - mpBegin.Y);
                e.Handled = true;
            }
            mbMouseDown = false;
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            if (!IsFreezed)
            {
                mbMouseDown = true;
                mpBegin = e.GetPosition(this);
                left = GetLeft(ContainerCanv);
                right = GetRight(ContainerCanv);
                top = GetTop(ContainerCanv);
                bottom = GetBottom(ContainerCanv);
                xorg = ResolveOffset(left, right, out modifyLeftOffset);
                yorg = ResolveOffset(top, bottom, out modifyTopOffset);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            {
                if (!IsFreezed && mbMouseDown)
                {
                    Point bNew = e.GetPosition(this);
                    Pan(bNew.X - mpBegin.X, bNew.Y - mpBegin.Y);
                    e.Handled = true;
                }
            }
        }

        protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        {
            if (!IsFreezed)
            {
                if (mbMouseDown && mpBegin != e.GetPosition(this))
                {
                    Point bNew = e.GetPosition(this);
                    Pan(bNew.X - mpBegin.X, bNew.Y - mpBegin.Y);
                    e.Handled = true;
                }
                mbMouseDown = false;
            }
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            if (!IsFreezed)
            {
                if (mbMouseDown && mpBegin != e.GetPosition(this))
                {
                    e.Handled = true;
                }
                mbMouseDown = false;
            }
        }


        protected void Pan(double xOff, double yOff)
        {
            double newHorizontalOffset, newVerticalOffset;


            if (modifyLeftOffset)
                newHorizontalOffset = xorg + xOff;
            else
                newHorizontalOffset = xorg - xOff;

            if (modifyTopOffset)
                newVerticalOffset = yorg + yOff;
            else
                newVerticalOffset = yorg - yOff;

            if (newHorizontalOffset <= 0 &&
                Math.Abs(newHorizontalOffset) <= Math.Abs(FullCanvasSize.Width - ViewBoxWidth - (1 - ZoomLevel)*343*10))
            {
                if (modifyLeftOffset)
                    SetLeft(ContainerCanv, newHorizontalOffset);
                else
                    SetRight(ContainerCanv, newHorizontalOffset);
            }

            if (newVerticalOffset <= 0 &&
                Math.Abs(newVerticalOffset) <= Math.Abs(FullCanvasSize.Height - ViewBoxHight - (1 - ZoomLevel)*538*10))
            {
                if (modifyTopOffset)
                    SetTop(ContainerCanv, newVerticalOffset);
                else
                    SetBottom(ContainerCanv, newVerticalOffset);
            }

            double cleft;
            double cright;
            double ctop;
            double cbottom;
            double cxorg, cyorg;
            cleft = GetLeft(ContainerCanv);
            cright = GetRight(ContainerCanv);
            ctop = GetTop(ContainerCanv);
            cbottom = GetBottom(ContainerCanv);
            cxorg = ResolveOffset(cleft, cright, out modifyLeftOffset);
            cyorg = ResolveOffset(ctop, cbottom, out modifyTopOffset);
            SetValue(CurrentXProperty, -cxorg);
            SetValue(CurrentYProperty, -cyorg);
            SetValue(TPointProperty, new Point(CurrentX, CurrentY));

            System.Diagnostics.Debug.WriteLine("Translate=" + TPoint.ToString());

            InvalidateVisual();

            if (PosChanged != null)
                PosChanged(-cxorg, -cyorg, ZoomLevel);
        }

        private static double ResolveOffset(double side1, double side2, out bool useSide1)
        {
            useSide1 = true;
            double result;
            if (Double.IsNaN(side1))
            {
                if (Double.IsNaN(side2))
                {
                    result = 0;
                }
                else
                {
                    result = side2;
                    useSide1 = false;
                }
            }
            else
            {
                result = side1;
            }
            return result;
        }
    }
}