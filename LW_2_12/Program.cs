using System;

namespace LW_2_12
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> emptyStack = new MyStack<int>();
            MyStack<int> defaultStack = new MyStack<int>(5);
            
            int[] values = { 1, 2, 3, 4, 5, 6 };
            MyStack<int> notEmptyStack = new MyStack<int>();
            notEmptyStack.Push(values);

            Console.WriteLine(">>> Заполнение с использованием всех видов конструкторов");
            Console.WriteLine("Вывод пустого стека");
            Console.WriteLine(emptyStack.Show() + $" ({emptyStack.Count})");
            Console.WriteLine("Вывод стека с предопределенным размером");
            Console.WriteLine(defaultStack.Show() + $" ({defaultStack.Count})");
            Console.WriteLine("Вывод заполненного стека");
            Console.WriteLine(notEmptyStack.Show() + $" ({notEmptyStack.Count})");


            Console.WriteLine(">>> Поиск элемента 4 и 10 в третьей коллекции");
            Console.WriteLine($"Элемент 4 найден: {notEmptyStack.Contains(4)}");
            Console.WriteLine($"Элемент 10 найден: {notEmptyStack.Contains(10)}");


            Console.WriteLine(">>> Клонирование 3 стека в 1");
            emptyStack = new MyStack<int>(notEmptyStack);

            Console.WriteLine("Стек 1");
            Console.WriteLine(emptyStack.Show() + $" ({emptyStack.Count})");
            Console.WriteLine("Стек 2");
            Console.WriteLine(defaultStack.Show() + $" ({defaultStack.Count})");
            Console.WriteLine("Стек 3");
            Console.WriteLine(notEmptyStack.Show() + $" ({notEmptyStack.Count})");

            Console.WriteLine("Добавление в 3 стек элемента");
            notEmptyStack.Push(7);

            Console.WriteLine("Стек 1");
            Console.WriteLine(emptyStack.Show() + $" ({emptyStack.Count})");
            Console.WriteLine("Стек 2");
            Console.WriteLine(defaultStack.Show() + $" ({defaultStack.Count})");
            Console.WriteLine("Стек 3");
            Console.WriteLine(notEmptyStack.Show() + $" ({notEmptyStack.Count})");


            Console.WriteLine(">>> Поверхностное копирование 2 стека в 1");
            emptyStack = defaultStack.ShallowCopy();

            Console.WriteLine("Стек 1");
            Console.WriteLine(emptyStack.Show() + $" ({emptyStack.Count})");
            Console.WriteLine("Стек 2");
            Console.WriteLine(defaultStack.Show() + $" ({defaultStack.Count})");
            Console.WriteLine("Стек 3");
            Console.WriteLine(notEmptyStack.Show() + $" ({notEmptyStack.Count})");

            Console.WriteLine("Добавление в 2 стек элемента");
            defaultStack.Push(66);

            Console.WriteLine("Стек 1");
            Console.WriteLine(emptyStack.Show() + $" ({emptyStack.Count})");
            Console.WriteLine("Стек 2");
            Console.WriteLine(defaultStack.Show() + $" ({defaultStack.Count})");
            Console.WriteLine("Стек 3");
            Console.WriteLine(notEmptyStack.Show() + $" ({notEmptyStack.Count})");


            Console.WriteLine(">>> Очистка всех стеков");

            emptyStack.Remove(emptyStack.Count);
            defaultStack.Remove(defaultStack.Count);
            notEmptyStack.Remove(notEmptyStack.Count);

            Console.WriteLine("Стек 1");
            Console.WriteLine(emptyStack.Show() + $" ({emptyStack.Count})");
            Console.WriteLine("Стек 2");
            Console.WriteLine(defaultStack.Show() + $" ({defaultStack.Count})");
            Console.WriteLine("Стек 3");
            Console.WriteLine(notEmptyStack.Show() + $" ({notEmptyStack.Count})");
        }
    }
}