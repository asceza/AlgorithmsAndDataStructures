// C# implementation of Cocktail Sort
using System;

namespace CocktailSort
{
    internal class Program
    {
        // Точка входа в программу
        private static void Main(string[] args)
        {
            // Инициализируем неотсортированный массив
            int[] array = { 5, 1, 4, 2, 8, 0, 2, 7, 3, 6, 9 };

            Console.WriteLine("Исходный массив:");
            PrintArray(array);

            // Вызываем метод шейкерной сортировки
            CocktailSortAlgorithm(array);

            Console.WriteLine(); // Перенос строки для лучшего форматирования
            Console.WriteLine("Отсортированный массив:");
            PrintArray(array);

            Console.ReadKey();
        }

        /// <summary>
        /// Реализует алгоритм шейкерной (коктейльной) сортировки.
        /// </summary>
        /// <param name="array">Массив для сортировки.</param>
        private static void CocktailSortAlgorithm(int[] array)
        {
            // 'swapped' отслеживает, были ли обмены в текущей итерации.
            // Если обменов не было, массив уже отсортирован.
            bool swapped = true;
            // 'start' - начальный индекс для прохода слева направо.
            int start = 0;
            // 'end' - конечный индекс для прохода справа налево.
            int end = array.Length;

            while (swapped == true)
            {
                // Сбрасываем флаг 'swapped' в начале каждой итерации.
                // Если после двух проходов он останется false, значит, обменов не было.
                swapped = false;

                // --- Проход слева направо (как в обычной пузырьковой сортировке) ---
                // Перемещаем самый большой элемент из неотсортированной части в конец.
                for (int i = start; i < end - 1; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        // Обмен элементов
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        // Устанавливаем флаг, так как произошел обмен.
                        swapped = true;
                    }
                }

                // Если после первого прохода обменов не было, массив уже отсортирован.
                // Выходим из цикла.
                if (swapped == false)
                    break;

                // Сбрасываем флаг для обратного прохода.
                swapped = false;

                // Уменьшаем 'end', так как самый большой элемент уже на своем месте.
                end = end - 1;

                // --- Проход справа налево ---
                // Перемещаем самый маленький элемент из неотсортированной части в начало.
                for (int i = end - 1; i > start; i--)
                {
                    if (array[i - 1] > array[i])
                    {
                        // Обмен элементов
                        int temp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = temp;
                        // Устанавливаем флаг, так как произошел обмен.
                        swapped = true;
                    }
                }

                // Увеличиваем 'start', так как самый маленький элемент уже на своем месте.
                start = start + 1;
            }
        }

        /// <summary>
        /// Вспомогательный метод для вывода массива в консоль.
        /// </summary>
        private static void PrintArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}