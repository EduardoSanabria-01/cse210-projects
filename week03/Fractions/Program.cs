// Program.cs

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Verifying Constructors and Methods ---");
        Console.WriteLine(); // Adding a space for readability

        // 1. Using the no-argument constructor (1/1)
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());
        
        // 2. Using the constructor with one parameter (5 -> 5/1)
        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());
        
        // 3. Using the constructor with two parameters (3/4)
        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        // 4. Another fraction to test decimal representation (1/3)
        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());
        
        Console.WriteLine();
        Console.WriteLine("--- Verifying Getters and Setters ---");
        Console.WriteLine();

        // 5. Using setters to change values and getters to retrieve them
        Fraction f5 = new Fraction(); // Starts as 1/1
        f5.SetTop(2);
        f5.SetBottom(5);
        Console.WriteLine($"Original fraction was 1/1, new fraction is: {f5.GetTop()}/{f5.GetBottom()}");
        Console.WriteLine(f5.GetFractionString());
        Console.WriteLine(f5.GetDecimalValue());
    }
}