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

    public abstract string NomeForma { get; }

    protected Forma(string cor)
    {
        Cor = cor;
    }

    public abstract double CalcularArea();

    public virtual void ExibirDados()
    {
        Console.WriteLine($"Forma: {NomeForma,-12} | Cor: {Cor,-8} | Área: {CalcularArea():F2}");
    }
}

public class Triangulo : Forma
{
    private double _baseTriangulo;
    private double _altura;

    public override string NomeForma => "Triângulo";

    public double BaseTriangulo
    {
        get => _baseTriangulo;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("A base deve ser maior que zero.");
            }
            _baseTriangulo = value;
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

    public Triangulo(string cor, double baseTriangulo, double altura) : base(cor)
    {
        BaseTriangulo = baseTriangulo;
        Altura = altura;
    }

    public override double CalcularArea() => (_baseTriangulo * _altura) / 2;
}

class Program
{
    static void Main()
    {
        Triangulo t = new Triangulo("Laranja", 6.0, 4.0);
        t.ExibirDados();
    }
}