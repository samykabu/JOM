using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace YearSelector
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class YearSelector : UserControl
    {
        #region Delegates

        public delegate void OnDateChange(int Year, int Month);

        #endregion

        public static readonly DependencyProperty DateStringProperty =
            DependencyProperty.Register("DateString", typeof(string), typeof(YearSelector),
                                        new UIPropertyMetadata((new DateTime(2009, 1, 1)).ToString("MM / yyyy")));

        public static readonly DependencyProperty SelectedMonthProperty =
            DependencyProperty.Register("SelectedMonth", typeof(int), typeof(YearSelector), new UIPropertyMetadata(0));



        public string datestr
        {
            get { return (string)GetValue(datestrProperty); }
            set { SetValue(datestrProperty, value); }
        }

        // Using a DependencyProperty as the backing store for datestr.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty datestrProperty =
            DependencyProperty.Register("datestr", typeof(string), typeof(YearSelector), new UIPropertyMetadata(""));


        private int curPos = -1255;

        private Point CurrentPosition;
        private Point IntialPosition;
        private bool IsMouseDown;
        private long PreviouseCall = DateTime.Now.Ticks;
        private string[] ArabicMName = { "شباط", "آذار", "نيسان", "أيار", "حزيران", "تموز", "آب", "أيلول", "تشرين الأول", "تشرين الثاني", "كانون الأول ", " كانون الثاني" };

        private string[] ArabicMName2 = {
                                            "يناير", "فبراير", "مارس", "أبريل", "مايو", "يونيو", "يوليو", "أغسطس", "سبتمبر"
                                            , "أكتوبر", "نوفمبر", "ديسمبر"
                                        };




        private string ParseToArabic(DateTime dt)
        {
            return dt.ToString("MM / yyyy");
            return (ArabicMName2[dt.Month - 1] + "," + dt.Year);
        }

        public YearSelector()
        {
            InitializeComponent();

            label1.Content = DateString;
        }


        // Dependancy Property for Description
        public string DateString
        {
            get { return (string)GetValue(DateStringProperty); }
            set { SetValue(DateStringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DateString.  This enables animation, styling, binding, etc...

        public int SelectedMonth
        {
            get { return (int)GetValue(SelectedMonthProperty); }
            set { SetValue(SelectedMonthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedMonth.  This enables animation, styling, binding, etc...

        public event OnDateChange DateChanged;

        private void MouseDownEv(object sender, MouseButtonEventArgs e)
        {
            IntialPosition = e.MouseDevice.GetPosition(ControlContainer);
            CurrentPosition = IntialPosition;
            IsMouseDown = true;
            e.MouseDevice.OverrideCursor = Cursors.Hand;
            image1.CaptureMouse();
        }

        public void SetSelectionTo(DateTime SetDate)
        {
            double MonthCount = (SetDate.Month - 1) + (12 * (SetDate.Year - 2009));
            double pos = MonthCount * 20.5 - 1255;
            Canvas.SetLeft(image1, pos);
            SetValue(SelectedMonthProperty, (int)Math.Round((pos + 1255) / 20.5));
            var dt = new DateTime(2009, 1, 1);
            dt = dt.AddMonths((int)GetValue(SelectedMonthProperty));
            SetValue(DateStringProperty, ParseToArabic(dt));
            SetValue(datestrProperty, dt.ToShortDateString());
            label1.Content = ParseToArabic(dt);
            if (DateChanged != null)
                DateChanged(dt.Year, dt.Month);
        }

        private void MouseUpEv(object sender, MouseButtonEventArgs e)
        {
            image1.ReleaseMouseCapture();
            e.MouseDevice.OverrideCursor = Cursors.Arrow;
            IsMouseDown = false;
            //if (((curPos + 1255)/36) != 0)
            {
                curPos = (int)(-1255 + (int)Math.Round((curPos + 1255) / 20.5) * 20.5);
                Canvas.SetLeft(image1, curPos);
                SetValue(SelectedMonthProperty, (int)Math.Round((curPos + 1255) / 20.5));
                var dt = new DateTime(2009, 1, 1);
                dt = dt.AddMonths((int)GetValue(SelectedMonthProperty));
                SetValue(DateStringProperty, ParseToArabic(dt));
                SetValue(datestrProperty, dt.ToShortDateString());
                label1.Content = ParseToArabic(dt);

                if (DateChanged != null)
                    DateChanged(dt.Year, dt.Month);

                Debug.WriteLine(Math.Round((curPos + 1255) / 20.5).ToString());
            }
        }

        private void MoveSlider(object sender, MouseEventArgs e)
        {
            if (IsMouseDown && (DateTime.Now.Ticks - PreviouseCall) > TimeSpan.TicksPerSecond / 50)
            {
                CurrentPosition = e.MouseDevice.GetPosition(ControlContainer);

                if ((CurrentPosition.X - IntialPosition.X) > 0)
                {
                    curPos += (int)(CurrentPosition.X - IntialPosition.X);
                    if (curPos > -292)
                        curPos = -292;
                    Canvas.SetLeft(image1, curPos);
                }
                else
                {
                    curPos += (int)(CurrentPosition.X - IntialPosition.X);
                    if (curPos < -1255)
                        curPos = -1255;
                    Canvas.SetLeft(image1, curPos);
                }
                e.MouseDevice.Synchronize();
                IntialPosition = CurrentPosition;
                SetValue(SelectedMonthProperty, (int)Math.Round((curPos + 1255) / 20.5));
                var dt = new DateTime(2009, 1, 1);
                dt = dt.AddMonths((int)GetValue(SelectedMonthProperty));
                SetValue(DateStringProperty, ParseToArabic(dt));
                SetValue(datestrProperty, dt.ToShortDateString());
                label1.Content = ParseToArabic(dt);
                PreviouseCall = DateTime.Now.Ticks;
            }
        }

    }
}