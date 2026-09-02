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

    public override string ToString()
    {
        return $"Objeto: {Nome} | Instâncias Criadas: {TotalInstancias}";
    }
}

class Program
{
    static void Main()
    {
        ContadorInstancias obj1 = new ContadorInstancias("Objeto A");
        ContadorInstancias obj2 = new ContadorInstancias("Objeto B");

        Console.WriteLine(obj1.ToString());
        Console.WriteLine(obj2);
    }
}