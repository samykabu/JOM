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
using MapMenu.EntryForms;

namespace MapMenu.GeneralLocation
{
    /// <summary>
    /// Interaction logic for MonthlyReport.xaml
    /// </summary>
    public partial class MonthlyReport : Window
    {
        int CYear=2009, CMonth=1;
        public MonthlyReport()
        {
            InitializeComponent();
            if (App.IsInEditMode)
            {
                EditIcon.Visibility = Visibility.Visible;
            }
            ShowData();
        }

        private void CloseThisWindow(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ySelector_DateChanged(int Year, int Month)
        {
            CYear = Year;
            CMonth = Month;
            ShowData();
        }

        private void ExitApplication(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ShowData()
        {
            DateTime CurSelectedDate = new DateTime(CYear, CMonth, 1);
            

            IQueryable<DataRecord> drecords = from query in App.ActiveDatabase.DatabaseEntities.DataRecord
                                              where
                                                  query.Category.CategoryID == Util.MonthlyProgress &&
                                                  query.DataEntryDate == CurSelectedDate
                                              select query;
            int d = drecords.Count();
            
            PageView.Children.Clear();

            if (d > 0)
            {
                Image img = new Image();
                ImageSource imgsrc = Util.LoadImage(drecords.FirstOrDefault().DataFile);
                img.Source = imgsrc;
                img.Stretch = Stretch.Uniform;
                img.Width = PageView.Width;
                img.Height = PageView.Height;
                PageView.Children.Add(img);
            }
            
        }

        private void ShowMetadataDialog(object sender, MouseButtonEventArgs e)
        {
            DataUpload de = new DataUpload(Util.ApplicationRoot, true, null, Util.MonthlyProgressSectionID,
                                           new DateTime(CYear, CMonth, 1));
            de.ShowDialog();
            ShowData();
           
        }

    }
}
