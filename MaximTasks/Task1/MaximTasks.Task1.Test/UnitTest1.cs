using MaximTasks.Task1.Lib;

namespace MaximTasks.Task1.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Тест Transform с четным количеством символов в строке.
        /// </summary>
        [Test]
        public void Transform_Even()
        {
            var result = StringUtilities.Transform("abcdef");
            Assert.That(result == "cbafed");
        }

        /// <summary>
        /// Тест Transform с нечетным количеством символов в строке.
        /// </summary>
        [Test]
        public void Transform_Odd()
        {
            var result = StringUtilities.Transform("abcde");
            Assert.That(result == "edcbaabcde");
        }

        /// <summary>
        /// Тест Transform на содержание не подходящих символов в строке.
        /// </summary>
        /// <param name="value">Входящая строка.</param>
        [TestCase("abc12")]
        [TestCase("a.34,as")]
        [TestCase(".dfda")]
        [Test]
        public void Transform_NotSuitableChars_ReturnErrorMessage(string value)
        {
            var result = StringUtilities.Transform(value);
            Assert.IsTrue(result.Contains("Были введены не подходящие символы: "));
        }

        /// <summary>
        /// Тест CalculateNumberChar.
        /// </summary>
        [Test]
        public void CalculateNumberChar_Test()
        {
            var result = StringUtilities.CalculateNumberChar("abcdderad");
            var chars = new Dictionary<char, int>()
            {
                { 'a', 2 },
                { 'b', 1 },
                { 'c', 1 },
                { 'd', 3 },
                { 'e', 1 },
                { 'r', 1 }
            };
            Assert.That(chars, Is.EqualTo(result));
        }

        /// <summary>
        /// Тест GetLongestSubstringVowel.
        /// </summary>
        /// <param name="value">Входящая строка.</param>
        /// <param name="output">
        /// Подстрока, которая начинается и заканчивается нагласную букву из «aeiouy».
        /// </param>
        [TestCase("cbafed", "afe")]
        [Test]
        public void GetLongestSubstringVowel_Test(string value, string output)
        {
            var result = StringUtilities.GetLongestSubstringVowel(value);
            Assert.That(result, Is.EqualTo(output));
        }

        /// <summary>
        /// Тест быстрой сортировки.
        /// </summary>
        /// <param name="value">Входящая строка.</param>
        [TestCase("cdehaed")]
        [Test]
        public void QuickSort_Test(string value)
        {
            var result = SortingAlgorithms.QuickSort(value.ToCharArray(), 0, value.Length - 1);
            Assert.IsTrue(result.Equals("acddeeh"));
        }

        /// <summary>
        /// Тест сортировки деревом.
        /// </summary>
        /// <param name="value">Входящая строка.</param>
        [TestCase("cdehaed")]
        [Test]
        public void TreeSort_Test(string value)
        {
            var result = SortingAlgorithms.TreeSort(value.ToCharArray());
            Assert.IsTrue(result.Equals("acddeeh"));
        }
    }
}