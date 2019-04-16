using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Xml;
using System.Xml.Serialization;

namespace InterActiveMap
{
    [Serializable]
    public enum MetaDataCatigory
    {
    }

    [Serializable]
    public class Surface
    {
        private LinkedList<Point> _Points = new LinkedList<Point>();
        [XmlIgnore]
        public object Tag;
        public Point TranslateFactor;
        public double ZoomFactor;
        public string SurfaceID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public Color FillColor { get; set; }

        public LinkedList<Point> Points
        {
            get { return _Points; }
            set { _Points = value; }
        }
    }

    [Serializable]
    public class ZonesMap
    {
        public List<Zone> Zones = new List<Zone>();
        public void SaveZones(string SavePathURL)
        {
            var xsr = new XmlSerializer(typeof(ZonesMap));
            var xtw = new XmlTextWriter(SavePathURL, Encoding.UTF8);
            xsr.Serialize(xtw, this);
            xsr = null;
            xtw.Flush();
            xtw.Close();
        }

        public static ZonesMap LoadFromFile(string SavePathURL)
        {
            ZonesMap Res;
            try
            {
                var xsr = new XmlSerializer(typeof(ZonesMap));
                var xtr = new XmlTextReader(SavePathURL);
                Res = (ZonesMap)xsr.Deserialize(xtr);
                xsr = null;
                xtr.Close();
            }
            catch (Exception)
            {
                return new ZonesMap();
            }
            return Res;
        }
        public void GetClosedSurface(LinkedList<Surface> ClosedSurfaces)
        {
            ClosedSurfaces.Clear();

            foreach (Zone zone in Zones)
            {
                var sf = new Surface();
                sf.Name = zone.ZoneName;
                sf.SurfaceID = zone.ZoneID;
                sf.FillColor = zone.FillColor;
                sf.Type = 0;
                sf.Tag = zone;
                foreach (Point oPoint in zone.ZoneSurface)
                {
                    sf.Points.AddLast(oPoint);
                }
                ClosedSurfaces.AddLast(sf);

                foreach (Region region in zone.Regions)
                {
                    sf = new Surface();
                    sf.Name = region.RegionName;
                    sf.SurfaceID = region.RegionID;
                    sf.FillColor = region.FillColor;
                    sf.Type = 1;
                    sf.Tag = region;
                    foreach (Point oPoint in region.RegionSurface)
                    {
                        sf.Points.AddLast(oPoint);
                    }
                    ClosedSurfaces.AddLast(sf);
                }
            }
        }
    }

    [Serializable]
    public class Zone
    {
        public MetaData Metadata;
        public List<Region> Regions = new List<Region>();
        public Point TranslateFactor;
        [XmlAttribute]
        public string ZoneID;
        [XmlAttribute]
        public string ZoneName;
        public Point[] ZoneSurface;
        public double ZoomFactor;
        public Color FillColor { get; set; }

        public MetaData GetMetaData()
        {
            if (Metadata == null)
                Metadata = new MetaData();
            return Metadata;
        }
    }

    [Serializable]
    public class Region
    {
        public MetaData Metadata;
        [XmlAttribute]
        public string RegionID;
        [XmlAttribute]
        public string RegionName;
        public Point[] RegionSurface;
        public Point TranslateFactor;
        public double ZoomFactor;
        public Color FillColor { get; set; }

        public MetaData GetMetaData()
        {
            if (Metadata == null)
                Metadata = new MetaData();
            return Metadata;
        }
    }

    [Serializable]
    public class MetaData
    {
        public List<MetaDataYear> MetaDataCollection = new List<MetaDataYear>();

        public MetaDataYear Year(int Year)
        {
            foreach (MetaDataYear metaDataYear in MetaDataCollection)
            {
                if (metaDataYear.Year == Year)
                    return metaDataYear;
            }
            var mNewYear = new MetaDataYear();
            mNewYear.Year = Year;
            MetaDataCollection.Add(mNewYear);
            return mNewYear;
        }

        public MetaDataYear CheckYear(int Year)
        {
            foreach (MetaDataYear metaDataYear in MetaDataCollection)
            {
                if (metaDataYear.Year == Year)
                    return metaDataYear;
            }
            return null;
        }
    }

    [Serializable]
    public class MetaDataYear
    {
        public List<MetaDataMonth> Months = new List<MetaDataMonth>();
        [XmlAttribute]
        public int Year;

        public MetaDataMonth Month(int month)
        {
            foreach (MetaDataMonth metaDataMonth in Months)
            {
                if (metaDataMonth.Month == month)
                    return metaDataMonth;
            }
            var mNewMonth = new MetaDataMonth();
            mNewMonth.Month = month;
            Months.Add(mNewMonth);
            return mNewMonth;
        }

        public MetaDataMonth CheckMonth(int month)
        {
            foreach (MetaDataMonth metaDataMonth in Months)
            {
                if (metaDataMonth.Month == month)
                    return metaDataMonth;
            }
            return null;
        }
    }

    [Serializable]
    public class MetaDataMonth
    {
        public Cat1 cat1;
        public Cat10 cat10;
        public Cat11 cat11;
        public Cat12 cat12;
        public Cat13 cat13;
        public Cat14 cat14; //Video Synop
        public Cat2 cat2;
        public Cat3 cat3;
        public Cat4 cat4;
        public Cat5 cat5;
        public Cat6 cat6;
        public Cat7 cat7;
        public Cat8 cat8;
        public Cat9 cat9;
        [XmlAttribute]
        public int Month;

        public Cat1 GetCat1()
        {
            if (cat1 == null)
                cat1 = new Cat1();
            return cat1;
        }

        public Cat2 GetCat2()
        {
            if (cat2 == null)
                cat2 = new Cat2();
            return cat2;
        }

        public Cat3 GetCat3()
        {
            if (cat3 == null)
                cat3 = new Cat3();
            return cat3;
        }

        public Cat4 GetCat4()
        {
            if (cat4 == null)
                cat4 = new Cat4();
            return cat4;
        }

        public Cat5 GetCat5()
        {
            if (cat5 == null)
                cat5 = new Cat5();
            return cat5;
        }

        public Cat6 GetCat6()
        {
            if (cat6 == null)
                cat6 = new Cat6();
            return cat6;
        }

        public Cat7 GetCat7()
        {
            if (cat7 == null)
                cat7 = new Cat7();
            return cat7;
        }

        public Cat8 GetCat8()
        {
            if (cat8 == null)
                cat8 = new Cat8();
            return cat8;
        }

        public Cat9 GetCat9()
        {
            if (cat9 == null)
                cat9 = new Cat9();
            return cat9;
        }

        public Cat10 GetCat10()
        {
            if (cat10 == null)
                cat10 = new Cat10();
            return cat10;
        }

        public Cat11 GetCat11()
        {
            if (cat11 == null)
                cat11 = new Cat11();
            return cat11;
        }

        public Cat12 GetCat12()
        {
            if (cat12 == null)
                cat12 = new Cat12();
            return cat12;
        }

        public Cat13 GetCat13()
        {
            if (cat13 == null)
                cat13 = new Cat13();
            return cat13;
        }

        public Cat14 GetCat14()
        {
            if (cat14 == null)
                cat14 = new Cat14();
            return cat14;
        }
    }

    [Serializable]
    public class Cat1
    {
        public List<ImageFile> Images;
        public List<ImageFile> GetImages()
        {
            if (Images == null)
                Images = new List<ImageFile>();
            return Images;
        }
    }

    [Serializable]
    public class Cat2
    {
        public List<ImageFile> Images;
        public List<ImageFile> GetImages()
        {
            if (Images == null)
                Images = new List<ImageFile>();
            return Images;
        }
    }

    [Serializable]
    public class Cat3
    {
        public List<ImageFile> Images;
        public List<ImageFile> GetImages()
        {
            if (Images == null)
                Images = new List<ImageFile>();
            return Images;
        }
    }

    [Serializable]
    public class Cat4
    {
        public List<ImageFile> Images;
        public List<ImageFile> GetImages()
        {
            if (Images == null)
                Images = new List<ImageFile>();
            return Images;
        }
    }

    [Serializable]
    public class Cat5
    {
        public List<ImageFile> Images;
        public List<ImageFile> GetImages()
        {
            if (Images == null)
                Images = new List<ImageFile>();
            return Images;
        }
    }

    [Serializable]
    public class Cat6
    {
        public List<ImageFile> Images;
        public List<ImageFile> GetImages()
        {
            if (Images == null)
                Images = new List<ImageFile>();
            return Images;
        }
    }

    [Serializable]
    public class Cat7
    {
        public List<ImageFile> Images;
        public List<ImageFile> GetImages()
        {
            if (Images == null)
                Images = new List<ImageFile>();
            return Images;
        }
    }

    [Serializable]
    public class Cat8
    {
        public List<ImageFile> Images;
        public List<ImageFile> GetImages()
        {
            if (Images == null)
                Images = new List<ImageFile>();
            return Images;
        }
    }

    [Serializable]
    public class Cat9
    {
        public List<ImageFile> Images;
        public List<ImageFile> GetImages()
        {
            if (Images == null)
                Images = new List<ImageFile>();
            return Images;
        }
    }

    [Serializable]
    public class Cat10
    {
        public List<VideoFile> Videos;
        public List<VideoFile> GetVideos()
        {
            if (Videos == null)
                Videos = new List<VideoFile>();
            return Videos;
        }
    }

    [Serializable]
    public class Cat11
    {
        public List<ThreeDView> V3DViews;
        public List<ThreeDView> Get3DViews()
        {
            if (V3DViews == null)
                V3DViews = new List<ThreeDView>();
            return V3DViews;
        }
    }

    [Serializable]
    public class Cat12
    {
        public List<ImageFile> Images;
        public List<ImageFile> GetImages()
        {
            if (Images == null)
                Images = new List<ImageFile>();
            return Images;
        }
    }

    [Serializable]
    public class Cat13
    {
        public List<ThreeDView> V3DViews;
        public List<ThreeDView> Get3DViews()
        {
            if (V3DViews == null)
                V3DViews = new List<ThreeDView>();
            return V3DViews;
        }
    }

    public class Cat14
    {
        public List<VideoFile> Videos;
        public List<VideoFile> GetVideos()
        {
            if (Videos == null)
                Videos = new List<VideoFile>();
            return Videos;
        }
    }

    [Serializable]
    public class ImageFile
    {
        [XmlAttribute]
        public DateTime date;
        [XmlAttribute]
        public string FileName;
        [XmlAttribute]
        public string Title;
    }

    [Serializable]
    public class VideoFile
    {
        public DateTime date;
        [XmlAttribute]
        public string Title;
        [XmlAttribute]
        public string VideoFileName;
        [XmlAttribute]
        public string VideoThumbnail;
    }

    [Serializable]
    public class Document
    {
        [XmlAttribute]
        public DateTime date;
        [XmlAttribute]
        public string DocumentName;
        [XmlAttribute]
        public string Title;
    }

    [Serializable]
    public class ThreeDView
    {
        [XmlAttribute]
        public DateTime date;
        [XmlAttribute]
        public string FolderName;
        [XmlAttribute]
        public string Title;
    }
}