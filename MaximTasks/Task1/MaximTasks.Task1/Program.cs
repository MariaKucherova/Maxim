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
        }
    }
}
