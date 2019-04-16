using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace DataEntryList
{
    public class ImageFile : INotifyPropertyChanged
    {
        private string _ImageFileName;
        private string _Title;
        private int _Catigoty;

        public ImageFile(string ImgFileName, string title, int category)
        {
            _ImageFileName = ImgFileName;
            _Title = title;
            _Catigoty = category;
        }

        private Visibility _HasValidTitle;
        public Visibility HasValidTitle
        {
            get
            {
                if (_Title == string.Empty || (_Title.Trim().Length > 0 && (_Title.ToLower() == "na" || _Title.ToLower() == "no title")))
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }
        private void Notify(string PropertyName)
        {

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        public string FileName
        {
            get { return _ImageFileName; }
            set
            {
                _ImageFileName = value;
                Notify("FileName");
            }
        }
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                Notify("Title");
                Notify("HasValidTitle");

            }
        }
        public int Catigoty
        {
            get { return _Catigoty; }
            set
            {
                _Catigoty = value;
                Notify("Catigoty");

            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

    public class ImageList : ObservableCollection<ImageFile>
    {

    }
}
