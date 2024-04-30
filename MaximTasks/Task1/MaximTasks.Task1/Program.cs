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

            if (!result.Contains("Были введены не подходящие символы:"))
            {
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

                while (true)
                {
                    if (result == string.Empty)
                    {
                        break;
                    }

                    Console.WriteLine("Выберите алгоритм сортировки: \n" +
                                      "1 - быстрая сортировка\n" +
                                      "2 - сортировка деревом");
                    int.TryParse(Console.ReadLine(), out int sorting);


                    if (sorting == 1)
                    {
                        var sortedResult = SortingAlgorithms.QuickSort(result.ToCharArray(), 0, result.Length - 1);
                        Console.WriteLine($"Отсортированная строка - {sortedResult}");
                        break;
                    }
                    else if (sorting == 2)
                    {
                        var sortedResult = SortingAlgorithms.TreeSort(result.ToCharArray());
                        Console.WriteLine($"Отсортированная строка - {sortedResult}");
                        break;
                    }
                }
            }
        }
    }
}
