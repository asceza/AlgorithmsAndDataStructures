using System;

namespace MergeSort
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			// Исходный массив для сортировки
			int[] array = { 38, 27, 43, 3, 9, 82, 10 };

            Console.WriteLine("Исходный массив:");
            PrintArray(array);

            // Вызов метода сортировки слиянием
            MergeSort(array);

            Console.WriteLine();
            Console.WriteLine("Отсортированный массив:");
            PrintArray(array);
		}

		/// <summary>
		/// Рекурсивно разделяет массив на две половины и затем сливает их.
		/// </summary>
		/// <param name="array">Сортируемый массив.</param>
		public static void MergeSort(int[] array)
		{
			// Рекурсия продолжается, пока длина массива больше 1
			if (array.Length < 2)
			{
				return;
			}

			// Находим середину массива
			int mid = array.Length / 2;

			// Создаем два подмассива: левый и правый
			int[] left = new int[mid];
			int[] right = new int[array.Length - mid];

			// Копируем элементы из основного массива в левый подмассив
			for (int i = 0; i < mid; i++)
			{
				left[i] = array[i];
			}

			// Копируем элементы из основного массива в правый подмассив
			for (int i = mid; i < array.Length; i++)
			{
				right[i - mid] = array[i];
			}

			// Рекурсивно вызываем MergeSort для обеих половин
			MergeSort(left);
			MergeSort(right);

			// Сливаем отсортированные половины
			Merge(array, left, right);
		}

		/// <summary>
		/// Сливает два отсортированных подмассива в один отсортированный массив.
		/// </summary>
		/// <param name="array">Основной массив для перезаписи.</param>
		/// <param name="left">Левый отсортированный подмассив.</param>
		/// <param name="right">Правый отсортированный подмассив.</param>
		public static void Merge(int[] array, int[] left, int[] right)
		{
			// i - итератор для левого подмассива, j - для правого, k - для основного
			int i = 0, j = 0, k = 0;

			// Сравниваем элементы из левого и правого подмассивов
			// и помещаем меньший элемент в основной массив
			while (i < left.Length && j < right.Length)
			{
				if (left[i] <= right[j])
				{
					array[k++] = left[i++];
				}
				else
				{
					array[k++] = right[j++];
				}
			}

			// Если в левом подмассиве остались элементы, копируем их
			while (i < left.Length)
			{
				array[k++] = left[i++];
			}

			// Если в правом подмассиве остались элементы, копируем их
			while (j < right.Length)
			{
				array[k++] = right[j++];
			}
		}

		/// <summary>
		/// Вспомогательный метод для вывода массива в консоль.
		/// </summary>
		/// <param name="array">Массив для вывода.</param>
		public static void PrintArray(int[] array)
		{
			Console.WriteLine(string.Join(", ", array));
		}
	}
}