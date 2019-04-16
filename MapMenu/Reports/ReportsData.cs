#region System Refrences

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using InterActiveMap;

#endregion

namespace MapMenu.Reports
{
    [Serializable]
    public class ReportsData
    {
        public BinLadenGroup BinLadenGroup = new BinLadenGroup();
        public GeneralReport GeneralReports = new GeneralReport();
        public saudiAujaGroup SaudiAujaGroup = new saudiAujaGroup();

        public static ReportsData LoadFromFile(string FileName)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof (ReportsData));
                XmlTextReader xtr = new XmlTextReader(FileName);
                return (ReportsData) xs.Deserialize(xtr);
            }
            catch (Exception ex)
            {
            }
            return new ReportsData();
        }

        public void SaveToFile(string FileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof (ReportsData));
            XmlTextWriter xtw = new XmlTextWriter(FileName, Encoding.UTF8);
            xs.Serialize(xtw, this);
            xs = null;
            xtw.Flush();
            xtw.Close();
        }
    }

    [Serializable]
    public class GeneralReport
    {
        public MetaData Data = new MetaData();
    }

    [Serializable]
    public class BinLadenGroup
    {
        public MetaData Data = new MetaData();
    }

    [Serializable]
    public class saudiAujaGroup
    {
        public MetaData Data = new MetaData();
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
            MetaDataYear mNewYear = new MetaDataYear();
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
        [XmlAttribute] public int Year;

        public MetaDataMonth Month(int month)
        {
            foreach (MetaDataMonth metaDataMonth in Months)
            {
                if (metaDataMonth.Month == month)
                    return metaDataMonth;
            }
            MetaDataMonth mNewMonth = new MetaDataMonth();
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
        public Cat2 cat2;
        public Cat3 cat3;
        public Cat4 cat4;
        public Cat5 cat5;
        public Cat6 cat6;
        public Cat7 cat7;
        public Cat8 cat8;
        public Cat9 cat9;

        [XmlAttribute] public int Month;

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
}