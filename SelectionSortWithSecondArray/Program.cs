namespace SelectionSortWithSecondArray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] numbers = { 64, 25, 12, 22, 11 };
            int[] sortedNumbers = SelectionSortWithSecondArray(numbers);

            Console.WriteLine("Исходный массив: " + string.Join(", ", numbers)); // 64, 25, 12, 22, 11
            Console.WriteLine("Отсортированный: " + string.Join(", ", sortedNumbers)); // 11, 12, 22, 25, 64
        }

        /// <summary>
        /// Сортировка выбором с использование вспомогательного массива
        /// </summary>
        /// <param name="originalArray"></param>
        /// <returns></returns>
        public static int[] SelectionSortWithSecondArray(int[] originalArray)
        {
            int[] sortedArray = new int[originalArray.Length];
            bool[] usedIndices = new bool[originalArray.Length]; // Отслеживаем, какие элементы уже скопированы

            for (int i = 0; i < originalArray.Length; i++)
            {
                // находим минимальный элемент среди неиспользованных
                // гарантированно больше любого возможного элемента в массиве
                int minValue = int.MaxValue;
                int minIndex = -1;

                for (int j = 0; j < originalArray.Length; j++)
                {
                    if (!usedIndices[j] && originalArray[j] < minValue)
                    {
                        minValue = originalArray[j];
                        minIndex = j;
                    }
                }

                // помещаем его в отсортированный массив и отмечаем как использованный
                sortedArray[i] = minValue;
                usedIndices[minIndex] = true;
            }

            return sortedArray;
        }
    }
}