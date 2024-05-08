using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TempElementsLib
{
    public class TempTxtFile : TempFile
    {

        ~TempTxtFile()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public override void Dispose(bool disposing)
        {
            if (disposing)
            {
                fileStream?.Close();
                fileInfo?.Delete();
            }
            IsDestroyed = true;
        }

        public TempTxtFile() : base()
        {
        }

        public TempTxtFile(string path) : base(path)
        {
        }

        public void Write(string text)
        {
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(text);
                writer.Flush();
                fileStream.Position = 0;
            }
        }

        public string ReadAllText()
        {
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string text = reader.ReadToEnd();
                fileStream.Position = 0;
                return text;
            }
        }
    }
}
