using System;

public class Circulo
{
    public const double PI = 3.141592653589793;

    public double Raio { get; set; }

    public Circulo(double raio)
    {
        Raio = raio;
    }

    public double CalcularArea()
    {
        return PI * Raio * Raio;
    }

    public double CalcularPerimetro()
    {
        return 2 * PI * Raio;
    }

    public void ExibirDados()
    {
        Console.WriteLine($"Raio: {Raio} | Área: {CalcularArea():F2} | Perímetro: {CalcularPerimetro():F2}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine($"Valor da constante PI: {Circulo.PI}");

        Circulo c1 = new Circulo(5.0);
        c1.ExibirDados();
    }
}