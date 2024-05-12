using System;
using TempElementsLib;
using System.IO;

namespace TempElementsConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("Testowanie przy użyciu konsoli wymienionych założeń z zadania 1:");
            //Console.ResetColor();
            //Console.WriteLine("Tworzenie pliku przy użyciu \"standardowych\" komend");
            //TempFile tempFile = new TempFile();                                             // tworzenie pliku w domyslnej dla systemu/użytkownika lokalizacji i o losowej nazwie
            //Console.WriteLine(tempFile.FilePath);                                           // ścieżka dostępu do pliku
            //Console.WriteLine(tempFile.IsDestroyed);                                        // false
            //tempFile.Dispose();                                                             // usuwanie pliku
            //Console.WriteLine(tempFile.IsDestroyed);                                        // true
            //Console.WriteLine("Próba zapisu do pliku po jego zamknięciu:");
            //try
            //{
            //    tempFile.AddText("Hello World!");                                           // próba zapisu do plik
            //}
            //catch (Exception ex)                                                            // przechwytywanie wyjątku
            //{
            //    Console.WriteLine(ex.Message);                                              // wyświetlenie komunikatu o błędzie
            //}
            //Console.WriteLine("------------------------------------------------------------\nTworzenie pliku przy użyciu bloku using");
            //using (TempFile tempFile2 = new TempFile())                                     // tworzenie katalogu w domyslnej dla systemu/użytkownika lokalizacji
            //{
            //    Console.WriteLine(tempFile2.FilePath);                                      // ścieżka dostępu do pliku
            //    Console.WriteLine(tempFile2.IsDestroyed);                                   // false
            //}

            //Console.WriteLine("------------------------------------------------------------\nTworzenie pliku przy użyciu bloku try-catch-finally");     
            //TempFile tempFile3 = null;

            //try
            //{
            //    tempFile3 = new TempFile();
            //    tempFile3.AddText("Hello, World!");
            //    Console.WriteLine(tempFile3.FilePath);
            //    Console.WriteLine(tempFile3.IsDestroyed);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}");
            //}
            //finally
            //{
            //    tempFile3?.Dispose();
            //    Console.WriteLine(tempFile3.IsDestroyed);
            //}
            //Console.WriteLine("Próba zapisu do pliku po bloku try-catch-finally:");
            //try
            //{
            //    tempFile3.AddText("Hello, World!");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //Console.WriteLine("------------------------------------------------------------\nTworzenie pliku przy użyciu konstruktora z argumentem path przy użyciu bloku using");
            //using (TempFile tempFile4 = new TempFile($"D:{Path.DirectorySeparatorChar}PlikiTestowe{Path.DirectorySeparatorChar}test.tmp"))    // tworzenie pliku we wskazanym miejscu i o wskazanej nazwie
            //{
            //    Console.WriteLine(tempFile4.IsDestroyed);
            //    Console.WriteLine(tempFile4.FilePath);

            //}
            //Console.WriteLine("------------------------------------------------------------\nPróba utworzenia pliku przy użyciu niepoprawnej ścieżki używając bloku using");
            //try
            //{
            //    using (TempFile tempFile5 = new TempFile($"$D:{Path.DirectorySeparatorChar}PlikiTestowe{Path.DirectorySeparatorChar}test{Path.DirectorySeparatorChar}test"))
            //    {
            //        Console.WriteLine(tempFile5);
            //        Console.WriteLine(tempFile5.IsDestroyed);
            //        Console.WriteLine(tempFile5.FilePath);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}");
            //}
            //Console.WriteLine("Próba zapisu do pliku po bloku using:");

            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("Testowanie przy użyciu konsoli wymienionych założeń z zadania 2:");
            //Console.ResetColor();
            //TempTxtFile tempTxtFile = new TempTxtFile(@"D:\PlikiTestowe\test");                                     // tworzenie pliku tekstowego w domyslnej dla systemu/użytkownika lokalizacji i o losowej nazwie
            //Console.WriteLine($"Ścieżka dostępu do pliku:  {tempTxtFile.FilePath}");
            //Console.WriteLine($"Czy plik jest usunięty: {tempTxtFile.IsDestroyed}");
            //Console.WriteLine("Wpisanie tekstu do pliku za pomocą metody WriteLine:");
            //tempTxtFile.WriteLine("Linijka pierwsza");                                           // próba zapisu do pliku
            //tempTxtFile.Write("Linijka druga");
            //tempTxtFile.Close();
            //Console.WriteLine("Odczytanie tekstu z pliku za pomocą metody ReadLine:");
            //Console.WriteLine(tempTxtFile.ReadOneLine());
            //Console.WriteLine("Odczytanie tekstu z pliku za pomocą metody ReadAllText:");
            //Console.WriteLine(tempTxtFile.ReadAllText());
            //tempTxtFile.Dispose();
            //Console.WriteLine($"Czy plik jest usunięty: {tempTxtFile.IsDestroyed}");
            //Console.WriteLine("------------------------------------------------------------\nTworzenie pliku tekstowego przy użyciu bloku using");
            //using (TempTxtFile tempTxtFile2 = new TempTxtFile())                                     // tworzenie katalogu w domyslnej dla systemu/użytkownika lokalizacji
            //{
            //    Console.WriteLine($"Ścieżka dostępu do pliku:  {tempTxtFile2.FilePath}");
            //    tempTxtFile2.Close();
            //    Console.WriteLine($"Czy plik jest usunięty: {tempTxtFile2.IsDestroyed}");
            //}

            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("Testowanie przy użyciu konsoli wymienionych założeń z zadania 3:");
            //Console.ResetColor();
            //TempDir tempDir = new TempDir(@"D:\PlikiTestowe\folder");
            //Console.WriteLine($"Ścieżka dostępu do katalogu:  {tempDir.DirPath}");
            //Console.WriteLine($"Czy katalog jest pusty: {tempDir.IsEmpty}");
            //Console.WriteLine("Tworzenie pliku w katalogu:");
            //TempFile tempFileDir = new TempFile(@"D:\PlikiTestowe\folder\test.tmp");
            //Console.Write("Sprawdzanie czy folder jest pusty:");
            //Console.WriteLine(tempDir.IsEmpty);
            //Console.WriteLine("Usuwanie pliku z katalogu za pomocą metody Empty:");
            //tempFileDir.fileStream.Close();
            //tempDir.Empty();
            //Console.Write("Sprawdzanie czy folder jest pusty:");
            //Console.WriteLine(tempDir.IsEmpty);
            //Console.WriteLine("Usuwanie katalogu za pomocą metody Dispose:");
            //tempDir.Dispose();
            //Console.WriteLine($"Czy katalog jest usunięty: {tempDir.IsDestroyed}");
            //Console.WriteLine("Próba dostępu do katalogu po jego usunięciu:");
            //try
            //{
            //tempFileDir = new TempFile(@"D:\PlikiTestowe\folder\test.tmp");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //Console.WriteLine("------------------------------------------------------------\nTworzenie katalogu za pomocą bloku using:");
            //using (TempDir tempDir2 = new TempDir(@"D:\PlikiTestowe\folder"))
            //{
            //    Console.WriteLine($"Ścieżka dostępu do katalogu:  {tempDir2.DirPath}");
            //    Console.WriteLine($"Czy katalog jest pusty: {tempDir2.IsEmpty}");
            //}

            TempFile tempFile = new TempFile($@"D:\TempFile");
            TempDir tempDir = new TempDir($@"D:\TempDir");
            using (TempElementsList tempElementsList = new TempElementsList())
            {

                // Add elements with specific paths

                tempElementsList.AddExistingElement(tempFile);
                tempElementsList.AddExistingElement(tempDir);

                Console.WriteLine($"Number of elements after adding: {tempElementsList.Elements.Count}");


                // Move elements

                tempFile.Close();
                tempElementsList.MoveElementTo(tempFile, @"D:\PlikiTestowe2\");
                tempFile.fileInfo.Refresh();
                Console.WriteLine($"New File path: {tempFile.FilePath}");


                // Check if the list is empty
                Console.WriteLine($"Is the list empty: {tempElementsList.IsEmpty}");
                tempElementsList.DeleteElement(tempFile);
                Console.WriteLine($"Is the list empty: {tempElementsList.IsEmpty}");
                Console.WriteLine($"Number of elements after deleting: {tempElementsList.Elements.Count}");

            }

            tempDir.Dispose();
            tempFile.Dispose();

        }
    }
}
