using System;

namespace Lab1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторна робота 1, 2 ===");
            Console.WriteLine("Варіант 17");

            // 1. Конструктор з 1 параметром
            RList list1 = new RList(10);
            Console.WriteLine("\nСтворено список 1 з 1 елементом:");
            list1.Print();

            // 6. Додавання елемента останнім (рекурсивно)
            list1.AddLastRecursive(20);
            list1.AddLastRecursive(30);
            list1.AddLastRecursive(40);
            Console.WriteLine("\nДодано елементи 20, 30, 40 (рекурсивно):");
            list1.Print();

            // 2. Конструктор з двома параметрами
            RList list2 = new RList(5, list1);
            Console.WriteLine("\nСтворено список 2 (додано 5 на початок списку 1):");
            list2.Print();

            // 49. Властивість Length та 43. Підрахунок
            Console.WriteLine($"\nДовжина списку 2 (через властивість Length): {list2.Length}");

            // 9. Додавання перед значенням
            Console.WriteLine("\nДодавання 25 перед 30 у список 2:");
            list2.AddBeforeValue(30, 25);
            list2.Print();

            Console.WriteLine("\nДодавання 1 перед першим елементом (5):");
            list2.AddBeforeValue(5, 1);
            list2.Print();

            // 15. Рекурсивне видалення останнього
            Console.WriteLine("\nРекурсивне видалення останнього (40):");
            list2.RemoveLastRecursive();
            list2.Print();

            // 17. Не рекурсивне видалення n-ного елемента
            Console.WriteLine("\nНе рекурсивне видалення 2-го елемента (індекс 2 - значення 10):");
            list2.RemoveNthNonRecursive(2);
            list2.Print();

            Console.WriteLine("\nНе рекурсивне видалення 0-го елемента (індекс 0 - значення 1):");
            list2.RemoveNthNonRecursive(0);
            list2.Print();

            // 29. Друк у зворотному порядку в стовпець (не рекурсивно)
            Console.WriteLine("\nДрук списку у зворотному порядку в стовпець (не рекурсивно):");
            list2.PrintReverseColumnNonRecursive();

            // 73, 79. Оператори == та !=
            Console.WriteLine("\nПеревірка операторів == та !=");
            RList list3 = new RList(5);
            list3.AddLastRecursive(20);
            list3.AddLastRecursive(25);
            list3.AddLastRecursive(30);
            
            Console.WriteLine("Список 3:");
            list3.Print();

            Console.WriteLine($"Список 2 == Список 3? {list2 == list3}");
            
            list3.AddLastRecursive(99);
            Console.WriteLine("Додали 99 у Список 3.");
            Console.WriteLine($"Список 2 != Список 3? {list2 != list3}");

            Console.WriteLine("\nНатисніть Enter для виходу...");
            Console.ReadLine();
        }
    }
}
