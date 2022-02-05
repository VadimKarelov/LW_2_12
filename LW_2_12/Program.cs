using System;

namespace LW_2_12
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<Organization> emptyStack = new MyStack<Organization>();
            MyStack<Organization> defaultStack = new MyStack<Organization>(5);

            Organization[] values = { new Organization("ZZ", "PP", 500), new Organization("AA", "VV", 40) };
            MyStack<Organization> notEmptyStack = new MyStack<Organization>();
            notEmptyStack.Push(values);

            Console.WriteLine("\n>>> Заполнение с использованием всех видов конструкторов");
            Console.WriteLine("Вывод пустого стека");
            Console.WriteLine(emptyStack.Show() + $" ({emptyStack.Count})");
            Console.WriteLine("Вывод стека с предопределенным размером");
            Console.WriteLine(defaultStack.Show() + $" ({defaultStack.Count})");
            Console.WriteLine("Вывод заполненного стека");
            Console.WriteLine(notEmptyStack.Show() + $" ({notEmptyStack.Count})");


            Console.WriteLine("\n>>> Поиск элемента в третьей коллекции");
            Console.WriteLine($"Существующий элемент найден: {notEmptyStack.Contains(new Organization("ZZ", "PP", 500))}");
            Console.WriteLine($"Не существующий элемент найден: {notEmptyStack.Contains(new Organization("Z", "P", 300))}");


            Console.WriteLine("\n>>> Клонирование 3 стека в 1");
            emptyStack = new MyStack<Organization>(notEmptyStack);

            Console.WriteLine("Стек 1");
            Console.WriteLine(emptyStack.Show() + $" ({emptyStack.Count})");
            Console.WriteLine("Стек 2");
            Console.WriteLine(defaultStack.Show() + $" ({defaultStack.Count})");
            Console.WriteLine("Стек 3");
            Console.WriteLine(notEmptyStack.Show() + $" ({notEmptyStack.Count})");

            Console.WriteLine("Добавление в 3 стек элемента");
            notEmptyStack.Push(new Organization("BB", "UU", 1000));

            Console.WriteLine("Стек 1");
            Console.WriteLine(emptyStack.Show() + $" ({emptyStack.Count})");
            Console.WriteLine("Стек 2");
            Console.WriteLine(defaultStack.Show() + $" ({defaultStack.Count})");
            Console.WriteLine("Стек 3");
            Console.WriteLine(notEmptyStack.Show() + $" ({notEmptyStack.Count})");


            Console.WriteLine("\n>>> Поверхностное копирование 2 стека в 1");
            emptyStack = defaultStack.ShallowCopy();

            Console.WriteLine("Стек 1");
            Console.WriteLine(emptyStack.Show() + $" ({emptyStack.Count})");
            Console.WriteLine("Стек 2");
            Console.WriteLine(defaultStack.Show() + $" ({defaultStack.Count})");
            Console.WriteLine("Стек 3");
            Console.WriteLine(notEmptyStack.Show() + $" ({notEmptyStack.Count})");

            Console.WriteLine("Добавление в 2 стек элемента");
            defaultStack.Push(new Organization("QQ", "WW", 66));

            Console.WriteLine("Стек 1");
            Console.WriteLine(emptyStack.Show() + $" ({emptyStack.Count})");
            Console.WriteLine("Стек 2");
            Console.WriteLine(defaultStack.Show() + $" ({defaultStack.Count})");
            Console.WriteLine("Стек 3");
            Console.WriteLine(notEmptyStack.Show() + $" ({notEmptyStack.Count})");


            Console.WriteLine("\n>>> Очистка всех стеков");

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