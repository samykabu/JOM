#region System Refrences

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Windows.Media;
using MapMenu.EntryForms;

#endregion

namespace MapMenu.Reports
{
    /// <summary>
    /// Interaction logic for ConstructionDetails.xaml
    /// </summary>
    public partial class SaudiAuj
    {
        private int CMonth;
        private int CYear;


        public SaudiAuj()
        {
            InitializeComponent();
            if (App.IsInEditMode)
            {
                EditIcon.Visibility = Visibility.Visible;
            }
            CYear = 2009;
            CMonth = 1;
            RefreshButtons();
        }

        private void CloseThisWindow(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
        private void ExitApplication(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void ySelector_DateChanged(int Year, int Month)
        {
            CYear = Year;
            CMonth = Month;
            RefreshButtons();
        }
        private void RefreshButtons()
        {
            DateTime CurSelectedDate = new DateTime(CYear, CMonth, 1);
            var Categories = from category in App.ActiveDatabase.DatabaseEntities.Category
                             where category.Sections.SectionID == Util.SaudiOjahReports
                             select category;
            wPanel.Children.Clear();
            foreach (Category category in Categories)
            {
                var drecords = from query in App.ActiveDatabase.DatabaseEntities.DataRecord
                               where
                                   query.Category.CategoryID == category.CategoryID &&
                                   query.DataEntryDate == CurSelectedDate
                               orderby query.EntryDateTime descending
                               select query;
                int d = drecords.Count();

                if (d > 0)
                {
                    Button bt = new Button();
                    bt.Template = (ControlTemplate)FindResource("GlassButton");
                    bt.FontFamily = new FontFamily("Simplified Arabic");
                    bt.FontSize = 20;
                    bt.Foreground = Brushes.White;
                    bt.FontWeight = FontWeights.Bold;
                    bt.Width = 310;
                    bt.Height = 35;
                    if (App.CurLanguage == App.Language.Arabic)
                        bt.Content = category.ArName;
                    else
                        bt.Content = category.EnName;

                    bt.Tag = category;
                    bt.Click += new RoutedEventHandler(ShowCategoryDetails);
                    wPanel.Children.Add(bt);
                }
            }
            wPanel.InvalidateVisual();
        }
        private void ShowCategoryDetails(object sender, RoutedEventArgs e)
        {
            Category btcat = (Category)((Button)sender).Tag;
            DateTime CurSelectedDate = new DateTime(CYear, CMonth, 1);
            var dr = from query in App.ActiveDatabase.DatabaseEntities.DataRecord
                     where
                         query.Category.CategoryID == btcat.CategoryID &&
                         query.DataEntryDate == CurSelectedDate
                     orderby query.EntryDateTime descending
                     select query;

            List<DataRecord> records = new List<DataRecord>();
            foreach (DataRecord record in dr)
            {
                records.Add(record);
            }
            if (records.Count > 0)
            {
                DataTypes dtype = (DataTypes)btcat.DType;
                switch (dtype)
                {
                    case DataTypes.Image: //Image Page View Galary                    
                        ImageGalaryPageView ImageGPageView = new ImageGalaryPageView(records,
                                                                                     btcat.HeaderImageFile);
                        ImageGPageView.ShowDialog();
                        if (ImageGPageView.DataChanged)
                            ySelector_DateChanged(CurSelectedDate.Year, CurSelectedDate.Month);
                        break;

                    case DataTypes.ImageGalary: //Image Gallary
                        ImageGalary ImageView = new ImageGalary(records);
                        ImageView.ShowDialog();
                        if (ImageView.DataChanged)
                            ySelector_DateChanged(CurSelectedDate.Year, CurSelectedDate.Month);

                        break;
                    case DataTypes.Video: // Video Galary
                        VideoGalary VideoView = new VideoGalary(records, btcat.HeaderImageFile);
                        VideoView.ShowDialog();
                        if (VideoView.DataChanged)
                            ySelector_DateChanged(CurSelectedDate.Year, CurSelectedDate.Month);
                        break;

                }

                records.Clear();
            }
        }
        private void ShowMetadataDialog(object sender, MouseButtonEventArgs e)
        {
            DataUpload de = new DataUpload(Util.ApplicationRoot, true, null, Util.SaudiOjahReports,
                                           new DateTime(CYear, CMonth, 1));
            de.ShowDialog();
            RefreshButtons();
        }

    }
}