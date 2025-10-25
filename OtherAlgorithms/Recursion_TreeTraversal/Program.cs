namespace Recursion_TreeTraversal
{
    /// <summary>Узел дерева</summary>
    public class Node
    {
        public string Data { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();

        public Node(string data)
        {
            Data = data;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            // Создаем корень дерева
            Node root = new Node("Root");

            // Добавляем детей к корню
            Node firstChild = new Node("Child 1");
            Node secondChild = new Node("Child 2");
            root.Children.Add(firstChild);
            root.Children.Add(secondChild);

            // Добавляем детей к первому ребенку
            firstChild.Children.Add(new Node("Child 1.1"));
            firstChild.Children.Add(new Node("Child 1.2"));

            // Добавляем детей ко второму ребенку
            secondChild.Children.Add(new Node("Child 2.1"));
            secondChild.Children.Add(new Node("Child 2.2"));
            Node childOfSecondChild = new Node("Child 2.3");
            secondChild.Children.Add(childOfSecondChild);

            // Добавляем детей к ребенку 2.3
            childOfSecondChild.Children.Add(new Node("Child 2.3.1"));

            // Обход дерева и вывод в консоль
            Console.WriteLine("Обход дерева:");
            TraverseAndPrint(root);

            Console.ReadLine();
        }

        /// <summary>
        /// Рекурсивная функция обхода и отображения узлов
        /// </summary>
        /// <param name="node"></param>
        /// <param name="indentLevel"></param>
        private static void TraverseAndPrint(Node node, int indentLevel = 0)
        {
            // Отступ для визуального отображения уровня вложенности
            string indent = new string(' ', indentLevel * 2);

            // Вывод текущего узла
            Console.WriteLine($"{indent}- {node.Data}");

            // Обход детей
            foreach (var child in node.Children)
            {
                TraverseAndPrint(child, indentLevel + 1);
            }
        }
    }
}