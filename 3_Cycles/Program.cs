using System;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1: Вывод первых 10 чисел Фибоначчи
            Console.WriteLine("Первые 10 чисел Фибоначчи:");
            int a = 0, b = 1;
            for (int i = 0; i < 10; i++)
            {
                Console.Write(a + " ");
                int temp = a;
                a = b;
                b = temp + b;
            }
            Console.WriteLine();

            // Задание 2: Вывод всех чётных чисел от 2 до 20
            Console.WriteLine("Чётные числа от 2 до 20:");
            for (int i = 2; i <= 20; i += 2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // Задание 3: Таблица умножения от 1 до 5
            Console.WriteLine("Таблица умножения от 1 до 5:");
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    Console.WriteLine($"{i} * {j} = {i * j}\t");
                }
                Console.WriteLine();
            }

            // Задание 4: Ввод пароля
            string password = "qwerty";
            string userInput = "";
            do
            {
                Console.WriteLine("Введите пароль:");
                
                userInput = Console.ReadLine();
               
            } while (userInput != password);

            Console.WriteLine("Пароль верный! Доступ разрешён.");
        }
    }
}
