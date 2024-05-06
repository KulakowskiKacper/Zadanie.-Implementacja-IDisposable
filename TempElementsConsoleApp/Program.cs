using System;
using TempElementsLib;
using System.IO;

namespace TempElementsConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tworzenie pliku przy użyciu \"standardowych\" komend");
            TempFile tempFile = new TempFile();                                             // tworzenie pliku w domyslnej dla systemu/użytkownika lokalizacji i o losowej nazwie
            Console.WriteLine(tempFile.FilePath);                                           // ścieżka dostępu do pliku
            Console.WriteLine(tempFile.IsDestroyed);                                        // false
            tempFile.Dispose();                                                             // usuwanie pliku
            Console.WriteLine(tempFile.IsDestroyed);                                        // true
            Console.WriteLine("Próba zapisu do pliku po jego zamknięciu");
            try
            {
                tempFile.AddText("Hello World!");                                           // próba zapisu do plik
            }
            catch (Exception ex)                                                            // przechwytywanie wyjątku
            {
                Console.WriteLine(ex.Message);                                              // wyświetlenie komunikatu o błędzie
            }
            Console.WriteLine("\nTworzenie pliku przy użyciu bloku using");
            using (TempFile tempFile2 = new TempFile())                                     // tworzenie katalogu w domyslnej dla systemu/użytkownika lokalizacji
            {
                Console.WriteLine(tempFile2.FilePath);                                      // ścieżka dostępu do pliku
                Console.WriteLine(tempFile2.IsDestroyed);                                   // false
                                                                                            // usuwanie pliku

            }
            Console.WriteLine("\nTworzenie pliku przy użyciu bloku try-catch-finally");
            TempFile tempFile3 = new TempFile();                                            // tworzenie pliku w domyslnej dla systemu/użytkownika lokalizacji i o losowej nazwie
            try                                                                             // blok try-catch
            {
                Console.WriteLine(tempFile3.FilePath);                                      // ścieżka dostępu do pliku
                Console.WriteLine(tempFile3.IsDestroyed);                                   // false
                tempFile3.AddText("Hello World!");                                          // zapis do pliku
                Console.WriteLine(tempFile3.IsDestroyed);                                   // false
            }
            catch (Exception ex)                                                            // przechwytywanie wyjątku
            {
                Console.WriteLine(ex.Message);                                              // wyświetlenie komunikatu o błędzie
            }
            finally                                                                         // blok finally
            {
                tempFile3.Dispose();                                                        // usuwanie pliku
                Console.WriteLine(tempFile3.IsDestroyed);                                   // true
            }

        }
    }
}
