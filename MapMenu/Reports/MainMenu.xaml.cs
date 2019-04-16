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
    public partial class ReportsMapMenu : Window
    {        

        public ReportsMapMenu()
        {
            InitializeComponent();
        }


        private void ExitApplication(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GoHome(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void GotoGeneral(object sender, MouseButtonEventArgs e)
        {
            GeneralReports gm = new GeneralReports();
            gm.ShowDialog();
        }

       

        private void GotoSubMain(object sender, MouseButtonEventArgs e)
        {
            SubMainMenu smm=new SubMainMenu();
            smm.ShowDialog();
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