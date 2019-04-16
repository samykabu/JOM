using System.Windows;
using System.Windows.Media;

namespace InterActiveMap
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class SurfacePropertyWindow : Window
    {
        private readonly Point translationpoint;
        private readonly double zoomlevel;
        internal Surface sf;

        public SurfacePropertyWindow()
        {
            InitializeComponent();
        }

        public SurfacePropertyWindow(Point TranslationPoint, double ZoomLevel)
        {
            InitializeComponent();
            Zooml.Text = ZoomLevel.ToString();
            X.Text = TranslationPoint.X.ToString();
            Y.Text = TranslationPoint.Y.ToString();
            translationpoint = TranslationPoint;
            zoomlevel = ZoomLevel;
        }

        public SurfacePropertyWindow(Surface sff, Point TranslationPoint, double ZoomLevel)
        {
            InitializeComponent();

            sf = sff;
            textBox1.Text = sf.Name;

            if (sf.Type == 0)
                radioButton1.IsChecked = true;

            if (sf.Type == 1)
                radioButton2.IsChecked = true;
            IDtxtbox.Text = sf.SurfaceID;

            if (sf.FillColor.R == sf.FillColor.G && sf.FillColor.R == sf.FillColor.B && sf.FillColor.B == 0)
                sf.FillColor = Color.FromRgb(100, 100, 100);

            Zooml.Text = ZoomLevel.ToString();
            X.Text = TranslationPoint.X.ToString();
            Y.Text = TranslationPoint.Y.ToString();
            translationpoint = TranslationPoint;
            zoomlevel = ZoomLevel;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0 || IDtxtbox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Make sure that Surface Name and ID filled");
                return;
            }
            sf.Name = textBox1.Text;

            if (radioButton1.IsChecked == true)
                sf.Type = 0;

            else if (radioButton2.IsChecked == true)
                sf.Type = 1;

            sf.TranslateFactor = translationpoint;
            sf.ZoomFactor = zoomlevel;
            sf.SurfaceID = IDtxtbox.Text;
            DialogResult = true;
        }

        private void ColorSelectionBT_Click(object sender, RoutedEventArgs e)
        {
            //var cPicker = new ColorPickerDialog();
            //cPicker.StartingColor = sf.FillColor;
            //cPicker.Owner = this;
            //bool? dialogResult = cPicker.ShowDialog();

            //if (dialogResult != null && (bool) dialogResult)
            //{
            //    sf.FillColor = cPicker.SelectedColor;
            //}
        }
    }
}