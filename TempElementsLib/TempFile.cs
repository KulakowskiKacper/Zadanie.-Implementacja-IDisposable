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
            fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.ReadWrite);
            fileInfo = new FileInfo(tempPath);
            
        }

        public TempFile(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("Path cannot be null");
            }
            if (path == "")
            {
                throw new ArgumentException("Path cannot be empty");
            }
            fileInfo = new FileInfo(path);
            string directory = Path.GetDirectoryName(FilePath);
            if (!Directory.Exists(directory))
            {
                throw new DirectoryNotFoundException($"The directory of the provided file path does not exist: {directory}");
            }
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

