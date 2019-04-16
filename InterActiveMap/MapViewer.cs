using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InterActiveMap
{

    public class MapViewer : Canvas
    {
        public class PolygonSurface
        {
            private LinkedList<Point> _Points = new LinkedList<Point>();
            public object Tag;
            public Point TranslateFactor;
            public double ZoomFactor;
            public string SurfaceID { get; set; }
            public string Name { get; set; }
            public Guid GUID { get; set; }
            public int RefPolygon { get; set; }
            public int Type { get; set; }
            public Color FillColor { get; set; }
            public bool Selected { get; set; }
            public LinkedList<Point> Points
            {
                get { return _Points; }
                set { _Points = value; }
            }
        }

        internal LinkedList<PolygonSurface> Surfaces = new LinkedList<PolygonSurface>();
        private Canvas canvas2 = new Canvas();
        private Image backgroundImage = new Image();
        private LinkedListNode<PolygonSurface> SelectedSurface;
        private bool ShowAllTransparent = true;
        private LinkedListNode<PolygonSurface> oldSelectedSurface = null;        
        #region Dependancy properties

        public string BackGroundImage
        {
            get { return (string)GetValue(BackGroundImageProperty); }
            set { SetValue(BackGroundImageProperty, value); }
        }
        public static readonly DependencyProperty BackGroundImageProperty =
            DependencyProperty.Register("BackGroundImage", typeof(string), typeof(MapViewer), new UIPropertyMetadata("zones-2008-12-29.jpg"));



        public LinkedList<PolygonSurface> PolygonSurfaces
        {
            get { return (LinkedList<PolygonSurface>)GetValue(PolygonSurfacesProperty); }
            set { SetValue(PolygonSurfacesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PolygonSurfaces.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PolygonSurfacesProperty =
            DependencyProperty.Register("PolygonSurfaces", typeof(LinkedList<PolygonSurface>), typeof(MapViewer), new UIPropertyMetadata(null, PolygonsChanged));

        private static void PolygonsChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MapViewer self = (MapViewer)sender;
            self.Surfaces = (LinkedList<PolygonSurface>)e.NewValue;
            self.Refresh();
        }

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

        public static readonly DependencyProperty IsFreezedProperty =
            DependencyProperty.Register("IsFreezed", typeof(bool), typeof(InterActiveMap),
                                        new UIPropertyMetadata(false));
        public bool IsFreezed
        {
            get { return (bool)GetValue(IsFreezedProperty); }
            set { SetValue(IsFreezedProperty, value); }
        }


        #endregion

        #region Delegates

        public delegate void OnMouseEnterdlg(bool zone, Guid guid);
        public delegate void OnSelectionChangedDlg(bool zone, Guid guid);
        public delegate void OnSeleactionClearedDlg();
        public event OnSelectionChangedDlg OnSelectionChanged;
        public event OnMouseEnterdlg OnMouseOver;
        public event OnSeleactionClearedDlg OnSelectionClear;
        #endregion

        static MapViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MapViewer), new FrameworkPropertyMetadata(typeof(MapViewer)));
        }

        public MapViewer()
        {
            backgroundImage.Source = new BitmapImage(new Uri(BackGroundImage, UriKind.Relative));
            backgroundImage.Width = 3422;
            backgroundImage.Height = 5388;
            Children.Add(backgroundImage);
            canvas2.Width = 3422;
            canvas2.Height = 5388;
            Children.Add(canvas2);
        }

        public void Refresh()
        {            
            canvas2.Children.Clear();
            DrawClosedSarfaces();
        }       
        
        private void DrawClosedSarfaces()
        {
            LinkedListNode<PolygonSurface> first = Surfaces.First;

            while (first != null)
            {
                DrawClosedShape(first);
                first = first.Next;
            }
        }

        private void DrawClosedShape(LinkedListNode<PolygonSurface> csf)
        {
            if (csf != null)
            {
                LinkedListNode<Point> p1;
                p1 = csf.Value.Points.First;
                var pl = new Polygon();

                while (p1 != null)
                {
                    pl.Points.Add(p1.Value);                 
                    p1 = p1.Next;                    
                }

                pl.Fill = csf.Value.FillColor == new Color() ? Brushes.White : new SolidColorBrush(csf.Value.FillColor);

                if (csf.Value.Selected)
                {
                    pl.Stroke = new SolidColorBrush(SelectionHighlite);
                    pl.StrokeThickness = SelectionThicknes;
                }

                if (ShowAllTransparent)
                    pl.Opacity = .3;
                //
                pl.Tag = csf;                
                pl.Opacity = 0;                
                
                if (csf.Value.Type == 1)
                    SetZIndex(pl, 1);

                pl.MouseUp += PolygonMouseUp;
                pl.MouseEnter += pl_MouseEnter;
                csf.Value.RefPolygon=canvas2.Children.Add(pl);                
            }
        }

        #region Polygon Events

        public void SelectSurface(Guid ZoneRegionGUID)
        {
            foreach (var child in canvas2.Children)
            {
                if(child is Polygon)
                {
                    if(SelectedSurface!=null)
                    {
                        var pp = (Polygon)canvas2.Children[SelectedSurface.Value.RefPolygon];
                        pp.StrokeThickness = 0;
                        pp.Opacity = 0;
                    }
                    if (oldSelectedSurface != null)
                    {
                        var pp = (Polygon)canvas2.Children[oldSelectedSurface.Value.RefPolygon];
                        pp.StrokeThickness = 0;
                        pp.Opacity = 0;
                    }
                    var poly = (LinkedListNode<PolygonSurface>)((Polygon)child).Tag;
                    if(poly.Value.GUID==ZoneRegionGUID)
                    {
                        Polygon SelPoly = (Polygon) child;
                        SelPoly.Opacity = .3;
                        SelPoly.StrokeThickness = SelectionThicknes;
                        SelPoly.Stroke = new SolidColorBrush(SelectionHighlite);
                        SelectedSurface = (LinkedListNode<PolygonSurface>)SelPoly.Tag;
                        SelectedSurface.Value.Selected = true;
                        break;                        
                    }
                }
            }
        }
        private void PolygonMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!IsFreezed)
            {
                if (IsFocused != true)
                    Focus();

                if (e.ChangedButton == MouseButton.Left)
                {
                    e.Handled = true;

                    var selectedpoly = (Polygon)sender;                    
                    SelectedSurface = (LinkedListNode<PolygonSurface>)selectedpoly.Tag;

                    
                    Polygon SelPoly = (Polygon)canvas2.Children[SelectedSurface.Value.RefPolygon];

                    if (SelectedSurface == oldSelectedSurface)
                    {
                        SelectedSurface.Value.Selected = !SelectedSurface.Value.Selected;
                        if (SelectedSurface.Value.Selected)
                        {
                            SelPoly.Opacity = .3;
                            SelPoly.StrokeThickness = SelectionThicknes;
                            SelPoly.Stroke = new SolidColorBrush(SelectionHighlite);
                        }
                        else
                        {


                            SelPoly.Opacity = 0;
                            SelPoly.StrokeThickness = 0;
                            SelPoly.Stroke = new SolidColorBrush(SelectionHighlite);
                        }
                    }
                    else
                    {
                        if (oldSelectedSurface != null)
                        {
                            oldSelectedSurface.Value.Selected = false;
                            Polygon prvPoly = (Polygon)canvas2.Children[oldSelectedSurface.Value.RefPolygon];
                            prvPoly.Opacity = 0;
                            prvPoly.StrokeThickness = 0;
                            prvPoly.Stroke = new SolidColorBrush(SelectionHighlite);
                            prvPoly.InvalidateVisual();
                        }

                        SelectedSurface.Value.Selected = true;
                        SelPoly.Opacity = .3;
                        SelPoly.StrokeThickness = SelectionThicknes;
                        SelPoly.Stroke = new SolidColorBrush(SelectionHighlite);

                        oldSelectedSurface = SelectedSurface;
                    }

                    if (OnSelectionChanged != null)
                    {
                        if (SelectedSurface.Value.Selected)
                        {
                            if(OnSelectionChanged!=null)
                                OnSelectionChanged(SelectedSurface.Value.Type == 0, SelectedSurface.Value.GUID);
                        }
                        else
                        {
                            if (OnSelectionClear != null)
                                OnSelectionClear();
                        }
                    }
                    SelPoly.InvalidateVisual();
                }
            }
        }

        private void pl_MouseEnter(object sender, MouseEventArgs e)
        {
            if (OnMouseOver != null)
            {
                var cSurface = (LinkedListNode<PolygonSurface>)((Polygon)sender).Tag;
                OnMouseOver(cSurface.Value.Type == 0, cSurface.Value.GUID);
            }
        }

        #endregion
    }
}
