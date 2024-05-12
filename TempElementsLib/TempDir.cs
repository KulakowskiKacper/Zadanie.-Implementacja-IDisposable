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
        private bool isEmpty;  //true, jeśli katalog jest pusty

        public string DirPath  //ścieżka do katalogu
        {
            get
            {
                return dirInfo.FullName;
            }
            set
            {
            }
        }

        public bool IsEmpty   //true, jeśli katalog jest pusty
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

        public bool IsDestroyed { get; set; }  //true, jeśli element skutecznie usunięty

        public DirectoryInfo dirInfo { get; }  //informacje o katalogu

        ~TempDir()  //destruktor
        {
            Dispose(false);
        }

        public void Dispose()  //usuwa katalog
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!IsDestroyed)
            {
                if (disposing)
                {
                    Empty();
                    Directory.Delete(dirInfo.FullName, true);
                }
                IsDestroyed = true;
            }
        }


        public void Empty()  //usuwa wszystkie pliki i katalogi z katalogu
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

        public void Close()  //zamyka katalog
        {
            dirInfo.Delete(true);
        }

        public TempDir()  //konstruktor tworzący katalog tymczasowy w domyślnym katalogu
        {
            string tempPath = Path.GetTempPath();
            dirInfo = new DirectoryInfo(tempPath);
        }

        public TempDir(string? pathToDir)  //konstruktor tworzący katalog tymczasowy w podanej lokalizacji
        {
            Directory.CreateDirectory(pathToDir);
            dirInfo = new DirectoryInfo(pathToDir);

        }
    }
}

