using System;

public class ContadorInstancias
{
    private static int _contador = 0;

    public string Nome { get; set; }

    public static int TotalInstancias
    {
        get => _contador;
    }

    public ContadorInstancias()
    {
        _contador++;
    }

    public ContadorInstancias(string nome) : this()
    {
        Nome = nome;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine($"Instâncias iniciais: {ContadorInstancias.TotalInstancias}");

        ContadorInstancias obj1 = new ContadorInstancias("Objeto 1");
        ContadorInstancias obj2 = new ContadorInstancias("Objeto 2");
        ContadorInstancias obj3 = new ContadorInstancias("Objeto 3");

        Console.WriteLine($"Total de instâncias criadas: {ContadorInstancias.TotalInstancias}");
    }
}