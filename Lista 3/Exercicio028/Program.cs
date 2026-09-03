using System;

public record Cliente(int Id, string Nome, string Email);

class Program
{
    static void Main()
    {
        Cliente c1 = new Cliente(1, "Lucas", "lucas@email.com");
        Cliente c2 = new Cliente(1, "Lucas", "lucas@email.com");

        Console.WriteLine(c1);
        Console.WriteLine($"c1 é igual a c2? {c1 == c2}");

        Cliente c3 = c1 with { Email = "novo.lucas@email.com" };
        Console.WriteLine(c3);
    }
}