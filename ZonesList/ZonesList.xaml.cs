using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Controls;

namespace ZonesList
{
    /// <summary>
    /// Interaction logic for ZonesList.xaml
    /// </summary>
    public partial class ZonesList : UserControl
    {
        public delegate void OnZoneClickedDlg(Guid cat,string ZoneName);
        public event OnZoneClickedDlg OnZoneClicked;

        private int ViewIndex = 1;        
        public ZoneCollection ItemCollection
        {
            get { return (ZoneCollection) GetValue(ItemCollectionProperty); }
            set { SetValue(ItemCollectionProperty, value); }
        }

        public static readonly DependencyProperty ItemCollectionProperty =
            DependencyProperty.Register("ItemCollection", typeof (ZoneCollection), typeof (ZonesList), new UIPropertyMetadata(new ZoneCollection()));
        
        public ZonesList()
        {
            InitializeComponent();                      
            SetValue(ItemCollectionProperty,new ZoneCollection());
            Binding ItemsBind = new Binding();
            ItemsBind.Source = ItemCollection;
            zlist.SetBinding(CustomBarList.ItemsSourceProperty, ItemsBind);            
        }
      
        private void MovePrevouse(object sender, MouseButtonEventArgs e)
        {
            
            zlist.SelectPrevious();
        }

        private void MoveNext(object sender, MouseButtonEventArgs e)
        {            
            zlist.SelectNext();
        }

        private  void BTClicked(Guid Cat,string Name)
        {
            if (OnZoneClicked != null)
                OnZoneClicked(Cat,Name);
        }
    }
}