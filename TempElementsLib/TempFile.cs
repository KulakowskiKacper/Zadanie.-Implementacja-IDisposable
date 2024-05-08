using System;
using System.IO;
using System.IO.Pipes;
using System.Text;


namespace TempElementsLib
{
    public class TempFile : ITempFile
    {

        public bool IsDestroyed { get; set; }
        public string FilePath => fileInfo.FullName;

        public FileStream fileStream { get; }
        public FileInfo fileInfo { get; }

        public TempFile()
        {
            string tempPath = Path.GetTempFileName();
            fileInfo = new FileInfo(tempPath);
            fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.ReadWrite);
        }

        public TempFile(string path)
        {

            fileInfo = new FileInfo(path);
            fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
        }

        ~TempFile()
        {
            Dispose(false);
        }

        public void AddText(string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fileStream.Write(info, 0, info.Length);
            fileStream.Flush();
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
                fileStream.Close();
                fileInfo.Delete();
            }
            IsDestroyed = true;
        }
    }

}

