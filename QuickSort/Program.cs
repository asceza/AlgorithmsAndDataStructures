namespace QuickSort
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] array = { 33, 10, 55, 71, 29, 3, 18, 41 };

            QuickSort(array);

            Console.WriteLine("Отсортированный массив:");
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }
        }

        /// <summary>
        /// Быстрая сортировка
        /// </summary>
        /// <param name="array"></param>
        private static void QuickSort(int[] array)
        {
            // Рекурсивную функцию сортировки на всем диапазоне массива
            QuickSortInternal(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Вспомогательный рекурсивный метод быстрой сортировки
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left">Индекс начала сортируемого подмассива</param>
        /// <param name="right">Индекс конца сортируемого подмассива</param>
        private static void QuickSortInternal(int[] array, int left, int right)
        {
            // Базовый случай рекурсии: если подмассив пуст или содержит один элемент, сортировка не нужна
            if (left >= right)
            {
                return;
            }

            // Выбираем опорный элемент, здесь выбирается средний элемент подмассива
            int pivot = array[(left + right) / 2];

            // Инициируем индексы для прохода с двух сторон
            int i = left;   // слева направо
            int j = right;  // справа налево

            // Пока левый индекс не прошел правый
            while (i <= j)
            {
                // Сдвигаем индекс i вправо, пока элементы меньше опорного
                while (array[i] < pivot)
                {
                    i++;
                }

                // Сдвигаем индекс j влево, пока элементы больше опорного
                while (array[j] > pivot)
                {
                    j--;
                }

                // Если индексы не пересеклись - меняем элементы местами
                if (i <= j)
                {
                    // Обмен элементов массива
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;

                    // Сдвигаем оба индекса для продолжения сортировки
                    i++;
                    j--;
                }
            }

            // Рекурсивно сортируем левую часть подмассива
            if (left < j)
            {
                QuickSortInternal(array, left, j);
            }

            // Рекурсивно сортируем правую часть подмассива
            if (i < right)
            {
                QuickSortInternal(array, i, right);
            }
        }
    }
}