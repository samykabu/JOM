using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace Controls
{
    public class ZonesInfo : DependencyObject
    {
        // Using a DependencyProperty as the backing store for FillColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillColorProperty =
            DependencyProperty.Register("FillColor", typeof(Brush), typeof(ZonesInfo),
                                        new UIPropertyMetadata(new SolidColorBrush(Colors.Red)));


        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(string), typeof(ZonesInfo), new UIPropertyMetadata("NA"));


        // Using a DependencyProperty as the backing store for ZoneID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ZoneIDProperty =
            DependencyProperty.Register("ZoneID", typeof(string), typeof(ZonesInfo), new UIPropertyMetadata("0"));

        public Brush FillColor
        {
            get { return (Brush)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }

        public string ZoneName
        {
            get { return (string)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        public string ZoneID
        {
            get { return (string)GetValue(ZoneIDProperty); }
            set { SetValue(ZoneIDProperty, value); }
        }
    }

    public sealed class ZoneCollection : ObservableCollection<ZonesInfo>
    {
        public ZoneCollection()
        {
            //Read From The Xml File The zones list and display them (File Directory \Def\Zones.xml)
            var zf = new ZonesInfo();
            zf.ZoneName = "Zone N1";
            zf.ZoneID = "e7ebfad6-83fe-4a4c-a5be-4bc358f62a38";
            zf.FillColor = new SolidColorBrush(Color.FromRgb(169, 172, 163));
            Add(zf);
            zf = new ZonesInfo();
            zf.ZoneName = "Zone N2";
            zf.ZoneID = "3597c78f-a2e9-4bcf-b387-c50d4a4bc020";
            zf.FillColor = new SolidColorBrush(Color.FromRgb(209, 206, 184));
            Add(zf);
            zf = new ZonesInfo();
            zf.ZoneName = "Zone N3";
            zf.ZoneID = "eee5ac38-cab5-427c-8380-167986aa0c4c";
            zf.FillColor = new SolidColorBrush(Color.FromRgb(166, 204, 175));
            Add(zf);
            zf = new ZonesInfo();
            zf.ZoneName = "Zone N4";
            zf.ZoneID = "65084e6d-7953-422e-809b-8c5860d6892a";
            zf.FillColor = new SolidColorBrush(Color.FromRgb(189, 188, 145));
            Add(zf);
            zf = new ZonesInfo();
            zf.ZoneName = "Zone N5";
            zf.ZoneID = "e7db6c9b-3780-44c3-9d83-c7e27301ac57";
            zf.FillColor = new SolidColorBrush(Color.FromRgb(135, 140, 139));
            Add(zf);
            zf = new ZonesInfo();
            zf.ZoneName = "Zone N6";
            zf.ZoneID = "8a300191-ce7f-4b86-8976-58e92df3709c";
            zf.FillColor = new SolidColorBrush(Color.FromRgb(151, 176, 92));
            Add(zf);


            zf = new ZonesInfo();
            zf.ZoneName = "Zone S1";
            zf.ZoneID = "9e31b38f-60e3-461d-9126-db5699577943";
            zf.FillColor = new SolidColorBrush(Color.FromRgb(148, 96, 53));
            Add(zf);            
            zf = new ZonesInfo();
            zf.ZoneName = "Zone S2";
            zf.ZoneID = "6bedef4b-0fee-46e4-930c-c0c7f7d2a57c";
            zf.FillColor = new SolidColorBrush(Color.FromRgb(139, 195, 141));
            Add(zf);
            zf = new ZonesInfo();
            zf.ZoneName = "Zone S3";
            zf.ZoneID = "be20756d-d1f6-4760-be03-ffa7c6b0081e";
            zf.FillColor = new SolidColorBrush(Color.FromRgb(141, 141, 150));
            Add(zf);
            zf = new ZonesInfo();
            zf.ZoneName = "Zone S4";
            zf.ZoneID = "471a9ee0-7a6a-415b-91c4-87ea342f15bb";
            zf.FillColor = new SolidColorBrush(Color.FromRgb(202, 202, 204));
            Add(zf);
            zf = new ZonesInfo();
            zf.ZoneName = "Zone S5";
            zf.ZoneID = "5f882c85-1b08-47a1-8653-858f89281e73";
            zf.FillColor = new SolidColorBrush(Color.FromRgb(185, 186, 191));
            Add(zf);
            zf = new ZonesInfo();
            zf.ZoneName = "Zone S6";
            zf.ZoneID = "e122e42b-5517-4a1e-8f7c-e7c3735dd6bf";
            zf.FillColor = new SolidColorBrush(Color.FromRgb(159, 208, 206));
            Add(zf);
            zf = new ZonesInfo();
            zf.ZoneName = "Zone S7";
            zf.ZoneID = "7ec3559d-cfcc-4d5b-b262-1a2eebfc3d08";
            zf.FillColor = new SolidColorBrush(Color.FromRgb(247, 175, 89));
            Add(zf);
            zf = new ZonesInfo();
            zf.ZoneName = "Zone S8";
            zf.ZoneID = "455fb534-1f9f-471f-8d36-02fa892307cc";
            zf.FillColor = new SolidColorBrush(Color.FromRgb(205, 218, 143));
            Add(zf);
            zf = new ZonesInfo();
            zf.ZoneName = "Zone S9";
            zf.ZoneID = "2ccc6fe4-a72e-46dc-b285-51ec8ceb0346";
            zf.FillColor = new SolidColorBrush(Color.FromRgb(226, 212, 121));
            Add(zf);
            zf = new ZonesInfo();
            zf.ZoneName = "Zone S10";
            zf.ZoneID = "c063f138-ca1d-4858-aff4-81ccce0799a6";
            zf.FillColor = new SolidColorBrush(Color.FromRgb(218, 191, 155));
            Add(zf);
            zf = new ZonesInfo();
            zf.ZoneName = "Zone S11";
            zf.ZoneID = "7966692c-f339-49ef-ac08-a4fe08beab1b";
            zf.FillColor = new SolidColorBrush(Color.FromRgb(231, 187, 174));
            Add(zf);
            
           
        }
    }
}