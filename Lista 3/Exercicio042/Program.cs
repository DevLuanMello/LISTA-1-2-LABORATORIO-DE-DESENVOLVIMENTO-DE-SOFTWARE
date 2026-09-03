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
        return distanciaKm / 11.5;
    }

    public override void Acelerar()
    {
        Console.WriteLine($"O carro {Marca} {Modelo} acelerou suavemente.");
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
        return distanciaKm / 28.0;
    }

    public override void Acelerar()
    {
        Console.WriteLine($"A moto {Marca} {Modelo} de {Cilindradas}cc acelerou rapidamente.");
    }
}

public class Caminhao : Veiculo
{
    public decimal CapacidadeCargaToneladas { get; set; }

    public Caminhao(string marca, string modelo, int ano, decimal capacidadeCargaToneladas)
        : base(marca, modelo, ano)
    {
        CapacidadeCargaToneladas = capacidadeCargaToneladas;
    }

    public override double CalcularConsumo(double distanciaKm)
    {
        return distanciaKm / 3.2;
    }

    public override void Acelerar()
    {
        Console.WriteLine($"O caminhão {Marca} {Modelo} acelerou com força total.");
    }
}

class Program
{
    static void Main()
    {
        List<Veiculo> frota = new List<Veiculo>
        {
            new Carro("Toyota", "Corolla", 2024, 4),
            new Moto("Honda", "CB 500F", 2023, 500),
            new Caminhao("Volvo", "FH 540", 2022, 30.5m)
        };

        double distancia = 200.0;

        foreach (Veiculo veiculo in frota)
        {
            veiculo.Acelerar();
            double litros = veiculo.CalcularConsumo(distancia);
            Console.WriteLine($"Consumo do {veiculo.Marca} {veiculo.Modelo} para {distancia} km: {litros:F2} L\n");
        }
    }
}