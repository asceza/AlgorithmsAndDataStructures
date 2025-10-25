using System;
using System.Collections.Generic;

namespace TreeSort
{
    /// <summary>
    /// Узел бинарного дерева
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// Значение узла
        /// </summary>
        public int Data;

        /// <summary>
        /// Левый дочерний узел
        /// </summary>
        public TreeNode? Left;

        /// <summary>
        /// Правый дочерний узел
        /// </summary>
        public TreeNode? Right;

        /// <summary>
        /// Конструктор для создания узла
        /// </summary>
        /// <param name="data">Значение для сохранения в узле</param>
        public TreeNode(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    /// <summary>
    /// Бинарное дерево поиска
    /// </summary>
    public class BinaryTree
    {
        /// <summary>
        /// Корень дерева
        /// </summary>
        private TreeNode? _root;

        /// <summary>
        /// Конструктор для создания пустого дерева
        /// </summary>
        public BinaryTree()
        {
            _root = null;
        }

        /// <summary>
        /// Вставка нового значения в дерево
        /// </summary>
        /// <param name="data">Значение для вставки</param>
        public void Insert(int data)
        {
            // Если корень пуст, создаем новый узел и делаем его корнем
            if (_root == null)
            {
                _root = new TreeNode(data);
                return;
            }
            // Иначе, вставляем узел в соответствующее поддерево
            InsertRec(_root, new TreeNode(data));
        }

        /// <summary>
        /// Рекурсивная вставка нового узла
        /// </summary>
        /// <param name="root">Текущий узел</param>
        /// <param name="newNode">Новый узел для вставки</param>
        private void InsertRec(TreeNode root, TreeNode newNode)
        {
            // Если значение нового узла меньше значения текущего узла
            if (newNode.Data < root.Data)
            {
                // Если левый дочерний узел пуст, вставляем новый узел сюда
                if (root.Left == null)
                {
                    root.Left = newNode;
                }
                // Иначе, рекурсивно ищем место в левом поддереве
                else
                {
                    InsertRec(root.Left, newNode);
                }
            }
            // Если значение нового узла больше или равно значению текущего узла
            else
            {
                // Если правый дочерний узел пуст, вставляем новый узел сюда
                if (root.Right == null)
                {
                    root.Right = newNode;
                }
                // Иначе, рекурсивно ищем место в правом поддереве
                else
                {
                    InsertRec(root.Right, newNode);
                }
            }
        }

        /// <summary>
        /// Обход дерева в порядке "in-order" для получения отсортированного списка
        /// </summary>
        /// <param name="root">Текущий узел</param>
        /// <param name="sortedList">Список для сохранения отсортированных элементов</param>
        public void InOrder(TreeNode? root, List<int> sortedList)
        {
            // Если узел не пуст
            if (root != null)
            {
                // Рекурсивно обходим левое поддерево
                InOrder(root.Left, sortedList);
                // Добавляем значение текущего узла в список
                sortedList.Add(root.Data);
                // Рекурсивно обходим правое поддерево
                InOrder(root.Right, sortedList);
            }
        }

        /// <summary>
        /// Возвращает корень дерева
        /// </summary>
        /// <returns>Корень дерева</returns>
        public TreeNode? GetRoot()
        {
            return _root;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            // Исходный массив для сортировки
            int[] array = { 5, 2, 8, 1, 95, 4, 63, 3, 7 };

            Console.WriteLine("Исходный массив:");
            PrintArray(array);

            // Выполняем сортировку деревом
            TreeSort(array);

            Console.WriteLine("\nОтсортированный массив:");
            PrintArray(array);
        }

        /// <summary>
        /// Сортировка массива с использованием бинарного дерева
        /// </summary>
        /// <param name="array">Массив для сортировки</param>
        public static void TreeSort(int[] array)
        {
            // Создаем новое бинарное дерево
            var tree = new BinaryTree();

            // Вставляем все элементы массива в дерево
            foreach (var item in array)
            {
                tree.Insert(item);
            }

            // Создаем список для хранения отсортированных элементов
            var sortedList = new List<int>();
            // Обходим дерево в порядке "in-order" для получения отсортированного списка
            tree.InOrder(tree.GetRoot(), sortedList);

            // Копируем отсортированные элементы обратно в массив
            for (int i = 0; i < sortedList.Count; i++)
            {
                array[i] = sortedList[i];
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