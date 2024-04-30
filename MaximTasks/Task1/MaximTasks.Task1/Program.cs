using MaximTasks.Task1.Lib;

namespace MaximTasks.Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            string? input = Console.ReadLine();

            var result = StringUtilities.Transform(input);
            Console.WriteLine(result);

            var chars = StringUtilities.CalculateNumberChar(result);
            foreach (var c in chars)
            {
                Console.WriteLine($"Символ {c.Key} встречается в строке {c.Value} раз.");
            }

            var substring = StringUtilities.GetLongestSubstringVowel(result);
            if (substring != string.Empty)
            {
                Console.WriteLine($"Самая длинная подстрока начинающаяся и заканчивающаяся" +
                                  $" на гласную букву из «aeiouy»: {substring}");
            }
        }
    }
}
