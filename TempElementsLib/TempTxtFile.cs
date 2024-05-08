using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TempElementsLib
{
    public class TempTxtFile : TempFile
    {
        public string FilePath => fileInfo.FullName;
        public FileStream fileStream { get; }
        public FileInfo fileInfo { get; }
        public bool IsDestroyed { get; set; }

        ~TempTxtFile()
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
                fileStream?.Close();
                fileInfo?.Delete();
            }
            IsDestroyed = true;
        }

        public TempTxtFile()
        {
            fileStream = new FileStream(Path.GetTempFileName() + ".txt", FileMode.Create, FileAccess.ReadWrite);
            fileInfo = new FileInfo(fileStream.Name);
        }

        public TempTxtFile(string path)
        {
            fileStream = new FileStream(path + ".txt", FileMode.Create, FileAccess.ReadWrite);
            fileInfo = new FileInfo(fileStream.Name);
        }


        public void Close()
        {
            fileStream.Close();
        }

    }
}
