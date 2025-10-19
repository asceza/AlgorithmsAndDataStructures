using System;

namespace InsertionSort
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] array = { 12, 11, 13, 5, 6 };
            Console.WriteLine("Original array:");
            PrintArray(array);

            InsertionSort(array);

            Console.WriteLine("\nSorted array:");
            PrintArray(array);
        }

        /// <summary>
        /// Сортирует массив целых чисел с использованием алгоритма сортировки вставками.
        /// </summary>
        /// <param name="array">Массив для сортировки.</param>
        static void InsertionSort(int[] array)
        {
            // Начинаем со второго элемента, так как первый элемент уже считается отсортированным
            for (int i = 1; i < array.Length; i++)
            {
                // Выбираем текущий элемент для вставки в отсортированную часть массива
                int key = array[i];
                int j = i - 1;

                // Перемещаем элементы отсортированной части, которые больше ключа,
                // на одну позицию вправо, чтобы освободить место для ключа
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                // Вставляем ключ в правильное место в отсортированной части массива
                array[j + 1] = key;
            }
        }

        /// <summary>
        /// Выводит элементы целочисленного массива в консоль.
        /// </summary>
        /// <param name="array">Массив для вывода.</param>
        static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}