using System;

class Program
{
    static void Main(string[] args)
    {
        // Test af Faculty
        Console.WriteLine("Faculty(5): " + Opgave3.Faculty(5)); // Output skal være '120'.

        // Test af SFD
        Console.WriteLine("SFD(48, 18): " + SFD(48, 18)); // Output skal være '6'.

        // Test af Power
        Console.WriteLine("5 opløftet til 4: " + Power(5, 4)); // Output skal være '625'.

        Console.WriteLine("7 gange 5: " + Multiply(7, 5)); // Output skal være '35'.

        Console.WriteLine("Reversed 'EGAKNANAB': " + Reverse("EGAKNANAB")); // Output skal være 'BANANAKAGE'
    }

    // Metoden til beregning af SFD (Euclids algoritme)
    public static int SFD(int a, int b)
    {
        // Terminatoringsregel
        if (a % b == 0)
        {
            return b;
        }
        // Rekurrensregel
        if (a < b)
        {
            return SFD(b, a);
        }
        return SFD(b, a % b);
    }

    // Metoden til beregning af n opløftet i p-te potens
    public static int Power(int n, int p)
    {
        // Terminatoringsregel: n^0 = 1
        if (p == 0)
        {
            return 1;
        }
        // Rekurrensregel: n^p = n * n^(p-1)
        else
        {
            return n * Power(n, p - 1);
        }
    }

    // Metoden til beregning af a * b uden at bruge '*'
    public static int Multiply(int a, int b)
    {
        // Terminatoringsregler
        if (a == 1)
        {
            return b;
        }
        if (a == 0)
        {
            return 0;
        }
        // Rekurrensregel: a * b = (a - 1) * b + b
        return Multiply(a - 1, b) + b;
    }


    // Metoden til at vende en string rekursivt
    public static string Reverse(string s)
    {
        // Terminatoringsregel: En tom streng eller en streng med én karakter
        if (string.IsNullOrEmpty(s) || s.Length == 1)
        {
            return s;
        }

        // Rekurrensregel: Flyt første karakter til slutningen og anvend rekursion på resten
        return Reverse(s.Substring(1)) + s[0];
    }
}

class Opgave3
{
    public static int Faculty(int n)
    {
        // Terminatoringsregel: 0! = 1
        if (n == 0)
        {
            return 1;
        }
        // Rekurrensregel: n! = n * (n - 1)! hvor n > 0.
        else
        {
            return n * Faculty(n - 1);
        }
    }
}