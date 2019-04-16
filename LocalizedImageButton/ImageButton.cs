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

namespace LocalizedImageButton
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:LocalizedImageButton"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:LocalizedImageButton;assembly=LocalizedImageButton"
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
        public static readonly DependencyProperty AraMouseOverImageProperty;
        public static readonly DependencyProperty EnMouseOverImageProperty;
        public static readonly DependencyProperty AraImageProperty; 
        public static readonly DependencyProperty EnImageProperty;

        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton),
                                                     new FrameworkPropertyMetadata(typeof(ImageButton)));
            AraMouseOverImageProperty = DependencyProperty.Register("AraMouseOverImage", typeof(ImageSource),
                                                                 typeof(ImageButton), new UIPropertyMetadata(null));
            AraImageProperty = DependencyProperty.Register("AraImage", typeof(ImageSource),
                                                                typeof(ImageButton), new UIPropertyMetadata(null));
            EnMouseOverImageProperty = DependencyProperty.Register("EnMouseOverImage", typeof(ImageSource),
                                                                 typeof(ImageButton), new UIPropertyMetadata(null));
            EnImageProperty = DependencyProperty.Register("EnImage", typeof(ImageSource),
                                                                typeof(ImageButton), new UIPropertyMetadata(null));
        }

        public ImageSource EnImage
        {
            get { return (ImageSource)GetValue(EnImageProperty); }
            set { SetValue(EnImageProperty, value); }
        }

        public ImageSource AraImage
        {
            get { return (ImageSource)GetValue(AraImageProperty); }
            set { SetValue(AraImageProperty, value); }
        }

        public ImageSource EnMouseOverImage
        {
            get { return (ImageSource)GetValue(EnMouseOverImageProperty); }
            set { SetValue(EnMouseOverImageProperty, value); }
        }

        public ImageSource AraMouseOverImage
        {
            get { return (ImageSource)GetValue(AraMouseOverImageProperty); }
            set { SetValue(AraMouseOverImageProperty, value); }
        }

        public bool isEnglish
        {
            get { return (bool)GetValue(IsEnglishProperty); }
            set
            {
                SetValue(IsEnglishProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for IsEnglish.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsEnglishProperty =
            DependencyProperty.Register("isEnglish", typeof(bool), typeof(ImageButton), new UIPropertyMetadata(false, new PropertyChangedCallback(ValidateImage)));

        private static void ValidateImage(DependencyObject Obj, DependencyPropertyChangedEventArgs args)
        {
            

        }

       


        

    }
}
