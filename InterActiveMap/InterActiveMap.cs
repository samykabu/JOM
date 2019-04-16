using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace InterActiveMap
{
    public class InterActiveMap : Canvas
    {
        #region Variables

        internal Image _BackgroundImage = new Image();
        private readonly Canvas canvas2 = new Canvas();

        /// <summary>
        ///     
        /// </summary>
        /// <remarks>
        ///     
        /// </remarks>        

        private LinkedListNode<Point> DragedPoint;
        private bool DragPoint;
        //private LinkedListNode<Surface> _SelectedSurface = null;
        private bool DrawLinesandRect = true;
        private bool EditMode;
        private Point NewPos;
        private bool OldState;
        private Point p;
        private bool PolyMove;
        private Point PolyMoveMousePoint;
        private Surface sf;
        private bool ShowAllTransparent = true;
        private ZonesMap zmap;

        #endregion

        #region Delegates

        public delegate void OnMouseEnterdlg(bool Zone, object SelectedObject);

        public delegate void OnSelectionChangedDlg(bool Zone, object SelectedObject, double Zoom, Point Translation);

        #endregion

        public LinkedList<Surface> ClosedSurfaces
        {
            get { return (LinkedList<Surface>)GetValue(ClosedSurfacesProperty); }
            set { SetValue(ClosedSurfacesProperty, value); }
        }

        public static readonly DependencyProperty ClosedSurfacesProperty =
            DependencyProperty.Register("ClosedSurfaces", typeof(LinkedList<Surface>), typeof(InterActiveMap), new UIPropertyMetadata(null));

        public static readonly DependencyProperty BackgroundImageProperty =
            DependencyProperty.Register("BackgroundImage", typeof(ImageSource), typeof(InterActiveMap),
                                        new UIPropertyMetadata(null));

        public static readonly DependencyProperty CurrentSelectionDateProperty =
            DependencyProperty.Register("CurrentSelectionDate", typeof(DateTime), typeof(InterActiveMap),
                                        new UIPropertyMetadata(DateTime.Now));

        public static readonly DependencyProperty EnableEditModeProperty =
            DependencyProperty.Register("EnableEditMode", typeof(bool), typeof(InterActiveMap),
                                        new UIPropertyMetadata(true));

        public static readonly DependencyProperty IsFreezedProperty =
            DependencyProperty.Register("IsFreezed", typeof(bool), typeof(InterActiveMap),
                                        new UIPropertyMetadata(false));

        public static readonly DependencyProperty SavePathURLProperty =
            DependencyProperty.Register("SavePathURL", typeof(string), typeof(InterActiveMap),
                                        new UIPropertyMetadata(@"c:\JOM\SortedData.xml"));

        public static readonly DependencyProperty SelectedShapeProperty =
            DependencyProperty.Register
                ("SelectedShape", typeof(UIElement), typeof(InterActiveMap),
                 new PropertyMetadata(null, selectedShape_Changed));

        public static readonly DependencyProperty SelectedSurfaceProperty =
            DependencyProperty.Register("SelectedSurface", typeof(LinkedListNode<Surface>), typeof(InterActiveMap),
                                        new UIPropertyMetadata(null, new PropertyChangedCallback(selectedShape_Changed)));

        public static readonly DependencyProperty SourceXMLFileURLProperty =
            DependencyProperty.Register("SourceXMLFileURL", typeof(string), typeof(InterActiveMap),
                                        new UIPropertyMetadata(""));

        public static readonly DependencyProperty SourceXMlStringProperty =
            DependencyProperty.Register("SourceXMlString", typeof(string), typeof(InterActiveMap),
                                        new UIPropertyMetadata(""));

        public static readonly DependencyProperty TranslationFactorProperty =
            DependencyProperty.Register("TranslationFactor", typeof(Point), typeof(InterActiveMap),
                                        new UIPropertyMetadata(new Point(0.0, 0.0)));

        public static readonly DependencyProperty ZoomFactorProperty =
            DependencyProperty.Register("ZoomFactor", typeof(double), typeof(InterActiveMap),
                                        new UIPropertyMetadata(1.0));

        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(string), typeof(InterActiveMap), new UIPropertyMetadata("zones-2008-12-29.jpg", new PropertyChangedCallback(ChangeBackground)));

        public Color SelectionHighlite
        {
            get { return (Color)GetValue(SelectionHighliteProperty); }
            set { SetValue(SelectionHighliteProperty, value); }
        }

        public static readonly DependencyProperty SelectionHighliteProperty =
            DependencyProperty.Register("SelectionHighlite", typeof(Color), typeof(InterActiveMap), new UIPropertyMetadata(Colors.Yellow));

        public int SelectionThicknes
        {
            get { return (int)GetValue(SelectionThicknesProperty); }
            set { SetValue(SelectionThicknesProperty, value); }
        }

        public static readonly DependencyProperty SelectionThicknesProperty =
            DependencyProperty.Register("SelectionThicknes", typeof(int), typeof(InterActiveMap), new UIPropertyMetadata(6));
        static InterActiveMap()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InterActiveMap),
                                                     new FrameworkPropertyMetadata(typeof(InterActiveMap)));
        }

        public static void ChangeBackground(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            InterActiveMap map = (InterActiveMap)sender;
            map._BackgroundImage.Source = new BitmapImage(new Uri((string)args.NewValue, UriKind.Relative));
            map._BackgroundImage.Width = 3422;
            map._BackgroundImage.Height = 5388;
            map.InvalidateVisual();
        }

        public InterActiveMap()
        {
            MouseDown += InterActiveMap_MouseDown;
            MouseMove += InterActiveMap_MouseMove;
            MouseUp += InterActiveMap_MouseUp;
            KeyUp += InterActiveMap_KeyUp;

            _BackgroundImage.Source = new BitmapImage(new Uri(ImageSource, UriKind.Relative));
            _BackgroundImage.Width = 3422;
            _BackgroundImage.Height = 5388;
            Children.Add(_BackgroundImage);
            canvas2.Width = 3422;
            canvas2.Height = 5388;
            Children.Add(canvas2);
            SetValue(ClosedSurfacesProperty, new LinkedList<Surface>());
            SetValue(SelectedShapeProperty, canvas2);
        }

        #region Canvas Events

        private void InterActiveMap_KeyUp(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                switch (e.Key)
                {
                    case Key.Z:
                        if (EnableEditMode)
                            if (sf.Points != null && sf.Points.Count > 0)
                            {
                                sf.Points.Remove(sf.Points.Last);
                                UpdateInterface();
                            }
                        break;

                    case Key.D:
                        if (EnableEditMode)
                            if (SelectedSurface != null)
                            {
                                MessageBoxResult ir = MessageBox.Show("Do you want to delete selected Region?",
                                                                      "Region Deletetion", MessageBoxButton.YesNo);

                                if (ir == MessageBoxResult.Yes)
                                {
                                    LinkedListNode<Surface> Current = SelectedSurface.Previous;
                                    ClosedSurfaces.Remove(SelectedSurface);
                                    SelectedSurface = Current;
                                }
                            }
                        break;

                    case Key.Right: //select Next Surface
                        if (EnableEditMode)
                            if (SelectedSurface != null)
                            {
                                if (SelectedSurface.Next != null)
                                    SelectedSurface = SelectedSurface.Next;

                                else
                                    SelectedSurface = ClosedSurfaces.First;
                            }
                        break;

                    case Key.Left: // Select Previous Surface
                        if (EnableEditMode)
                            if (SelectedSurface != null)
                            {
                                if (SelectedSurface.Previous != null)
                                    SelectedSurface = SelectedSurface.Previous;

                                else
                                    SelectedSurface = ClosedSurfaces.Last;
                            }

                        break;

                    case Key.S: //Save Collection       
                        if (EnableEditMode)
                        {
                            MessageBoxResult sav = MessageBox.Show("Saving file will overwrite any previous file",
                                                                   "Save", MessageBoxButton.YesNo);

                            SaveConstructionToFile();
                        }
                        break;

                    case Key.A:
                        if (EnableEditMode)
                            if (SelectedSurface != null)
                            {
                                sf = SelectedSurface.Value;
                                ClosedSurfaces.Remove(SelectedSurface);
                                SelectedSurface = null;
                                EditMode = true;
                            }
                        break;

                    case Key.E: //Edit  Surface Properties
                        if (EnableEditMode)
                        {
                            if (SelectedSurface != null)
                            {
                                var ed = new SurfacePropertyWindow(SelectedSurface.Value, TranslationFactor, ZoomFactor);
                                ed.ShowDialog();

                                if (ed.DialogResult.HasValue && ed.DialogResult.Value)
                                {
                                    SelectedSurface.Value = ed.sf;
                                    SaveConstructionToFile();
                                }

                            }
                        }
                        break;

                    case Key.L:

                        break;
                    case Key.M: //Fill MetaData (Upload Files)

                        break;
                    case Key.N: //New Surface
                        if (EnableEditMode)
                        {
                            if (sf != null)
                            {
                                MessageBox.Show("Are you sure , discare the current surface");
                                sf = new Surface();
                            }

                            else
                            {
                                sf = new Surface();
                            }
                            SelectedSurface = null;
                            EditMode = true;

                        }
                        break;

                    case Key.U: //Discare the Current Surface And change edit mode
                        if (EnableEditMode)
                        {
                            MessageBox.Show("Are you sure , scrap the current surface");
                            sf = null;
                            EditMode = false;
                            SelectedSurface = ClosedSurfaces.First;

                        }
                        break;

                    case Key.V:
                        if (EnableEditMode)
                        {
                            DrawLinesandRect = !DrawLinesandRect;
                            UpdateInterface();
                        }
                        break;
                    case Key.P: // Data Entry
                        break;
                    case Key.T:
                        if (EnableEditMode)
                        {
                            ShowAllTransparent = !ShowAllTransparent;
                            UpdateInterface();
                        }
                        break;
                }
            }

            else
            {
                switch (e.Key)
                {
                    case Key.F1:
                        if (EnableEditMode)
                        {
                            var hp = new Help();
                            hp.ShowDialog();
                        }
                        break;
                    case Key.Enter:
                        if (SelectedSurface != null && OnSelectionChanged != null)
                        {
                            bool typ = SelectedSurface.Value.Tag is Zone;
                            OnSelectionChanged(typ, SelectedSurface.Value.Tag, ZoomFactor, TranslationFactor);
                        }
                        break;
                }
            }
        }

        private void InterActiveMap_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (IsFocused != true)
                Focus();

            if (EnableEditMode)
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    if (EditMode && sf != null)
                    {
                        p = e.MouseDevice.GetPosition(this);

                        if (!CloseSurface(p))
                            sf.Points.AddLast(p);

                        else
                        {
                            ClosedSurfaces.AddLast(sf);
                            sf = null;
                        }
                        UpdateInterface();
                    }
                    e.Handled = true;
                }
                else
                {
                    if (DragPoint)
                    {
                        ReleaseMouseCapture();
                        DragPoint = false;
                        return;
                    }
                    e.Handled = true;
                }
            }
        }

        private void InterActiveMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (EnableEditMode)
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    if (DragPoint)
                    {
                        DragedPoint.Value = e.MouseDevice.GetPosition(this);
                        UpdateInterface();
                    }
                    e.Handled = true;
                }
        }

        private void InterActiveMap_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (EnableEditMode)
            {
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    if (!EditMode)
                    {
                        Point curPoistion = e.MouseDevice.GetPosition(this);

                        foreach (Surface surface in ClosedSurfaces)
                        {
                            foreach (Point point1 in surface.Points)
                            {
                                double x = Math.Abs(point1.X - curPoistion.X);

                                double y = Math.Abs(point1.Y - curPoistion.Y);

                                if ((x <= 6) && (y <= 6))
                                {
                                    DragPoint = true;
                                    DragedPoint = GetPoint(surface, point1.X, point1.Y);
                                    CaptureMouse();
                                }
                            }
                        }
                    }

                    else
                    {
                        Point curPoistion = e.MouseDevice.GetPosition(this);

                        foreach (Point point1 in sf.Points)
                        {
                            double x = Math.Abs(point1.X - curPoistion.X);
                            double y = Math.Abs(point1.Y - curPoistion.Y);

                            if ((x <= 6) && (y <= 6))
                            {
                                DragPoint = true;
                                DragedPoint = GetPoint(sf, point1.X, point1.Y);
                                CaptureMouse();
                            }
                        }
                    }
                    e.Handled = true;
                }
            }
        }

        #endregion

        #region Polygon Events

        private void pl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!IsFreezed)
            {
                if (IsFocused != true)
                    Focus();

                if (e.ChangedButton == MouseButton.Left)
                {
                    if (!EditMode)
                    {
                        var selectedpoly = (Polygon)sender;
                        SelectedSurface = (LinkedListNode<Surface>)selectedpoly.Tag;
                        e.Handled = true;

                        if (SelectedSurface != null && OnSelectionChanged != null)
                        {
                            bool typ = SelectedSurface.Value.Tag is Zone;
                            OnSelectionChanged(typ, SelectedSurface.Value.Tag, ZoomFactor, TranslationFactor);
                        }
                    }
                }

                else
                {
                    var selectedpoly = (Polygon)sender;
                    SelectedSurface = (LinkedListNode<Surface>)selectedpoly.Tag;
                    SelectedSurface.Value.Points = new LinkedList<Point>();

                    foreach (Point point1 in selectedpoly.Points)
                    {
                        var p2 = new Point();
                        p2.X = point1.X + (NewPos.X - PolyMoveMousePoint.X);
                        p2.Y = point1.Y + (NewPos.Y - PolyMoveMousePoint.Y);
                        SelectedSurface.Value.Points.AddLast(p2);
                    }
                    DrawLinesandRect = OldState;
                    OldState = false;
                    PolyMove = false;
                    PolyMoveMousePoint = new Point();
                    NewPos = new Point();
                    UpdateInterface();
                    e.Handled = true;
                }
            }
        }

        private void pl_MouseMove(object sender, MouseEventArgs e)
        {
            if (EnableEditMode)
                if (e.RightButton == MouseButtonState.Pressed && PolyMove)
                {
                    var ppp = (Polygon)sender;
                    NewPos = e.MouseDevice.GetPosition(canvas2);
                    Transform ts = new TranslateTransform(NewPos.X - PolyMoveMousePoint.X,
                                                          NewPos.Y - PolyMoveMousePoint.Y);
                    ppp.RenderTransform = ts;
                    e.Handled = true;
                }
        }

        private void pl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (EnableEditMode)
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    OldState = DrawLinesandRect;
                    DrawLinesandRect = false;
                    PolyMove = true;
                    PolyMoveMousePoint = e.MouseDevice.GetPosition(canvas2);
                    UpdateInterface();
                    e.Handled = true;
                }
        }

        #endregion

        #region Drawing Functions

        public void UpdateInterface()
        {
            DrawShape();
            DrawClosedSarfaces();
        }

        private void DrawShape()
        {
            canvas2.Children.Clear();

            if (sf != null)
            {
                LinkedListNode<Point> p1, p2;
                p1 = sf.Points.First;

                while (p1 != null)
                {
                    if (DrawLinesandRect)
                        DrawBox(p1.Value.X, p1.Value.Y);

                    if (p1.Next != null)
                    {
                        p2 = p1;
                        p1 = p1.Next;

                        if (DrawLinesandRect)
                            DrawLine(p2.Value.X, p2.Value.Y, p1.Value.X, p1.Value.Y);
                    }

                    else
                    {
                        p1 = null;
                    }
                }
            }
        }

        private void DrawClosedSarfaces()
        {
            LinkedListNode<Surface> first = ClosedSurfaces.First;

            while (first != null)
            {
                DrawClosedShape(first);
                first = first.Next;
            }
        }

        private void DrawClosedShape(LinkedListNode<Surface> csf)
        {
            if (csf != null)
            {
                LinkedListNode<Point> p1, p2;
                p1 = csf.Value.Points.First;
                var pl = new Polygon();
                Brush b = Brushes.Gray;
                double Thicknes = .5;

                while (p1 != null)
                {
                    pl.Points.Add(p1.Value);

                    if (EnableEditMode)
                    {
                        if (DrawLinesandRect && csf == SelectedSurface)
                            DrawBox(p1.Value.X, p1.Value.Y);
                    }
                    else
                    {
                        if (DrawLinesandRect && csf == SelectedSurface)
                        {
                            b = new SolidColorBrush(SelectionHighlite);
                            Thicknes = SelectionThicknes;
                        }
                    }

                    if (p1.Next != null)
                    {
                        p2 = p1;
                        p1 = p1.Next;

                        if (DrawLinesandRect)
                            DrawLine(p2.Value.X, p2.Value.Y, p1.Value.X, p1.Value.Y, b, Thicknes);
                    }
                    else
                    {
                        p2 = p1;
                        p1 = csf.Value.Points.First;

                        if (DrawLinesandRect)
                            DrawLine(p2.Value.X, p2.Value.Y, p1.Value.X, p1.Value.Y, b, Thicknes);
                        p1 = null;
                    }
                }
                if (csf.Value.FillColor == new Color())
                    pl.Fill = Brushes.White;

                else
                {
                    pl.Fill = new SolidColorBrush(csf.Value.FillColor);
                }

                if (csf == SelectedSurface)
                {
                    pl.Stroke = Brushes.Red;
                    pl.StrokeThickness = 2;
                }

                if (ShowAllTransparent)
                    pl.Opacity = .3;
                //
                pl.Tag = csf;
                pl.Opacity = 0;
                if (csf.Value.Type == 1)
                    SetZIndex(pl, 1);

                pl.MouseUp += pl_MouseUp;
                pl.MouseDown += pl_MouseDown;
                pl.MouseMove += pl_MouseMove;
                pl.MouseEnter += pl_MouseEnter;
                pl.MouseLeave += pl_MouseLeave;

                canvas2.Children.Add(pl);
            }
        }

        private void pl_MouseLeave(object sender, MouseEventArgs e)
        {
        }

        private void pl_MouseEnter(object sender, MouseEventArgs e)
        {
            if (OnMouseOver != null)
            {
                var cSurface = (LinkedListNode<Surface>)((Polygon)sender).Tag;
                OnMouseOver(cSurface.Value.Tag is Zone, cSurface.Value.Tag);
            }
        }

        private void DrawLine(double X1, double Y1, double X2, double Y2, Brush b, double Thickness)
        {
            var l0 = new Line();
            l0.X1 = X1;
            l0.Y1 = Y1;
            l0.X2 = X2;
            l0.Y2 = Y2;
            l0.StrokeThickness = Thickness;
            l0.Stroke = b;
            canvas2.Children.Add(l0);
        }

        private void DrawLine(double X1, double Y1, double X2, double Y2)
        {
            var l0 = new Line();
            l0.X1 = X1;
            l0.Y1 = Y1;
            l0.X2 = X2;
            l0.Y2 = Y2;
            l0.StrokeThickness = 3;
            l0.Stroke = Brushes.Black;
            canvas2.Children.Add(l0);
        }

        private void DrawBox(double X, double Y)
        {
            var rec = new Rectangle();
            rec.Width = 12;
            rec.Height = 12;
            SetLeft(rec, X - 6);
            SetTop(rec, Y - 6);
            var myBrush = new SolidColorBrush(Colors.Green);
            rec.Stroke = Brushes.Red;
            rec.StrokeThickness = 1;
            rec.Fill = Brushes.Yellow;
            canvas2.Children.Add(rec);
        }

        #endregion

        #region XML Serialization

        public void SaveConstructionToFile()
        {
            zmap = new ZonesMap();

            var RegionsList = new List<Surface>();
            Zone zone;

            foreach (Surface surface in ClosedSurfaces)
            {
                if (surface.Type == 0) //Zone
                {
                    if (surface.Tag == null)
                        zone = new Zone();
                    else
                        zone = (Zone)surface.Tag;

                    zone.ZoneID = surface.SurfaceID;
                    zone.ZoneName = surface.Name;
                    zone.TranslateFactor = surface.TranslateFactor;
                    zone.ZoomFactor = surface.ZoomFactor;
                    var zonePoints = new Point[surface.Points.Count];
                    surface.Points.CopyTo(zonePoints, 0);
                    zone.ZoneSurface = zonePoints;
                    zmap.Zones.Add(zone);
                }
                else
                {
                    RegionsList.Add(surface);
                }
            }

            zmap.SaveZones(SavePathURL);
        }

        private Zone GetZoneParent(Point CheckforPoint)
        {
            bool res = false;

            foreach (Zone zone in zmap.Zones)
            {
                Debug.WriteLine(zone.ZoneName);
                res = PointInPolygon(CheckforPoint, zone.ZoneSurface);
                if (res)
                    return zone;
            }
            return null;
        }

        private static bool PointInPolygon(Point p, Point[] poly)
        {
            Point p1, p2;
            bool inside = false;
            if (poly.Length < 3)
            {
                return inside;
            }
            var oldPoint = new Point(
                poly[poly.Length - 1].X, poly[poly.Length - 1].Y);
            for (int i = 0; i < poly.Length; i++)
            {
                var newPoint = new Point(poly[i].X, poly[i].Y);
                if (newPoint.X > oldPoint.X)
                {
                    p1 = oldPoint;
                    p2 = newPoint;
                }
                else
                {
                    p1 = newPoint;
                    p2 = oldPoint;
                }
                if ((newPoint.X < p.X) == (p.X <= oldPoint.X) &&
                    ((long)p.Y - (long)p1.Y) * (long)(p2.X - p1.X) < ((long)p2.Y - (long)p1.Y) * (long)(p.X - p1.X))
                {
                    inside = !inside;
                }
                oldPoint = newPoint;
            }
            return inside;
        }


        public void LoadConstructionFile()
        {
            zmap = ZonesMap.LoadFromFile(SavePathURL);
            zmap.GetClosedSurface(ClosedSurfaces);
            UpdateInterface();
        }

        public void SelectSurface(Surface SelSurface)
        {
            LinkedListNode<Surface> fNode = ClosedSurfaces.First;
            while (fNode != null && fNode.Value.Name != SelSurface.Name)
            {
                fNode = fNode.Next;
            }
            SelectedSurface = fNode;
            UpdateInterface();
        }

        public void SelectSurface(string SurfaceName)
        {
            LinkedListNode<Surface> fNode = ClosedSurfaces.First;            
            while (fNode != null && fNode.Value.Name.ToLower() != SurfaceName.ToLower())
            {
                fNode = fNode.Next;
            }
            if (fNode != null && fNode.Value.Name.ToLower() == SurfaceName.ToLower())
                SelectedSurface = fNode;
            else
                SelectedSurface = null;

            UpdateInterface();
        }
        #endregion

        #region Polygon Processing

        private bool CloseSurface(Point p)
        {
            foreach (Point point1 in sf.Points)
            {
                double x = Math.Abs(point1.X - p.X);

                double y = Math.Abs(point1.Y - p.Y);

                if ((x <= 3) && (y <= 3))
                {
                    var ed = new SurfacePropertyWindow(sf, TranslationFactor, ZoomFactor);
                    ed.ShowDialog();

                    if (ed.DialogResult.HasValue && ed.DialogResult.Value)
                    {
                        EditMode = false;
                        sf = ed.sf;

                        Zone Parent = GetZoneParent(sf.Points.First.Value);
                        if (Parent != null)
                        {
                            var region = new Region();
                            region.RegionID = sf.SurfaceID;
                            region.RegionName = sf.Name;
                            var zonePoints = new Point[sf.Points.Count];
                            sf.Points.CopyTo(zonePoints, 0);
                            region.RegionSurface = zonePoints;
                            Parent.Regions.Add(region);
                        }

                        return true;
                    }

                    else if (ed.DialogResult.HasValue && !ed.DialogResult.Value)
                        return false;
                }
            }
            return false;
        }


        private LinkedListNode<Point> GetPoint(Surface sf, double X, double Y)
        {
            LinkedListNode<Point> f = sf.Points.First;

            while (!(f.Value.X == X && f.Value.Y == Y) && f.Next != null)
            {
                f = f.Next;
            }
            return f;
        }

        #endregion

        public ZonesMap Zones
        {
            get { return zmap; }
        }

        public LinkedListNode<Surface> SelectedSurface
        {
            get { return (LinkedListNode<Surface>)GetValue(SelectedSurfaceProperty); }
            set { SetValue(SelectedSurfaceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedSurface.  This enables animation, styling, binding, etc...


        public DateTime CurrentSelectionDate
        {
            get { return (DateTime)GetValue(CurrentSelectionDateProperty); }
            set { SetValue(CurrentSelectionDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentSelectionDate.  This enables animation, styling, binding, etc...


        public Point TranslationFactor
        {
            get { return (Point)GetValue(TranslationFactorProperty); }
            set { SetValue(TranslationFactorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TranslationFactor.  This enables animation, styling, binding, etc...


        public double ZoomFactor
        {
            get { return (double)GetValue(ZoomFactorProperty); }
            set { SetValue(ZoomFactorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ZoomFactor.  This enables animation, styling, binding, etc...


        public string SavePathURL
        {
            get { return (string)GetValue(SavePathURLProperty); }
            set { SetValue(SavePathURLProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SavePathURL.  This enables animation, styling, binding, etc...


        public bool EnableEditMode
        {
            get { return (bool)GetValue(EnableEditModeProperty); }
            set { SetValue(EnableEditModeProperty, value); }
        }

        public string SourceXMlString
        {
            get { return (string)GetValue(SourceXMlStringProperty); }
            set { SetValue(SourceXMlStringProperty, value); }
        }


        public string SourceXMLFileURL
        {
            get { return (string)GetValue(SourceXMLFileURLProperty); }
            set { SetValue(SourceXMLFileURLProperty, value); }
        }


        public ImageSource BackgroundImage
        {
            get { return (ImageSource)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackgroundImage.  This enables animation, styling, binding, etc...


        public bool IsFreezed
        {
            get { return (bool)GetValue(IsFreezedProperty); }
            set { SetValue(IsFreezedProperty, value); }
        }

        public UIElement SelectedShape
        {
            get { return (UIElement)GetValue(SelectedShapeProperty); }
            set { SetValue(SelectedShapeProperty, value); }
        }

        private static void selectedShape_Changed(object sender,
                                                  DependencyPropertyChangedEventArgs e)
        {
            InterActiveMap self = (InterActiveMap)sender;
            self.UpdateInterface();
        }

        // Using a DependencyProperty as the backing store for IsFreezed.  This enables animation, styling, binding, etc...

        public event OnSelectionChangedDlg OnSelectionChanged;

        public void ShowMetadataEditor()
        {
            //if (!EnableEditMode && SelectedSurface != null && SelectedSurface.Value.Tag != null)
            //{
            //    var Dupload = new DataUpload(System.IO.Path.GetDirectoryName(SavePathURL)+@"\Construction", zmap, SelectedSurface.Value, CurrentSelectionDate);
            //    Dupload.ShowDialog();
            //    if (Dupload.DialogResult.HasValue)
            //    {
            //        SaveConstructionToFile();
            //    }
            //}
        }

        public event OnMouseEnterdlg OnMouseOver;
    }
}