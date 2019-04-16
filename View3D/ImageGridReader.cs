namespace View3D
{
    using System;
    using System.Diagnostics;
    using System.IO;

    internal class ImageGridReader
    {
        private string _BaseURL;
        public string[,] _Images;
        private int _rows;

        public ImageGridReader(string MainDirectory)
        {
            this._BaseURL = MainDirectory;
            Refresh();
        }
        public bool Validate3Dfolder( int Rows)
        {
            DirectoryInfo info = new DirectoryInfo(_BaseURL);
            if (info.Exists)
            {
                DirectoryInfo[] directories = info.GetDirectories();
                int rows = directories.Length;
                if (rows < Rows)
                {
                    Debug.WriteLine("Error in the file row counts in selected folder ");
                    return false;
                }
                string[,] Images = new string[rows, 30];
                int num = 0;
                foreach (DirectoryInfo info2 in directories)
                {
                    FileInfo[] files = info2.GetFiles("*.jpg");
                    int num2 = 0;
                    foreach (FileInfo info3 in files)
                    {
                        Images[num, num2] = info3.FullName;
                        num2++;
                    }
                    if (num2 < 30)
                    {
                        Debug.WriteLine("Error in the file count in folder " + info2.Name);
                        return false;
                    }
                    num++;
                }
                Debug.Write("Done");
                return true;
            }
            return false;
        }
        public void Refresh()
        {
            DirectoryInfo info = new DirectoryInfo(this._BaseURL);
            if (info.Exists)
            {
                DirectoryInfo[] directories = info.GetDirectories();
                this._rows = directories.Length;
                this._Images = new string[this._rows, 30];
                int num = 0;
                foreach (DirectoryInfo info2 in directories)
                {
                    FileInfo[] files = info2.GetFiles("*.jpg");
                    int num2 = 0;
                    foreach (FileInfo info3 in files)
                    {
                        this._Images[num, num2] = info3.FullName;
                        num2++;
                    }
                    num++;
                }
                Debug.Write("Done");
            }
        }
    }
}

