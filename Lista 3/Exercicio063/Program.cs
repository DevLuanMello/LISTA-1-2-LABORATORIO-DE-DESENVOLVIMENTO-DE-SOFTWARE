using System;
using System.Collections.Generic;

public abstract class Forma
{
    private string _cor;

    public string Cor
    {
        get => _cor;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A cor não pode ser vazia.");
            }
            _cor = value;
        }
    }

    protected Forma(string cor)
    {
        Cor = cor;
    }

    public abstract double CalcularArea();

    public virtual void ExibirDados()
    {
        Console.WriteLine($"Forma: {GetType().Name} | Cor: {Cor} | Área: {CalcularArea():F2}");
    }
}

public class Retangulo : Forma
{
    private double _largura;
    private double _altura;

    public double Largura
    {
        get => _largura;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("A largura deve ser maior que zero.");
            }
            _largura = value;
        }
    }

    public double Altura
    {
        get => _altura;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("A altura deve ser maior que zero.");
            }
            _altura = value;
        }
    }

    public Retangulo(string cor, double largura, double altura) : base(cor)
    {
        Largura = largura;
        Altura = altura;
    }

    public override double CalcularArea() => _largura * _altura;
}

public class Quadrado : Retangulo
{
    public double Lado
    {
        get => Largura;
        set
        {
            Largura = value;
            Altura = value;
        }
    }

    public Quadrado(string cor, double lado) : base(cor, lado, lado)
    {
    }

    public override double CalcularArea() => Lado * Lado;
}

class Program
{
    static void Main()
    {
        List<Forma> formas = new List<Forma>
        {
            new Retangulo("Azul", 5.0, 3.0),
            new Quadrado("Verde", 4.0)
        };

        foreach (Forma f in formas)
        {
            f.ExibirDados();
        }
    }
}