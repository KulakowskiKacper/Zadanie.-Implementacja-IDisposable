using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TempElementsLib
{
    public class TempTxtFile : TempFile
    {
        public string FilePath => fileInfo.FullName;
        public TextReader txtReader { get; }
        public TextWriter txtWriter { get; }

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

        public void ReadAllText()
        {
            txtReader.ReadToEnd();
            txtReader.Dispose();

        }

        public void ReadLine()
        {
            txtReader.ReadLine();
            txtReader.Dispose();
        }

        public TempTxtFile() : base()
        {
        }

        public TempTxtFile(string path) : base(path)
        {
        }

        public void Write(string text)
        {
            txtWriter.Write(text);
            txtWriter.Flush();
        }

        public void WriteLine(string text)
        {
            txtWriter.WriteLine(text);
            txtWriter.Flush();
        }


    }
}
