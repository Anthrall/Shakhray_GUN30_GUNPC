using System;

class Logic
{
    static void Main()
    {
        // Ввод первого числа
        Console.WriteLine("Enter the first number:");
        if (!int.TryParse(Console.ReadLine(), out int a))
        {
            Console.WriteLine("Error! Invalid input for the first number.");
            return;
        }

        // Ввод второго числа
        Console.WriteLine("Enter the second number:");
        if (!int.TryParse(Console.ReadLine(), out int b))
        {
            Console.WriteLine("Error! Invalid input for the second number.");
            return;
        }

        // Ввод оператора
        Console.WriteLine("Enter the operator (&, |, ^):");
        char op = Console.ReadKey().KeyChar;
        Console.WriteLine();

        int result = 0;

        switch (op)
        {
            case '&':
                result = a & b; 
                break;
            case '|':
                result = a | b; 
                break;
            case '^':
                result = a ^ b; 
                break;
            default:
                Console.WriteLine("Error! Invalid operator.");
                return;
        }

        // Вывод результата 
        Console.WriteLine($"Result (Decimal): {result}");
        Console.WriteLine($"Result (Binary): {Convert.ToString(result, 2)}");
        Console.WriteLine($"Result (Hexadecimal): {result:X}");
    }
}
