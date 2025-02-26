using System;
using System.Collections.Generic;

namespace HomeWork
{
    internal class Program
    {
        private class ListTask
        {
            private readonly List<string> _list = new List<string>();

            public void TaskLoop()
            {
                Console.WriteLine("Задача 1: Список строк (enter '--exit' to quit)");

                // Инициализация списка
                _list.AddRange(new[] { "яблоко", "банан", "апельсин" });
                PrintList();

                while (true)
                {
                    Console.Write("Что добавить в список? ");
                    var input = Console.ReadLine();
                    if (input == "--exit") return;

                    _list.Add(input);
                    PrintList();

                    Console.Write("Что добавить в середину списка? ");
                    input = Console.ReadLine();
                    if (input == "--exit") return;

                    _list.Insert(_list.Count / 2, input);
                    PrintList();
                }
            }

            private void PrintList()
            {
                Console.WriteLine("Весь список:");
                Console.WriteLine(string.Join(", ", _list));
            }
        }

        private class DictionaryTask
        {
            private readonly Dictionary<string, double> _grades = new Dictionary<string, double>();

            public void TaskLoop()
            {
                Console.WriteLine("Задача 2: Словарь оценок студентов (enter '--exit' to quit)");

                while (true)
                {
                    Console.Write("Введите имя студента: ");
                    var name = Console.ReadLine();
                    if (name == "--exit") return;

                    Console.Write("Введите оценку (2-5): ");
                    if (!double.TryParse(Console.ReadLine(), out var grade) || grade < 2 || grade > 5)
                    {
                        Console.WriteLine("Неверная оценка!");
                        continue;
                    }

                    _grades[name] = grade;

                    Console.Write("Введите имя студента для поиска: ");
                    var searchName = Console.ReadLine();
                    if (_grades.TryGetValue(searchName, out var foundGrade))
                        Console.WriteLine($"Оценка: {foundGrade}");
                    else
                        Console.WriteLine("Студент не найден!");
                }
            }
        }

        private class LinkedListTask
        {
            private class Node
            {
                public string Data;
                public Node Previous;
                public Node Next;

                public Node(string data) => Data = data;
            }

            private Node _head;
            private Node _tail;

            public void TaskLoop()
            {
                Console.WriteLine("Задача 3: Двусвязный список (enter '--exit' to quit)");

                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"Введите элемент номер {i + 1}: ");
                    var input = Console.ReadLine();
                    if (input == "--exit") return;
                    AddNode(input);
                }

                PrintForward();
                PrintBackward();
            }

            private void AddNode(string data)
            {
                var newNode = new Node(data);
                if (_head == null)
                {
                    _head = _tail = newNode;
                }
                else
                {
                    _tail.Next = newNode;
                    newNode.Previous = _tail;
                    _tail = newNode;
                }
            }

            private void PrintForward()
            {
                Console.WriteLine("Прямой порядок:");
                var current = _head;
                while (current != null)
                {
                    Console.Write(current.Data + " ");
                    current = current.Next;
                }
                Console.WriteLine();
            }

            private void PrintBackward()
            {
                Console.WriteLine("Обратный порядок:");
                var current = _tail;
                while (current != null)
                {
                    Console.Write(current.Data + " ");
                    current = current.Previous;
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задания 1, 2 или 3 (enter '--exit' to quit)");

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out var task) || task < 1 || task > 3)
                {
                    Console.WriteLine("Неверный номер задания");
                    continue;
                }

                switch (task)
                {
                    case 1:
                        new ListTask().TaskLoop();
                        break;
                    case 2:
                        new DictionaryTask().TaskLoop();
                        break;
                    case 3:
                        new LinkedListTask().TaskLoop();
                        break;
                }
            }
        }
    }
}