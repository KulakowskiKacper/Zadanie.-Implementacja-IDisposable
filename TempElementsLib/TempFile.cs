using System;
using System.IO;
using System.IO.Pipes;
using System.Text;


namespace TempElementsLib
{
    public class TempFile : ITempFile
    {

        public bool IsDestroyed { get; set; } //true, jeśli element skutecznie usunięty

        public string FilePath  //ścieżka do pliku
        {
            get
            {
                return fileInfo.FullName;
            }
            set
            {
            }
        }

        public FileStream fileStream { get; } 
        public FileInfo fileInfo { get; set; } //informacje o pliku

        public TempFile() //konstruktor tworzący plik tymczasowy w domyślnym katalogu
        {
            string tempPath = Path.GetTempFileName();
            fileInfo = new FileInfo(tempPath);
            fileStream = new FileStream(tempPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public TempFile(string path) //konstruktor tworzący plik tymczasowy w podanej lokalizacji
        {

            fileInfo = new FileInfo(path);
            fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
        }

        ~TempFile()  //destruktor
        {
            Dispose(false);
        }

        public void AddText(string value)  //dodaje tekst do pliku
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fileStream.Write(info, 0, info.Length);
            fileStream.Flush();
        }

        public void Dispose()  //usuwa plik
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)  
        {
            if (disposing)
            {
                fileInfo.Refresh();
                fileStream.Close();
                fileInfo.Delete();
            }
            IsDestroyed = true;
        }

        public void Close()  //zamyka strumień pliku
        {
            fileStream.Close();
        }

        public void MoveFile(string newPath)  //przenosi plik do nowej lokalizacji
        {
            File.Move(fileInfo.FullName, newPath);
            
        }

    }

}