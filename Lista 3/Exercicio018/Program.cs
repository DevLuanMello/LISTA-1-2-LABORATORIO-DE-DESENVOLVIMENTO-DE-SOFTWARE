using System;

public class Calculadora
{
    public static double Somar(double a, double b)
    {
        return a + b;
    }
}

class Program
{
    static void Main()
    {
        double resultado1 = Calculadora.Somar(10.5, 5.5);
        Console.WriteLine($"Resultado da soma (10.5 + 5.5): {resultado1}");

        double resultado2 = Calculadora.Somar(-3, 8);
        Console.WriteLine($"Resultado da soma (-3 + 8): {resultado2}");
    }
}