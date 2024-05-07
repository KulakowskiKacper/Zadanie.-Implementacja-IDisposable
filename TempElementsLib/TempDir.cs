using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Reflection;
using System.Text;

namespace TempElementsLib
{
    public class TempDir : ITempDir
    {
        public bool IsDestroyed { get; set; }

        public bool IsEmpty { get; set; }

        public DirectoryInfo? DirectoryInfo { get; set; }
        public string DirPath => DirectoryInfo?.FullName;

        public TempDir()
        {
            DirectoryInfo = new DirectoryInfo(Path.GetTempPath());
        }

        public TempDir(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("Path cannot be null");
            }
            if (path == "")
            {
                throw new ArgumentException("Path cannot be empty");
            }
            Directory.CreateDirectory(path);
        }

        public void Empty()
        {
            try
            {
                DirectoryInfo?.Delete(true);
                DirectoryInfo?.Create();
            }
            catch (IOException)
            {
                
            }
            catch (UnauthorizedAccessException)
            {
                
            }
            finally
            {
                DirectoryInfo = null;
                IsEmpty = true;
            }
        }

        ~TempDir()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    DirectoryInfo?.Delete(true);
                }
                catch (IOException)
                {
                    
                }
                catch (UnauthorizedAccessException)
                {
                    
                }
                finally
                {
                    DirectoryInfo = null;
                }
            }
        }
    }
}

