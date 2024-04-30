namespace MaximTasks.Task1.Lib
{
    public static class SortingAlgorithms
    {
        /// <summary>
        /// Быстрая сортировка массива из символов.
        /// </summary>
        /// <param name="array">Массив символов.</param>
        /// <param name="left">Нижняя граница массива.</param>
        /// <param name="right">Верхняя граница массива.</param>
        /// <returns>Возвращает отсортированный массив.</returns>
        public static string QuickSort(char[] array, int left, int right)
        {
            if (left >= right)
            {
                return new String(array);
            }

            var pivot = GetPivot(array, left, right);
            QuickSort(array, left, pivot - 1);
            QuickSort(array, pivot + 1, right);

            return new String(array);
        }

        /// <summary>
        /// Выбирает опорный элемент.
        /// </summary>
        /// <param name="array">Массив символов.</param>
        /// <param name="left">Нижняя граница массива.</param>
        /// <param name="right">Верхняя граница массива.</param>
        /// <returns>Возвращает опорный элемент.</returns>
        private static int GetPivot(char[] array, int left, int right)
        {
            var pivot = left - 1;
            for (int i = left; i < right; i++)
            {
                if (array[i] < array[right])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[right]);
            return pivot;
        }

        /// <summary>
        /// Обменивает значения символов.
        /// </summary>
        /// <param name="x">Первый символ.</param>
        /// <param name="y">Второй символ.</param>
        private static void Swap(ref char x, ref char y)
        {
            var temp = x;
            x = y;
            y = temp;
        }

        /// <summary>
        /// Сортировка деревом массива из символов.
        /// </summary>
        /// <param name="array">Массив символов.</param>
        /// <returns>Возвращает отсортированную строку.</returns>
        public static string TreeSort(char[] array)
        {
            var tree = new TreeNode(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                tree.Insert(new TreeNode(array[i]));
            }

            return tree.ToString();
        }
    }
}
