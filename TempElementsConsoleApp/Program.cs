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
            Console.WriteLine(tempFile.FilePath);                                           // ścieżka dostępu do pliku
            Console.WriteLine(tempFile.IsDestroyed);                                        // false
            tempFile.Dispose();                                                             // usuwanie pliku
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
            Console.WriteLine("------------------------------------------------------------\nTworzenie pliku przy użyciu bloku using");
            using (TempFile tempFile2 = new TempFile())                                     // tworzenie katalogu w domyslnej dla systemu/użytkownika lokalizacji
            {
                Console.WriteLine(tempFile2.FilePath);                                      // ścieżka dostępu do pliku
                Console.WriteLine(tempFile2.IsDestroyed);                                   // false
            }

            Console.WriteLine("------------------------------------------------------------\nTworzenie pliku przy użyciu bloku try-catch-finally");     
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
            Console.WriteLine("Próba zapisu do pliku po bloku try-catch-finally:");
            try
            {
                tempFile3.AddText("Hello, World!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("------------------------------------------------------------\nTworzenie pliku przy użyciu konstruktora z argumentem path przy użyciu bloku using");
            using (TempFile tempFile4 = new TempFile($"D:{Path.DirectorySeparatorChar}PlikiTestowe{Path.DirectorySeparatorChar}test.tmp"))    // tworzenie pliku we wskazanym miejscu i o wskazanej nazwie
            {
                Console.WriteLine(tempFile4);
                Console.WriteLine(tempFile4.IsDestroyed);
                Console.WriteLine(tempFile4.FilePath);

            }
            Console.WriteLine("------------------------------------------------------------\nPróba utworzenia pliku przy użyciu niepoprawnej ścieżki używając bloku using");
            try
            {
                using (TempFile tempFile5 = new TempFile($"$D:{Path.DirectorySeparatorChar}PlikiTestowe{Path.DirectorySeparatorChar}test{Path.DirectorySeparatorChar}test"))
                {
                    Console.WriteLine(tempFile5);
                    Console.WriteLine(tempFile5.IsDestroyed);
                    Console.WriteLine(tempFile5.FilePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.WriteLine("Próba zapisu do pliku po bloku using:");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Testowanie przy użyciu konsoli wymienionych założeń z zadania 2:");
            Console.ResetColor();

        }
    }
}
