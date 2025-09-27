using System.Runtime.CompilerServices;

namespace BinarySearch
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] data = { 1, 7, 9, 12, 15, 23, 31, 32, 47 };

            Console.WriteLine(BinarySearch(data, 12).ToString());
        }

        /// <summary>
        /// Бинарный поиск индекса искомого элемента в массиве
        /// </summary>
        /// <param name="data"></param>
        /// <param name="searchNumber"></param>
        /// <returns></returns>
        private static int BinarySearch(int[] data, int searchNumber)
        {
            int minIndex = 0; // минимальная граница поиска
            int maxIndex = data.Length - 1; // максимальная граница поиска

            while (minIndex <= maxIndex) // пока не сошлись границы поиска
            {
                int middleIndex = (minIndex + maxIndex) / 2; // индекс среднего элемента
                int guess = data[middleIndex]; // значение среднего элемента

                if (guess == searchNumber) // если значение найдено
                {
                    return middleIndex;
                }

                if (guess > searchNumber)
                {
                    maxIndex = middleIndex - 1; // отбрасываем правую часть, работаем с левой частью
                }
                else
                {
                    minIndex = middleIndex + 1; //
                }
            }
            return -1;
        }
    }
}