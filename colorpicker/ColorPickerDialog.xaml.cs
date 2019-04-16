using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace Microsoft.Samples.CustomControls
{
    /// <summary>
    /// Interaction logic for ColorPickerDialog.xaml
    /// </summary>
    public partial class ColorPickerDialog : Window
    {
        private readonly Color startingColor;
        private Color m_color;

        public ColorPickerDialog()
        {
            InitializeComponent();
        }

        public Color SelectedColor
        {
            get { return m_color; }
        }

        public Color StartingColor
        {
            get { return startingColor; }
            set
            {
                cPicker.SelectedColor = value;
                OKButton.IsEnabled = false;
            }
        }

        private void okButtonClicked(object sender, RoutedEventArgs e)
        {
            OKButton.IsEnabled = false;
            m_color = cPicker.SelectedColor;
            DialogResult = true;
            Hide();
        }

        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            OKButton.IsEnabled = false;
            DialogResult = false;
        }

        private void onSelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            if (e.NewValue != m_color)
            {
                OKButton.IsEnabled = true;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            OKButton.IsEnabled = false;
            base.OnClosing(e);
        }
    }
}