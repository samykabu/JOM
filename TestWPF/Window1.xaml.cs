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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using JOMDB;
using System.IO;

namespace TestWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public static Datamanager ActiveDatabase = Datamanager.DataBase;

        public Window1()
        {
            InitializeComponent();
            //FillSurfaces();
        }

        private void FillSurfaces()
        {
            MapViewer1.PolygonSurfaces = new LinkedList<InterActiveMap.MapViewer.PolygonSurface>();

            var zoner = from zones in ActiveDatabase.DatabaseEntities.Zone select zones;

            
            foreach (Zone item in zoner)
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(item.PolyData);
                XmlNodeList xList = xdoc.SelectNodes("//Point");
                
                InterActiveMap.MapViewer.PolygonSurface nzone = new InterActiveMap.MapViewer.PolygonSurface();
                nzone.GUID = item.ID;
                nzone.Name = item.EnName;
                nzone.Type = 0;
                nzone.SurfaceID = item.ZoneID;
                nzone.ZoomFactor =(double) item.ZoomFactor;
                nzone.TranslateFactor = new Point((double)item.TranslateX, (double)item.TranslateY);
                nzone.FillColor = Color.FromRgb((byte)item.FillColorR, (byte)item.FillColorG, (byte)item.FillColorB);

                foreach (XmlNode xpoint in xList)
                {
                    nzone.Points.AddLast(new Point(double.Parse(xpoint.SelectSingleNode("X").InnerText), double.Parse(xpoint.SelectSingleNode("Y").InnerText)));
                }
                MapViewer1.PolygonSurfaces.AddLast(nzone);
            }

            var zreg = from region in ActiveDatabase.DatabaseEntities.Region select region;
            foreach (Region item in zreg)
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(item.PolyData);
                XmlNodeList xList = xdoc.SelectNodes("//Point");                
                InterActiveMap.MapViewer.PolygonSurface nregion = new InterActiveMap.MapViewer.PolygonSurface();
                nregion.GUID = item.ID;
                nregion.Type = 1;
                nregion.Name = item.EnName;
                nregion.SurfaceID = item.RegionID;
                nregion.ZoomFactor = (double)item.ZoomFactor;
                nregion.TranslateFactor = new Point((double)item.TranslateX, (double)item.TranslateY);
                nregion.FillColor = Color.FromRgb((byte)item.FillColorR, (byte)item.FillColorG, (byte)item.FillColorB);

                foreach (XmlNode xpoint in xList)
                {
                    nregion.Points.AddLast(new Point(double.Parse(xpoint.SelectSingleNode("X").InnerText), double.Parse(xpoint.SelectSingleNode("Y").InnerText)));
                }
                MapViewer1.PolygonSurfaces.AddLast(nregion);
            }
            MapViewer1.Refresh();
        }

        private void InterActiveMap_PosChanged(double x, double y, double ZoomFactor)
        {
            if (ZoomFactor == 1)
            {
                Canvas.SetLeft(ZoomedMap, x);
                Canvas.SetTop(ZoomedMap, y);
                ZoomedMap.Width = 668;
                ZoomedMap.Height = 456;
            }
            else
            {
                Canvas.SetLeft(ZoomedMap, x / ZoomFactor);
                Canvas.SetTop(ZoomedMap, y / ZoomFactor);
                ZoomedMap.Width = 668 * (1 / ZoomFactor);
                ZoomedMap.Height = 456 * (1 / ZoomFactor);
            }
            VVV.InvalidateArrange();
            VVV.InvalidateVisual();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            sysVar.Instance.isEnglish = !sysVar.Instance.isEnglish;
            JOMDB.JOMDBEntities jom = new JOMDB.JOMDBEntities("metadata=res://*/JOMDBModel.csdl|res://*/JOMDBModel.ssdl|res://*/JOMDBModel.msl;provider=System.Data.SqlServerCe.3.5;provider connection string=\"Data Source=d:\\JOMSQLDB.sdf;Password=p7z6y1f9;Persist Security Info=false\";");
            DateTime sd,ed,nd;
            sd=new DateTime(2009,5,1);
            ed=new DateTime(2009,7,31);
            nd = new DateTime(2009, 1, 1);
            string filestocopy = "";

            var rec = from records in jom.DataRecord where (records.DataEntryDate==nd ||(records.DataEntryDate <= ed && records.DataEntryDate >= sd)) select records;
            foreach (DataRecord dr in rec)
            {
                if (dr.DataEntryDate == nd)
                {
                    string d;
                    d = dr.DataFile;
                }
                
                FileInfo source = new FileInfo(dr.DataFile.Replace("C:", "F:"));
                if (source.Exists)
                {
                    FileInfo dest = new FileInfo(dr.DataFile.Replace("C:", "D:"));
                    if (!dest.Exists)
                    {
                        DirectoryInfo di = new DirectoryInfo(System.IO.Path.GetDirectoryName( dr.DataFile.Replace("C:", "D:")));
                        if (!di.Exists)
                            di.Create();
                        source.CopyTo(dr.DataFile.Replace("C:", "D:"));
                    }
                }
                else if(source.Directory.Exists)
                {
                    DirectoryInfo di = new DirectoryInfo(dr.DataFile.Replace("C:", "D:"));
                    if (!di.Exists)
                        di.Create();
                    filestocopy += "robocopy " + dr.DataFile.Replace("C:", "F:") + "\\ " + dr.DataFile.Replace("C:", "D:") + "\\ /s \r\n";
                }

                if (dr.ThumbnailFile != null && dr.ThumbnailFile != string.Empty)
                {
                    FileInfo vsource = new FileInfo(dr.ThumbnailFile.Replace("C:", "F:"));
                    if (vsource.Exists)
                    {
                        FileInfo dest = new FileInfo(dr.ThumbnailFile.Replace("C:", "D:"));
                        if (!dest.Exists)
                        {
                            DirectoryInfo di = new DirectoryInfo(System.IO.Path.GetDirectoryName(dr.ThumbnailFile.Replace("C:", "D:")));
                            if (!di.Exists)
                                di.Create();
                            vsource.CopyTo(dr.ThumbnailFile.Replace("C:", "D:"));
                        }
                    }
                    else if (vsource.Directory.Exists)
                    {
                        DirectoryInfo di = new DirectoryInfo(dr.ThumbnailFile.Replace("C:", "D:"));
                        if (!di.Exists)
                            di.Create();
                        filestocopy += "robocopy " + dr.ThumbnailFile.Replace("C:", "F:") + "\\ " + dr.ThumbnailFile.Replace("C:", "D:") + "\\ /s \r\n";
                    }
                }
            }

            FileInfo fi = new FileInfo(@"d:\Copylist.cmd");
            if (fi.Exists)
                fi.Delete();
            FileStream fs = fi.OpenWrite();
            byte[] buf = System.Text.Encoding.UTF8.GetBytes(filestocopy);
            fs.Write(buf, 0, buf.Length);
            fs.Flush();
            fs.Close();

        }
    }
}
