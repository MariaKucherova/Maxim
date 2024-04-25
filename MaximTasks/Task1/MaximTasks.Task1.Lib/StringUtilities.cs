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
        /// <returns>Возвращает обработанную строку.</returns>
        public static string Transform(string str)
        {
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
    }
}
