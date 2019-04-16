#region System Refrences

using System;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;

#endregion

namespace MapMenu
{
    public static class Util
    {
        public static string ApplicationRoot = @"C:\JOM";
        public static Guid ConstructionGuid = new Guid("{b2872373-07a7-4456-abb4-f3d568daed7d}");
        public static Guid DesignGuid = new Guid("{b2872373-07a7-4456-abb4-f3d568daed6d}");
        public static Guid PrespectiveGuid = new Guid("{b2872373-07a7-4456-abb4-f3d568daed8d}");
        public static Guid BinLadenReports = new Guid("{b2872373-07a7-4456-abb4-f3d568da3d61}");
        public static Guid SaudiOjahReports = new Guid("{b2872373-07a7-4456-abb4-f3d568da2d61}");
        public static Guid GeneralReports = new Guid("{b2872373-07a7-4456-abb4-f3d568da1d61}");
        public static Guid GeneralStudies = new Guid("{b2872373-07a7-4456-abb4-f3d568daed60}");
        public static Guid UtilitiesDesignBrief = new Guid("{b2872373-07a7-4456-abb4-f3d568daed61}");
        public static Guid GeneralLocation = new Guid("{b2872373-07a7-4456-abb4-f3d568daed9d}");
        public static Guid MonthlyProgress = new Guid("{b82106a7-f3ed-411a-9cab-ab293284ffc4}");
        public static Guid MonthlyProgressSectionID = new Guid("{d358e77e-1795-4351-b2d0-ef1038726eba}");



        public static Guid SynopImageCat = new Guid("{b2872373-07a7-4456-abb4-a3d568daed7d}");
        public static Guid SynopVideoCat = new Guid("{b2872373-07a7-4456-abb4-3bd568daed7d}");

        public static Guid Construction3DViewReal = new Guid("{5e572522-ddae-4179-8649-de60c2cb6311}");
        public static Guid Construction3DViewVirtual = new Guid("{6a5d593f-d12a-4ac2-bfe9-aac26c10d0e0}");


        public static void ChangeLanguage()
        {
            if (App.CurLanguage == App.Language.Arabic)
                App.CurLanguage = App.Language.English;
            else
                App.CurLanguage = App.Language.Arabic;
            sysVar.Instance.isEnglish = !sysVar.Instance.isEnglish;
        }

        public static string BasePath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
        }

        public static BitmapImage LoadImage(string ImageFile)
        {
            try
            {
                byte[] buffer = File.ReadAllBytes(ImageFile);
                MemoryStream ms = new MemoryStream(buffer);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = ms;
                image.EndInit();
                image.Freeze();
                return image;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public static BitmapImage LoadImage(string ImageFile, UriKind urkind)
        {
            string nImageFile = "";
            switch (urkind)
            {
                case UriKind.Relative:
                    nImageFile = Path.Combine(BasePath(), ImageFile);
                    break;
                default:
                    nImageFile = ImageFile;
                    break;
            }

            if (File.Exists(nImageFile))
            {
                byte[] buffer = File.ReadAllBytes(nImageFile);
                MemoryStream ms = new MemoryStream(buffer);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = ms;
                image.EndInit();
                image.Freeze();
                return image;
            }
            else
            {
                BitmapImage ms = new BitmapImage(new Uri(ImageFile, UriKind.Relative));
                return ms;
            }
        }

        public static bool DeleteFile(string FilePath)
        {
            FileInfo finfo = new FileInfo(FilePath);
            if (finfo.Exists)
                try
                {
                    finfo.Delete();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            return false;
        }

        public static bool DeleteDir(string DirectoryPath)
        {
            DirectoryInfo finfo = new DirectoryInfo(DirectoryPath);
            if (finfo.Exists)
                try
                {
                    finfo.Delete(true);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            return false;
        }
    }
}