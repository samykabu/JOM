#region System Refrences

using System.Windows;
using System.Windows.Input;
using MapMenu.Reports;

#endregion

namespace MapMenu
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private bool ConstructionPlayIntro = true;

        public MainMenu()
        {
            InitializeComponent();
            ConstructionPlayIntro = !App.IsInEditMode;
        }


        private void GotoConstruction(object sender, MouseButtonEventArgs e)
        {
            ConstructionMain cm = new ConstructionMain();
            HideAllCanvas.Visibility = Visibility.Visible;
            cm.SetAnimation(ConstructionPlayIntro);
            cm.ShowDialog();
            HideAllCanvas.Visibility = Visibility.Collapsed;
            ConstructionPlayIntro = false;
        }

        private void GotoDesign(object sender, MouseButtonEventArgs e)
        {
            NewDesignMain nd = new NewDesignMain();
            HideAllCanvas.Visibility = Visibility.Visible;
            nd.SetAnimation(ConstructionPlayIntro);
            nd.ShowDialog();
            HideAllCanvas.Visibility = Visibility.Collapsed;
            ConstructionPlayIntro = false;
        }

        private void ExitApplication(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GotoPresp(object sender, MouseButtonEventArgs e)
        {
            PrespectiveDesign3DView dview = new PrespectiveDesign3DView(2009, 1);
            HideAllCanvas.Visibility = Visibility.Visible;
            dview.SetAnimation(ConstructionPlayIntro);
            dview.ShowDialog();
            HideAllCanvas.Visibility = Visibility.Collapsed;
            ConstructionPlayIntro = false;
        }

        private void GotoReports(object sender, MouseButtonEventArgs e)
        {
            ReportsMapMenu rpm = new ReportsMapMenu();
            rpm.ShowDialog();
        }


        private void GotoPreStudies(object sender, MouseButtonEventArgs e)
        {
            PreMenu pm=new PreMenu();
            pm.ShowDialog();
        }

        private void GotoGeneralLocation(object sender, MouseButtonEventArgs e)
        {
            GeneralLocation.GeneralLocMainMenu locform = new GeneralLocation.GeneralLocMainMenu();
            locform.ShowDialog();
        }

        private void ChangeLanguage(object sender, MouseButtonEventArgs e)
        {
            if (App.CurLanguage == App.Language.Arabic)
                App.CurLanguage = App.Language.English;
            else
                App.CurLanguage = App.Language.Arabic;
            sysVar.Instance.isEnglish = !sysVar.Instance.isEnglish;
        }
    }
}