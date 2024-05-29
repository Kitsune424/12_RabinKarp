using System;

namespace RabinKarp
{
    class Program
    {
        private static void Main(string[] args)
        {
            string pattern;
            string path = "Revizor.txt";

            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не сущесвтует");
                return;
            }

            try
            {
                ConsoleKeyInfo K;
                do
                {
                    Console.Clear();
                    Console.Write("Введите слово для поиска: ");
                    pattern = Console.ReadLine();
                    Console.WriteLine(GetFileContent.SearchAndHighLight(path, pattern));

                    K = Console.ReadKey();
                }
                while (K.Key != ConsoleKey.Escape);
            }
            catch (Exception ex) { }
        }
    }
}