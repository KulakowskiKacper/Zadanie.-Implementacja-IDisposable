using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TempElementsLib;

namespace TempElementsLib
{
    public class TempElementsList : ITempElements
    {


        private bool disposed;  //true, jeśli element został usunięty 
        private readonly List<ITempElement> elements = new List<ITempElement>();  //lista elementów tymczasowych

        public IReadOnlyCollection<ITempElement> Elements => elements;  //lista elementów tymczasowych

        public T AddElement<T>() where T : ITempElement, new()  //dodaje nowy element do listy
        {
            var element = new T();
            elements.Add(element);
            return element;
        }
        public void AddExistingElement(ITempElement element)  //dodaje istniejący element do listy
        {
            elements.Add(element);
        }

        public void DeleteElement<T>(T element) where T : ITempElement, new()  //usuwa element z listy
        {
            if (elements.Contains(element))
            {
                element.Dispose();
                elements.Remove(element);
            }
        }

        public void MoveElementTo<T>(T element, string newPath) where T : ITempElement, new()  //przenosi element do nowej lokalizacji
        {
            if (element is TempFile file)
            {
                File.Move(file.FilePath, newPath + file.fileInfo.Name);
            }
            else if (element is DirectoryInfo directoryInfo)
            {
                Directory.Move(directoryInfo.FullName, newPath);
            }
        }

        public void RemoveDestroyed()  //usuwa zniszczone elementy z listy
        {
            elements.RemoveAll(element => element.IsDestroyed);
        }

        public bool IsEmpty => !elements.Any();  //true, jeśli lista jest pusta

        protected virtual void Dispose(bool disposing)
        {

            if (disposing)
            {
                foreach (var element in elements)
                {
                    element.Dispose();
                }
                elements.Clear();
            }
            disposed = true;

        }
        public void Dispose()  //usuwa liste
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

    }

}

