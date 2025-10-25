namespace BubbleSort
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] arr = { 64, 34, 25, 12, 22, 11, 90, 5, 77, 1 };
            BubbleSort(arr);
        }

        private static void BubbleSort(int[] arr)
        {
            int length = arr.Length;

            // Внешний цикл для прохода по всему массиву
            for (int i = 0; i < length - 1; i++)
            {
                // Внутренний цикл для сравнения и обмена элементов
                // На каждой итерации внешнего цикла самый большой элемент "всплывает" в конец
                for (int j = 0; j < length - i - 1; j++)
                {
                    // Сравниваем соседние элементы
                    if (arr[j] > arr[j + 1])
                    {
                        // Если левый элемент больше правого, меняем их местами
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Отсортированный массив: ");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}