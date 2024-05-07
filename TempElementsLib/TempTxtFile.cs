using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TempElementsLib
{
    public class TempTxtFile : TempFile
    {
        private TextReader? txtReader;
        private TextWriter? txtWriter;
        private FileStream fileStream;


        ~TempTxtFile()
        {
            Dispose(false);

        }

        public TempTxtFile() : base()
        {
            fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite);
            txtReader = new StreamReader(fileStream);
            txtWriter = new StreamWriter(fileStream);
        }

        public TempTxtFile(string path) : base(path)
        {
            txtReader = new StreamReader(fileStream);
            txtWriter = new StreamWriter(fileStream);
        }

        public void Write(string text)
        {
            txtWriter?.Write(text);
        }
        
        public void WriteLine(string text)
        {
            txtWriter?.WriteLine(text);
            txtWriter?.Flush();
        }

        public string ReadLine()
        {
            return txtReader?.ReadLine();
        }

        public string ReadAllText()
        {
            return txtReader?.ReadToEnd();
        }

        public override void Dispose()
        {
            txtReader?.Dispose();
            txtWriter?.Dispose();
            base.Dispose();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                txtReader?.Dispose();
                txtWriter?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
