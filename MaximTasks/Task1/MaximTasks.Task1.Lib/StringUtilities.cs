namespace MaximTasks.Task1.Lib
{
    /// <summary>
    /// Функции для работы со строками.
    /// </summary>
    public static class StringUtilities
    {
        /// <summary>
        /// Если строка содержит чётное количество символов, то метод разделяет её 
        /// на две подстроки, каждая подстрока переворачивается и соединятся в одну строку.
        /// Если строка содержит нечётное количество символов, то метод переворачивает эту
        /// строку и к ней добавляет изначальную строку.
        /// </summary>
        /// <param name="str">Входная строка.</param>
        /// <returns>
        /// Возвращает обработанную строку или сообщение о том, что были введены не
        /// подходящие символы.
        /// </returns>
        public static string Transform(string str)
        {
            string notSuitableChars = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < '\u0061' || str[i] > '\u007A')
                {
                    if (notSuitableChars.Length == 0)
                    {
                        notSuitableChars += str[i];
                    }
                    else
                    {
                        notSuitableChars += $", {str[i]}";
                    }
                }
            }

            if (notSuitableChars.Length != 0)
            {
                return "Были введены не подходящие символы: " + notSuitableChars;
            }
            

            if (str.Length % 2 == 0)
            {
                var middleStr = str.Length / 2;

                var subStr1 = new string(str.Substring(0, middleStr).Reverse().ToArray());
                var subStr2 = new string(str.Substring(middleStr).Reverse().ToArray());
                
                return subStr1 + subStr2;
            }
            else
            {
                var reversedStr = new string(str.Reverse().ToArray());  

                return reversedStr + str;
            }
        }
        
        /// <summary>
        /// Вычисляет сколько раз встречается символ в строке.
        /// </summary>
        /// <param name="str">Входная строка.</param>
        /// <returns>
        /// Возвращает словарь, содержащий символы строки и количество их вхождений.
        /// </returns>
        public static Dictionary<char, int> CalculateNumberChar(string str)
        {
            var chars = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (!chars.ContainsKey(str[i]))
                {
                    chars.Add(str[i], 1);
                }
                else
                {
                    ++chars[str[i]];
                }
            }

            return chars;
        }

        /// <summary>
        /// Находит в строке наибольшую подстроку, которая начинается и заканчивается
        /// на гласную букву из «aeiouy».
        /// </summary>
        /// <param name="str">Входная строка.</param>
        /// <returns>
        /// Возвращает самую длинную подстроку начинающуеся и заканчивающуеся
        /// на гласную букву из «aeiouy» или пустую строку, если такая подстрока
        /// не найдена.
        /// </returns>
        public static string GetLongestSubstringVowel(string str)
        {
            var vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'y' };

            var firstVowel = str.IndexOfAny(vowels);
            var lastVowel = str.LastIndexOfAny(vowels);

            if (firstVowel != -1 && lastVowel != -1)
            {
                return str.Substring(firstVowel, lastVowel - firstVowel + 1);
            }
            else
            {
                return "";
            }
        }
    }
}
