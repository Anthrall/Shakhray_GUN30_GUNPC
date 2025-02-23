using System;
using System.Linq.Expressions;

class Program
{
    static void Main()
    {

        Console.WriteLine("Задача A: создать 4 массива внутри метода Main");
        
        FibonacciNum();

        Console.WriteLine();
        Console.WriteLine();

        Mounth();

        Console.WriteLine();
        Console.WriteLine();

        MatrixPow();

        Console.WriteLine();
        Console.WriteLine();

        Jagged();

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Задача Б: Вам дано два массива int[] array = { 1, 2, 3, 4, 5 }; int[] array2 = { 7, 8, 9, 10, 11, 12, 13 }");
        ArraysB();
    }

    //Задание 1
    static void FibonacciNum()
    {
        int[] fibonacciNumbers = new int[8];

        fibonacciNumbers[0] = 0;
        fibonacciNumbers[1] = 1;

        for (int i = 2; i < fibonacciNumbers.Length; i++)
        {
            fibonacciNumbers[i] = fibonacciNumbers[i - 1] + fibonacciNumbers[i - 2];
        }

        Console.WriteLine("Первые 8 чисел Фибоначчи:");
        foreach (int number in fibonacciNumbers)
        {
            Console.Write(number + " ");
        }
    }

    //Задание 2
    static void Mounth()
    {
        string[] months = {
            "January", "February", "March", "April",
            "May", "June", "July", "August",
            "September", "October", "November", "December"
        };

        Console.WriteLine("Months of the year:");
        foreach (string month in months)
        {
            Console.WriteLine(month);
        }
    }

    //Задание 3
    static void MatrixPow()
    {
        int[,] matrix = new int[3, 3];

        for (int i = 0; i < 3; i++) // Строки
        {
            for (int j = 0; j < 3; j++) // Столбцы
            {
                matrix[i, j] = (int)Math.Pow(j + 2, i + 1);
            }
        }

        Console.WriteLine("Матрица 3x3:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matrix[i, j] + "\t"); 
            }
            Console.WriteLine(); 
        }
    }

    //Задание 4
    static void Jagged()
    {
        double[][] jaggedArray = new double[3][];

        jaggedArray[0] = new double[] { 1, 2, 3, 4, 5 };

        jaggedArray[1] = new double[] { Math.E, Math.PI };

        jaggedArray[2] = new double[]
        {
            Math.Log10(1),
            Math.Log10(10),
            Math.Log10(100),
            Math.Log10(1000)
        };

        Console.WriteLine("Jagged Array:");
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            Console.Write($"Array {i + 1}: ");
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    //Задания 5 и 6
    static void ArraysB()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };

        // Задание 5
        Array.Copy(array, 0, array2, 0, 3);

        Console.WriteLine("Второй массив после копирования:");
        foreach (int num in array2)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        // Задание 6
        Array.Resize(ref array, array.Length * 2);

        Console.WriteLine("Первый массив после изменения размера:");
        foreach (int num in array)
        {
            Console.Write(num + " ");
        }
    }
}

