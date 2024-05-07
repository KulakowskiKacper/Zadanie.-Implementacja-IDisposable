using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TempElementsLib
{
    public class TempTxtFile : TempFile
    {
        private StreamWriter? streamWriter;
        private StreamReader? streamReader;

        public TempTxtFile() : base()
        {
            InitializeStreamObjects();
        }

        public TempTxtFile(string path) : base(path)
        {
            InitializeStreamObjects();
        }

        private void InitializeStreamObjects()
        {
            streamWriter = new StreamWriter(fileStream);
            streamReader = new StreamReader(fileStream);
        }


        public void Write(string text)
        {
            streamWriter.Write(text);
            streamWriter.Flush();
        }

        public void WriteLine(string text)
        {
            streamWriter.WriteLine(text);
            streamWriter.Flush();
        }

        public string ReadLine()
        {
            return streamReader.ReadLine();
        }

        public string ReadAllText()
        {
            return streamReader.ReadToEnd();
        }

        public override void Dispose()
        {
            streamWriter?.Close();
            streamReader?.Close();
            base.Dispose();
        }
    }
}
