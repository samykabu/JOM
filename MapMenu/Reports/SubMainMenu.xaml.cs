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
    public partial class SubMainMenu : Window
    {
        public SubMainMenu()
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
       

        private void GotoBinLaden(object sender, MouseButtonEventArgs e)
        {
            BinLadenReports blw = new BinLadenReports();
            blw.ShowDialog();
        }

        private void GotoSaudiAuj(object sender, MouseButtonEventArgs e)
        {
            SaudiAuj sow = new SaudiAuj();
            sow.ShowDialog();
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