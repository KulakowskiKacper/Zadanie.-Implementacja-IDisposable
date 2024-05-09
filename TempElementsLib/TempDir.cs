using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Reflection;
using System.Text;

namespace TempElementsLib
{
    public class TempDir : ITempDir
    {
        private bool isEmpty;

        public string DirPath => dirInfo.FullName;

        public bool IsEmpty 
            {
                get
            {
                    if (dirInfo.GetFileSystemInfos().Length == 0)
                {
                        isEmpty = true;
                    }
                    else
                {
                        isEmpty = false;
                    }
                    return isEmpty;
                }
            set => isEmpty = value;
            }

        public bool IsDestroyed { get; set; }

        public DirectoryInfo dirInfo { get; }

        ~TempDir()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                dirInfo.Delete(true);
            }
            IsDestroyed = true;
        }

        public void Empty()
        {
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public TempDir()
        {
            string tempPath = Path.GetTempPath();
            dirInfo = new DirectoryInfo(tempPath);
        }

        public TempDir(string path)
        {
            Directory.CreateDirectory(path);
            dirInfo = new DirectoryInfo(path);
        }
    }
}

