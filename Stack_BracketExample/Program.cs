namespace Stack_BracketExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(IsBalanced("{выражение[выражение(выражение)]}")); // True
            Console.WriteLine(IsBalanced("{выражение[выражение(выражение])}")); // False
        }

        public static bool IsBalanced(string expression)
        {
            // Создаем стек для хранения открывающих скобок
            var stack = new Stack<char>();

            // Создаем словарь соответствий закрывающих скобок открывающим
            var pairs = new Dictionary<char, char>
                {
                    {')', '('},
                    {']', '['},
                    {'}', '{'}
                };

            // Обрабатываем каждый символ строки
            foreach (char c in expression)
            {
                // Если символ - открытка скобка, кладем его в стек
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                // Если символ - закрывающая скобка
                else if (c == ')' || c == ']' || c == '}')
                {
                    // Проверяем, есть ли в стеке соответствующая открывающая скобка
                    if (stack.Count == 0 || stack.Pop() != pairs[c])
                    {
                        // Если несовпадение или стек пуст - строка некорректна
                        return false;
                    }
                    // Другие символы игнорируются (если есть), например, буквенные или числовые
                }
                // После прохода по выражению, если стек пуст — все скобки сбалансированы
            }
            return stack.Count == 0;
        }
    }
}