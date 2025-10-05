namespace SelectionSort
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] numbers = { 64, 25, 12, 22, 11 };
            SelectionSort(numbers);
            Console.WriteLine(string.Join(", ", numbers)); // Вывод: 11, 12, 22, 25, 64
        }

        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                // Обмен местами
                (array[i], array[minIndex]) = (array[minIndex], array[i]);
            }
        }
    }
}