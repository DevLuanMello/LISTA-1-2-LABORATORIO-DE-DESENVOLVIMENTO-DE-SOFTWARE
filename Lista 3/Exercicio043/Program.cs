using System;
using System.Collections.Generic;

public abstract class Veiculo
{
    private string _marca;
    private string _modelo;
    private int _ano;

    public string Marca
    {
        get => _marca;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A marca não pode ser vazia.");
            }
            _marca = value;
        }
    }

    public string Modelo
    {
        get => _modelo;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O modelo não pode ser vazio.");
            }
            _modelo = value;
        }
    }

    public int Ano
    {
        get => _ano;
        set
        {
            if (value < 1886)
            {
                throw new ArgumentException("Ano inválido para um veículo.");
            }
            _ano = value;
        }
    }

    public Veiculo(string marca, string modelo, int ano)
    {
        Marca = marca;
        Modelo = modelo;
        Ano = ano;
    }

    public abstract void Acelerar();
    public abstract double CalcularConsumo(double distanciaKm);

    public override string ToString() =>
        $"Veículo: {Marca} {Modelo} | Ano: {Ano}";
}

public sealed class CarroEletrico : Veiculo
{
    private double _capacidadeBateriaKwh;

    public double CapacidadeBateriaKwh
    {
        get => _capacidadeBateriaKwh;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("A capacidade da bateria deve ser maior que zero.");
            }
            _capacidadeBateriaKwh = value;
        }
    }

    public CarroEletrico(string marca, string modelo, int ano, double capacidadeBateriaKwh)
        : base(marca, modelo, ano)
    {
        CapacidadeBateriaKwh = capacidadeBateriaKwh;
    }

    public override void Acelerar()
    {
        Console.WriteLine($"O carro elétrico {Marca} {Modelo} acelerou silenciosamente de forma instantânea.");
    }

    public override double CalcularConsumo(double distanciaKm)
    {
        return distanciaKm * 0.18;
    }

    public override string ToString() =>
        $"Carro Elétrico: {Marca} {Modelo} | Bateria: {CapacidadeBateriaKwh} kWh";
}

class Program
{
    static void Main()
    {
        CarroEletrico tesla = new CarroEletrico("Tesla", "Model 3", 2024, 75.0);

        Console.WriteLine(tesla);
        tesla.Acelerar();

        double consumoKwh = tesla.CalcularConsumo(150);
        Console.WriteLine($"Consumo para 150 km: {consumoKwh:F2} kWh");
    }
}