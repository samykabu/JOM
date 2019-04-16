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
using System.Windows.Shapes;

namespace MapMenu.GeneralLocation
{
    /// <summary>
    /// Interaction logic for GeneralLocMainMenu.xaml
    /// </summary>
    public partial class GeneralLocMainMenu : Window
    {
        public GeneralLocMainMenu()
        {
            InitializeComponent();
        }

        private void GoHome(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void ExitApplication(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ShowMonthlyReports(object sender, MouseButtonEventArgs e)
        {
            MonthlyReport mr = new MonthlyReport();
            mr.ShowDialog();
        }

        private void ShowGeneralLocation(object sender, MouseButtonEventArgs e)
        {
            Reports.GeneralLocation gr = new MapMenu.Reports.GeneralLocation();
            gr.ShowDialog();
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
