using System;

namespace ShellSort
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] array = { 12, 34, 54, 2, 3 };
            Console.WriteLine("Original array:");
            PrintArray(array);

            ShellSort(array);

            Console.WriteLine("\nSorted array:");
            PrintArray(array);
        }

        /// <summary>
        /// Сортирует массив методом Шелла.
        /// </summary>
        /// <param name="array">Сортируемый массив.</param>
        static void ShellSort(int[] array)
        {
            // Начинаем с большого шага, затем уменьшаем его
            for (int gap = array.Length / 2; gap > 0; gap /= 2)
            {
                // Выполняем сортировку вставками для этого шага
                for (int i = gap; i < array.Length; i++)
                {
                    // Сохраняем array[i] во временную переменную и создаем "дыру" в позиции i
                    int temp = array[i];

                    // Сдвигаем ранее отсортированные элементы вверх, пока не будет найдено правильное место для temp
                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }

                    // Помещаем temp (исходный array[i]) в его правильное место
                    array[j] = temp;
                }
            }
        }

        /// <summary>
        /// Выводит элементы массива в консоль.
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