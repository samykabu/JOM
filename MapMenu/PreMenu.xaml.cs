#region System Refrences

using System.Windows;
using System.Windows.Input;
using MapMenu.Studies;

#endregion

namespace MapMenu
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class PreMenu : Window
    {
        private bool ConstructionPlayIntro = true;

        public PreMenu()
        {
            InitializeComponent();
            ConstructionPlayIntro = !App.IsInEditMode;
        }


      

        private void ExitApplication(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GotoUtility(object sender, MouseButtonEventArgs e)
        {
            UtilitiesDesignStudies ud=new UtilitiesDesignStudies();
            ud.ShowDialog();

        }

        private void GoGeneralStudies(object sender, MouseButtonEventArgs e)
        {
            GeneralStudies gf=new GeneralStudies();
            gf.ShowDialog();
        }

        private void CloseThisWindow(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void ChangeLanguage(object sender, MouseButtonEventArgs e)
        {
            if (App.CurLanguage == App.Language.Arabic)
                App.CurLanguage = App.Language.English;
            else
                App.CurLanguage = App.Language.Arabic;
            sysVar.Instance.isEnglish = !sysVar.Instance.isEnglish;
        }

        private void GoHome(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

     


       
    }
}