using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* 
 * ANSI TEXT COLOR CODES
 * [0m - обычный шрифт
 * [30m - черный
 * [31m - красный
 * [32m - зеленый
 * [34m - голубой
 * [35m - маджента
 * [35m - циан
 * [37m - белый
*/
namespace RabinKarp
{
    internal class GetFileContent
    {
        static string RED_C = "\u001b[31m";
        static string GREEN_C = "\u001b[32m";
        static string YELLOW_C = "\u001b[33m";
        static string BLUE_C = "\u001b[34m";
        static string MAGENTA_C = "\u001b[35m";
        static string CYAN_C = "\u001b[36m";
        static string WHITE_C = "\u001b[37m";
        static string RESET = "\u001b[0m";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">путь к файлу</param>
        /// <param name="pattern">искомое слово</param>
        /// <returns></returns>
        public static string SearchAndHighLight(string filePath, string pattern)
        {
            string fileText = ReadFile(filePath);
            StringBuilder highlightedText = new StringBuilder();
            List<int> positions = FindOccurreces(fileText, pattern);

            if (positions.Count == 0)
            {
                return "Слово не найдено";
            }

            int currentIndex = 0;
            foreach (int pos in positions)
            {
                highlightedText.Append(fileText.Substring(currentIndex, pos-currentIndex));
                //  Console.Foregrond нет, держимся на ANSI форматировании
                highlightedText.Append(CYAN_C + fileText.Substring(pos, pattern.Length) + RESET);
                currentIndex = pos + pattern.Length;
            }
            highlightedText.Append(fileText.Substring(currentIndex));

            return highlightedText.ToString();
        }

        /// <summary>
        /// Считываем весь текст с файла и конверитрует его в строку
        /// </summary>
        /// <param name="filePath">путь к файлу</param>
        /// <returns></returns>
        private static string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        /// <summary>
        /// Список индексированных позиций слов совпадений
        /// </summary>
        /// <param name="fileText">текст файла</param>
        /// <param name="pattern">искомый файл</param>
        /// <returns></returns>
        private static List<int> FindOccurreces(string fileText, string pattern)
        {
            List<int> occurrecesPos = new List<int>();  //   позиция где начинается найденный паттерн
            string patternHASH = HashSHA256.GetHash(pattern);

            for (int i = 0; i <= fileText.Length - pattern.Length; i++)
            {
                string substring = fileText.Substring(i, pattern.Length);
                string substringHASH = HashSHA256.GetHash(substring);
                if (substringHASH == patternHASH)
                {
                    occurrecesPos.Add(i);
                }
            }
            return occurrecesPos;
        }
    }
}
