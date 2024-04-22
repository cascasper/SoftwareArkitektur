using System;

class Program
{
    static void Main(string[] args)
    {
        int n = 10; // Du kan ændre dette tal for at teste med forskellige input
        Console.WriteLine($"Fibonacci number at position {n} is {Fibonacci(n)}");
    }

    static int Fibonacci(int n)
    {
        if (n <= 0)
        {
            return 0;
        }
        else if (n == 1)
        {
            return 1;
        }
        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}