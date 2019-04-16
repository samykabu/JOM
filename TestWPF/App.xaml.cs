using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace TestWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application 
    {
       
        public  sysVar lng
        {
            get { return (sysVar.Instance); }
        }
    }

    public  class sysVar:INotifyPropertyChanged
    {
        private static sysVar _instance = null;
        private bool _isEnglish=true;

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
