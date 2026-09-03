using System;
using System.Collections.Generic;

public class Veiculo
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

    public virtual void Acelerar()
    {
        Console.WriteLine($"O veículo {Marca} {Modelo} está acelerando.");
    }

    public virtual double CalcularConsumo(double distanciaKm)
    {
        return distanciaKm / 10.0;
    }

    public override string ToString() =>
        $"Veículo: {Marca} {Modelo} | Ano: {Ano}";
}

public class Carro : Veiculo
{
    public int QuantidadePortas { get; set; }

    public Carro(string marca, string modelo, int ano, int quantidadePortas)
        : base(marca, modelo, ano)
    {
        QuantidadePortas = quantidadePortas;
    }

    public override double CalcularConsumo(double distanciaKm)
    {
        return distanciaKm / 12.0;
    }
}

public class Moto : Veiculo
{
    public int Cilindradas { get; set; }

    public Moto(string marca, string modelo, int ano, int cilindradas)
        : base(marca, modelo, ano)
    {
        Cilindradas = cilindradas;
    }

    public override double CalcularConsumo(double distanciaKm)
    {
        return distanciaKm / 25.0;
    }
}

class Program
{
    static void Main()
    {
        List<Veiculo> veiculos = new List<Veiculo>
        {
            new Veiculo("Chevrolet", "Celta", 2012),
            new Carro("Toyota", "Corolla", 2024, 4),
            new Moto("Honda", "CB 500F", 2023, 500)
        };

        double distancia = 100.0;

        foreach (Veiculo v in veiculos)
        {
            double consumo = v.CalcularConsumo(distancia);
            Console.WriteLine($"{v.Marca} {v.Modelo} precisa de {consumo:F2} litros para percorrer {distancia} km.");
        }
    }
}