namespace MaximTasks.Task1.WebAPI
{
    /// <summary>
    /// Тело ответа.
    /// </summary>
    public class StringResponse
    {
        /// <summary>
        /// Обработанная строка.
        /// </summary>
        public string? Result { get; set; }

        /// <summary>
        /// Словарь, содержащий информацию о том, сколько раз входил в обработанную
        /// строку каждый символ.
        /// </summary>
        public Dictionary<char, int>? Chars { get; set; }

        /// <summary>
        /// Самая длинная подстрока начинающаяся и заканчивающаяся на гласную букву
        /// из «aeiouy».
        /// </summary>
        public string? Substring { get; set; }

        /// <summary>
        /// Отсортированная обработанная строка.
        /// </summary>
        public string? SortedResult { get; set; }

        /// <summary>
        /// «Урезанная» обработанная строка – обработанная строка без одного символа.
        /// </summary>
        public string? CutedResult { get; set; }
    }
}
