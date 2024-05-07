using System;
using TempElementsLib;
using System.IO;

namespace TempElementsConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Testowanie przy użyciu konsoli wymienionych założeń z zadania 1:");
            Console.ResetColor();
            Console.WriteLine("Tworzenie pliku przy użyciu \"standardowych\" komend");
            TempFile tempFile = new TempFile();                                             // tworzenie pliku w domyslnej dla systemu/użytkownika lokalizacji i o losowej nazwie
            Console.Write("Ścieżka dostępu do pliku: ");
            Console.WriteLine(tempFile.FilePath);                                           // ścieżka dostępu do pliku
            Console.WriteLine("Wykonanie metody Dispose:");
            Console.WriteLine("Przed:");
            Console.WriteLine(tempFile.IsDestroyed);                                        // false
            tempFile.Dispose();                                                             // usuwanie pliku
            Console.WriteLine("Po:");
            Console.WriteLine(tempFile.IsDestroyed);                                        // true
            Console.WriteLine("Próba zapisu do pliku po jego zamknięciu:");
            try
            {
                tempFile.AddText("Hello World!");                                           // próba zapisu do plik
            }
            catch (Exception ex)                                                            // przechwytywanie wyjątku
            {
                Console.WriteLine(ex.Message);                                              // wyświetlenie komunikatu o błędzie
            }
            Console.WriteLine("------------------------------------------------------------\nTworzenie pliku przy użyciu bloku using: ");
            using (TempFile tempFile2 = new TempFile())                                     // tworzenie katalogu w domyslnej dla systemu/użytkownika lokalizacji
            {
                Console.Write("Ścieżka dostępu do pliku: ");
                Console.WriteLine(tempFile2.FilePath);                                      // ścieżka dostępu do pliku
                Console.WriteLine(tempFile2.IsDestroyed);                                   // false
            }
            Console.WriteLine("Próba zapisu do pliku po bloku using:");
            try
            {
                tempFile.AddText("Hello World!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("------------------------------------------------------------\nTworzenie pliku przy użyciu bloku try-catch-finally:");
            TempFile tempFile3 = null;

            try
            {
                tempFile3 = new TempFile();
                tempFile3.AddText("Hello, World!");
                Console.WriteLine(tempFile3.FilePath);
                Console.WriteLine(tempFile3.IsDestroyed);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                tempFile3?.Dispose();
                Console.WriteLine(tempFile3.IsDestroyed);
            }

            Console.WriteLine("------------------------------------------------------------\nTworzenie pliku przy użyciu konstruktora z argumentem path przy użyciu bloku using:");
            using (TempFile tempFile4 = new TempFile($"D:{Path.DirectorySeparatorChar}PlikiTestowe{Path.DirectorySeparatorChar}test.tmp"))    // tworzenie pliku we wskazanym miejscu i o wskazanej nazwie
            {
                Console.WriteLine(tempFile4);
                Console.WriteLine(tempFile4.IsDestroyed);
                Console.Write("Ścieżka dostępu do pliku: ");
                Console.WriteLine(tempFile4.FilePath);
                tempFile4.Dispose();
                Console.WriteLine(tempFile4.IsDestroyed);

            }
            Console.WriteLine("------------------------------------------------------------\nPróba utworzenia pliku przy użyciu niepoprawnej ścieżki używając bloku using");
            try
            {
                using (TempFile tempFile5 = new TempFile($"$D:{Path.DirectorySeparatorChar}PlikiTestowe{Path.DirectorySeparatorChar}test{Path.DirectorySeparatorChar}test"))
                {
                    Console.WriteLine(tempFile5);
                    Console.WriteLine(tempFile5.IsDestroyed);
                    Console.WriteLine(tempFile5.FilePath);
                    tempFile5.Dispose();
                    Console.WriteLine(tempFile5.IsDestroyed);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTestowanie przy użyciu konsoli wymienionych założeń z zadania 2:");
            Console.ResetColor();
            Console.WriteLine("Tworzenie tymczasowego pliku tekstowego przy użyciu bloku using:");
            using (TempTxtFile tempTxtFile = new TempTxtFile())
            {
                Console.Write("Ścieżka do pliku: ");
                Console.WriteLine(tempTxtFile.FilePath);
                Console.WriteLine("Dodanie przy pomocy Write, a następnie odczytanie przy pomocy ReadLine, tekstu \"test\"");
                tempTxtFile.Write("test");
                tempTxtFile.fileStream.Position = 0;
                Console.WriteLine(tempTxtFile.ReadLine());
                Console.WriteLine("Dodanie przy pomocy WriteLine, a następnie odczytanie przy pomocy ReadAllText, tekstu \"test2 \"");
                tempTxtFile.WriteLine("test2 ");
                tempTxtFile.fileStream.Position = 0;
                Console.WriteLine(tempTxtFile.ReadAllText());
                Console.WriteLine("Dodanie tekstu \"test3\" przy pomocy Write w celu sprawdzenia czy zapisze się w nowej linijce");
                tempTxtFile.Write("test3");
                tempTxtFile.fileStream.Position = 0;
                Console.WriteLine(tempTxtFile.ReadAllText());
            }

        }
    }
}
