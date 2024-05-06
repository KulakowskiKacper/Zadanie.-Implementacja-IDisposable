using System;
using System.IO;
using System.IO.Pipes;
using System.Text;


namespace TempElementsLib
{
    public class TempFile : ITempFile
    {

        public bool IsDestroyed { get; private set; }
        public string FilePath => fileInfo.FullName;

        public readonly FileStream fileStream;
        public readonly FileInfo fileInfo;

        public TempFile()
        {
            string tempPath = Path.GetTempFileName();
            fileStream = new FileStream(tempPath, FileMode.Open, FileAccess.ReadWrite);
            fileInfo = new FileInfo(tempPath);
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

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDestroyed)
            {
                if (disposing)
                {
                    fileStream?.Close();
                    fileInfo?.Delete();
                }
                IsDestroyed = true;
            }
        }
    }

}

