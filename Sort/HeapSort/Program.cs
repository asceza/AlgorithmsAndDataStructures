using System;

namespace Heapsort
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Исходный массив для сортировки
            int[] array = { 5, 12, 8, 1, 19, 4, 6, 3, 7 };

            Console.WriteLine("Исходный массив:");
            PrintArray(array);

            // Выполняем пирамидальную сортировку
            HeapSort(array);

            Console.WriteLine("\nОтсортированный массив:");
            PrintArray(array);
        }

        /// <summary>
        /// Пирамидальная сортировка
        /// </summary>
        /// <param name="array">Массив для сортировки</param>
        public static void HeapSort(int[] array)
        {
            int n = array.Length;

            // Построение кучи (перегруппируем массив)
            // Начинаем с последнего узла, у которого есть дочерние элементы
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i);
            }

            // Один за другим извлекаем элементы из кучи
            for (int i = n - 1; i >= 0; i--)
            {
                // Перемещаем текущий корень в конец
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                // вызываем heapify на уменьшенной куче
                Heapify(array, i, 0);
            }
        }

        /// <summary>
        /// Преобразование в двоичную кучу поддерева с корневым узлом i,
        /// что является индексом в array[]. n - размер кучи
        /// </summary>
        /// <param name="array">Массив</param>
        /// <param name="n">Размер кучи</param>
        /// <param name="i">Корневой узел</param>
        private static void Heapify(int[] array, int n, int i)
        {
            // Инициализируем наибольший элемент как корень
            int largest = i;
            // левый = 2*i + 1
            int left = 2 * i + 1;
            // правый = 2*i + 2
            int right = 2 * i + 2;

            // Если левый дочерний элемент больше корня
            if (left < n && array[left] > array[largest])
            {
                largest = left;
            }

            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
            if (right < n && array[right] > array[largest])
            {
                largest = right;
            }

            // Если самый большой элемент не корень
            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                Heapify(array, n, largest);
            }
        }

        /// <summary>
        /// Вывод массива в консоль
        /// </summary>
        /// <param name="array">Массив для вывода</param>
        public static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}