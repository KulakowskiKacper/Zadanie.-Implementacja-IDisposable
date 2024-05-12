using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TempElementsLib
{
    public class TempTxtFile : TempFile
    {
        public string FilePath => fileInfo.FullName;  //ścieżka do pliku
        public FileStream fileStream { get; set; }
        public FileInfo fileInfo { get; set; }
        public bool IsDestroyed { get; set; }  //true, jeśli element skutecznie usunięty

        ~TempTxtFile()  //destruktor
        {
            Dispose(false);
        }

        public void Dispose()  //usuwa plik
        {
            fileStream?.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                fileStream?.Close();
                fileInfo?.Delete();
                File.Delete(fileInfo.FullName);
            }
            if (fileInfo != null)
            {
                fileInfo.Delete();
                fileInfo = null;
            }
            IsDestroyed = true;
        }

        public string ReadAllText()  //odczytuje cały tekst z pliku
        {
            string text = File.ReadAllText(fileInfo.FullName);
            return text;
        }

        public string ReadOneLine()  //odczytuje pierwszą linię z pliku
        {
            string firstLine = File.ReadLines(fileInfo.FullName).FirstOrDefault();
            return firstLine;
        }

        public TempTxtFile()  //konstruktor tworzący plik tymczasowy w domyślnym katalogu
        {
            fileStream = new FileStream(Path.GetTempFileName() + ".txt", FileMode.Create, FileAccess.ReadWrite);
            fileInfo = new FileInfo(fileStream.Name);
        }

        public TempTxtFile(string path)  //konstruktor tworzący plik tymczasowy w podanej lokalizacji
        {
            fileStream = new FileStream(path + ".txt", FileMode.Create, FileAccess.ReadWrite);
            fileInfo = new FileInfo(fileStream.Name);
        }


        public void Close()  //zamyka plik
        {
            fileStream.Close();
        }

        public void Write(string value)  //zapisuje tekst do pliku
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fileStream.Write(info, 0, info.Length);
            fileStream.Flush();
        }

        public void WriteLine(string value)  //zapisuje tekst do pliku z nową linią
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value + Environment.NewLine);
            fileStream.Write(info, 0, info.Length);
            fileStream.Flush();
        }

    }
}
