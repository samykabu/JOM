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

namespace LocalizedImage
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:LocalizedImage"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:LocalizedImage;assembly=LocalizedImage"
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
    public class LocImage : Control
    {        
        public static readonly DependencyProperty EnImageProperty;
        public static readonly DependencyProperty AraImageProperty;

        static LocImage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LocImage), new FrameworkPropertyMetadata(typeof(LocImage)));

            EnImageProperty = DependencyProperty.Register("EnImage", typeof(ImageSource),
                                                                 typeof(LocImage), new UIPropertyMetadata(null));
            AraImageProperty = DependencyProperty.Register("AraImage", typeof(ImageSource),
                                                                typeof(LocImage), new UIPropertyMetadata(null,new PropertyChangedCallback(ValidateAraImage)));
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



        public bool IsEnglish
        {
            get { return (bool)GetValue(IsEnglishProperty); }
            set {
                  SetValue(IsEnglishProperty, value); 
                }
        }

        // Using a DependencyProperty as the backing store for IsEnglish.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsEnglishProperty =
            DependencyProperty.Register("IsEnglish", typeof(bool), typeof(LocImage), new UIPropertyMetadata(false,new PropertyChangedCallback(ValidateImage)));

        private static void ValidateImage(DependencyObject Obj,DependencyPropertyChangedEventArgs args)
        {
            LocImage img = (LocImage)Obj;
            if (img.EnImage == null)
                img.EnImage =ParseUrl(img.AraImage.ToString());

        }

        private static void ValidateAraImage(DependencyObject Obj, DependencyPropertyChangedEventArgs args)
        {
            LocImage img = (LocImage)Obj;
            ImageSource arg=(ImageSource)args.NewValue;

            if (img.EnImage == null && arg!=null)
                img.EnImage = ParseUrl(arg.ToString());

        }


        private static BitmapImage ParseUrl(string url)
        {
            int pngidx = url.ToLower().LastIndexOf(".png");
            string a = url.Substring(0, pngidx);
            string b = url.Substring(pngidx);
            string r=a +"EN"+ b;

            BitmapImage ob;
            try
            {
                ob = new BitmapImage(new Uri(r, UriKind.RelativeOrAbsolute));
            }
            catch (Exception ex)
            {
                return new BitmapImage(new Uri(url, UriKind.RelativeOrAbsolute));
            }
            return ob;
        }


    }

}
