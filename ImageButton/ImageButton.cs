using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ImageButton"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ImageButton;assembly=ImageButton"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class ImageButton : Control
    {
        public static readonly DependencyProperty MouseOverImageProperty;
        public static readonly DependencyProperty OriginalImageProperty;

        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (ImageButton),
                                                     new FrameworkPropertyMetadata(typeof (ImageButton)));
            MouseOverImageProperty = DependencyProperty.Register("MouseOverImage", typeof (ImageSource),
                                                                 typeof (ImageButton), new UIPropertyMetadata(null));
            OriginalImageProperty = DependencyProperty.Register("OriginalImage", typeof (ImageSource),
                                                                typeof (ImageButton), new UIPropertyMetadata(null));
        }

        public ImageSource MouseOverImage
        {
            get { return (ImageSource) GetValue(MouseOverImageProperty); }
            set { SetValue(MouseOverImageProperty, value); }
        }

        public ImageSource OriginalImage
        {
            get { return (ImageSource) GetValue(OriginalImageProperty); }
            set { SetValue(OriginalImageProperty, value); }
        }
    }
}