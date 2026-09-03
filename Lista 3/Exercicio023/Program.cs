using System;

public class Retangulo
{
    public double Largura { get; set; }
    public double Altura { get; set; }

    public double Area => Largura * Altura;

    public double Perimetro => 2 * (Largura + Altura);

    public Retangulo(double largura, double altura)
    {
        Largura = largura;
        Altura = altura;
    }

    public override string ToString()
    {
        return $"Retângulo [{Largura}x{Altura}] | Área: {Area} | Perímetro: {Perimetro}";
    }
}

class Program
{
    static void Main()
    {
        Retangulo ret = new Retangulo(5.0, 3.0);
        Console.WriteLine(ret);

        ret.Largura = 10.0;
        Console.WriteLine(ret);
    }
}