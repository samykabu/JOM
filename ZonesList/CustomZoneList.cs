#region Refrenced Assemblies

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

#endregion

namespace Controls
{
    public class CustomBarList : Canvas
    {
        #region Delegates
        public delegate void OnAnimationCompleteDel();
        public delegate void OnSelectionChangedDel(UIElement SelectedItem);
        public delegate void OnZoneClieckedDlg(Guid cat, string Name);
        public event OnZoneClieckedDlg OnZoneClicked;
        #endregion

        private static readonly DependencyProperty DataProperty = DependencyProperty.RegisterAttached("Data",
                                                                                                      typeof(
                                                                                                          CustListItem),
                                                                                                      typeof(
                                                                                                          CustomBarList));

        public IEnumerable<ZonesInfo> ItemsSource
        {
            get { return (IEnumerable<ZonesInfo>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable<ZonesInfo>), typeof(CustomBarList), new UIPropertyMetadata(null, new PropertyChangedCallback(ItemSourceChnaged)));

        public double AnimationDuration
        {
            get { return (double)GetValue(AnimationDurationProperty); }
            set { SetValue(AnimationDurationProperty, value); }
        }

        public static readonly DependencyProperty AnimationDurationProperty =
            DependencyProperty.Register("AnimationDuration", typeof(double), typeof(CustomBarList), new UIPropertyMetadata(0.4));

        public double AnimationSeperationDuration
        {
            get { return (double)GetValue(AnimationSeperationDurationProperty); }
            set { SetValue(AnimationSeperationDurationProperty, value); }
        }

        public static readonly DependencyProperty AnimationSeperationDurationProperty =
            DependencyProperty.Register("AnimationSeperationDuration", typeof(double), typeof(CustomBarList), new UIPropertyMetadata(0.0));

        public double ItemMargin
        {
            get { return (double)GetValue(ItemMarginProperty); }
            set { SetValue(ItemMarginProperty, value); }
        }

        public static readonly DependencyProperty ItemMarginProperty =
            DependencyProperty.Register("ItemMargin", typeof(double), typeof(CustomBarList), new UIPropertyMetadata(20.0));


        private double MOffset = 0;
        private DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Normal);

        public CustomBarList()
            : base()
        {
            timer.Tick += new EventHandler(timer_Tick);
            timer.IsEnabled = false;
        }

        public object SelectedItemTag { get; set; }
        public int SelectedIndex { get; set; }

        public double ItemSpacing
        {
            get { return ItemMargin; }
            set { ItemMargin = value; }
        }

        public double ImageWidth { get; set; }
        public double ImageHight { get; set; }

        public event OnSelectionChangedDel OnSelectionChanged;
        public event OnAnimationCompleteDel OnAnimationComplete;

        public static void ItemSourceChnaged(DependencyObject sender, DependencyPropertyChangedEventArgs arg)
        {
            CustomBarList osender = (CustomBarList)sender;
            if (arg.NewValue != arg.OldValue)
            {
                if (arg.NewValue is ZoneCollection)
                    osender.FillNewSource((ZoneCollection)arg.NewValue);

            }
        }

        internal void FillNewSource(ZoneCollection col)
        {
            ZoneCollection newcol = col;
            this.Children.Clear();
            int catTag = 1;
            foreach (ZonesInfo info in newcol)
            {
                Button bt = new Button();
                bt.Content = info.ZoneName;
                bt.Width = 200;
                bt.Height = 20;
                bt.Tag = new Guid("{" + info.ZoneID + "}");
                bt.Background = info.FillColor;
                bt.FontSize = 22;
                bt.FontWeight = FontWeights.Bold;
                bt.Click += new RoutedEventHandler(bt_Click);
                this.Children.Add(bt);
                catTag++;
            }

            this.InvalidateVisual();
        }

        private void bt_Click(object sender, RoutedEventArgs e)
        {
            if (OnZoneClicked != null)
                OnZoneClicked((Guid)((Button)sender).Tag, ((Button)sender).Content.ToString());
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            if (OnAnimationComplete != null)
                OnAnimationComplete();
        }

        public void SelectNext()
        {
            if (SelectedIndex <= Children.Count - 2)
            {
                SelectedIndex++;
                CalculateOffset(1);
                InvalidateArrange();
                if (OnSelectionChanged != null)
                    OnSelectionChanged(Children[SelectedIndex - 1]);
            }
        }

        public void Clear()
        {
            Children.Clear();
            SelectedItemTag = null;
            SelectedIndex = 0;
            MOffset = 0;
        }

        private void CalculateOffset(int dir)
        {
            int idx = 0;
            double offset = 0;
            foreach (UIElement child in Children)
            {
                if (dir == 1 && idx == SelectedIndex - 1)
                {
                    offset = ImageWidth + ItemMargin;
                    break;
                }
                if (dir == -1 && idx == SelectedIndex)
                {
                    offset = -(ImageWidth + ItemMargin);
                    break;
                }
                idx++;
            }
            MOffset = offset;
        }

        public void SelectPrevious()
        {
            if (SelectedIndex > 0)
            {
                SelectedIndex--;
                CalculateOffset(-1);
                InvalidateArrange();
                if (OnSelectionChanged != null)
                    OnSelectionChanged(Children[SelectedIndex - 1]);
            }
        }

        private DoubleAnimation MakeAnimation(double to, double startafter)
        {
            DoubleAnimation anim = new DoubleAnimation(to, TimeSpan.FromMilliseconds(1000 * AnimationDuration));
            anim.BeginTime = TimeSpan.FromSeconds(AnimationSeperationDuration * startafter);
            anim.AccelerationRatio = 0.2;
            anim.DecelerationRatio = 0.7;
            return anim;
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            int idx = 0;
            double ActualOffset = 0;
            timer.Stop();
            timer.Interval = TimeSpan.FromSeconds(AnimationDuration);
            foreach (UIElement child in Children)
            {
                CustListItem data = (CustListItem)child.GetValue(DataProperty);
                if (data == null)
                {
                    data = new CustListItem();
                    child.SetValue(DataProperty, data);
                }
                ImageWidth = ((Button)child).Width;//
                ActualOffset += ImageWidth;

                if (data.IsNew)
                {
                    data.IsNew = false;
                    child.Arrange(new Rect(new Point(0, 0), child.DesiredSize));
                    double moveto = (ActualOffset - (ImageWidth)) + ItemMargin * idx;
                    data.Location = new Point(moveto, 0);

                    TransformGroup tg = new TransformGroup();
                    Transform ts = new TranslateTransform(Width + 100, 0);
                    tg.Children.Add(ts);

                    ts.BeginAnimation((TranslateTransform.XProperty), MakeAnimation(moveto, idx),
                                      HandoffBehavior.Compose);
                    child.RenderTransform = tg;
                }
                else
                {
                    TransformGroup tg = new TransformGroup();
                    double moveto = MOffset;
                    Transform ts = new TranslateTransform(data.Location.X, data.Location.Y);
                    data.Location = new Point(data.Location.X - moveto, data.Location.Y);
                    tg.Children.Add(ts);
                    ts.BeginAnimation((TranslateTransform.XProperty), MakeAnimation(data.Location.X, idx),
                                      HandoffBehavior.Compose);
                    child.RenderTransform = tg;
                }
                idx++;
            }
            timer.Start();
            MOffset = 0;
            return DesiredSize;
        }

        #region Nested type: CustListItem

        private class CustListItem
        {
            public object Data;
            public bool IsNew = true;
            public Point Location;
            public Point Target;
        }

        #endregion
    }
}