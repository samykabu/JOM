#region System Refrences

using System;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Media.Animation;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using System.ComponentModel;
using JOMDB;

#endregion

namespace MapMenu
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Datamanager ActiveDatabase = Datamanager.DataBase;
        public static Hashtable CommandLineArgs = new Hashtable();
        public static bool IsInEditMode;
        public static bool IsInFullEditMode;
        public static Language CurLanguage = Language.Arabic;

        public enum Language
        {
            Arabic,
            English
        }

        public sysVar lng
        {
            get { return (sysVar.Instance); }
        }

        public static void DoEvents()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate { }));
        }
        
        private void app_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new PropertyMetadata(25));

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-SA");
                IsInEditMode = false;
                if (e.Args.Length == 0) return;

                string pattern = @"(?<argname>/\w+):(?<argvalue>\w+)";
                foreach (string arg in e.Args)
                {
                    Match match = Regex.Match(arg, pattern);
                    if (!match.Success)
                        throw new ArgumentException(
                            "The command line arguments are improperly formed. Use /argname:argvalue.");

                    CommandLineArgs[match.Groups["argname"].Value.ToLower()] = match.Groups["argvalue"].Value;
                }
                if (CommandLineArgs["/editmode"] != null)
                {
                    IsInFullEditMode = ((string)CommandLineArgs["editmode"]).ToLower() == "y";
                }
                if (CommandLineArgs["/dataentry"] != null)
                {
                    IsInEditMode = ((string)CommandLineArgs["/dataentry"]).ToLower() == "y";
                    // (string)CommandLineArgs["dataentry"] == "y";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Application Wide Error :" + ex.Message);
                throw ex;
            }
        }
    }

    public class sysVar : INotifyPropertyChanged
    {
        private static sysVar _instance = null;
        private bool _isEnglish = false;

        public static sysVar Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new sysVar();
                return _instance;
            }
        }

        private sysVar()
        {
        }

        public bool isEnglish
        {
            get { return _isEnglish; }
            set
            {
                _isEnglish = value;
                NotifyPropertyChanged("isEnglish");
            }
        }
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion
    }

}