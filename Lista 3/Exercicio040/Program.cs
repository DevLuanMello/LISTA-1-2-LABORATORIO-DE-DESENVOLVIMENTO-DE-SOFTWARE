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

    public override string ToString() =>
        $"Veículo: {Marca} {Modelo} | Ano: {Ano}";
}

public class Caminhao : Veiculo
{
    private decimal _capacidadeCargaToneladas;

    public decimal CapacidadeCargaToneladas
    {
        get => _capacidadeCargaToneladas;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("A capacidade de carga deve ser maior que zero.");
            }
            _capacidadeCargaToneladas = value;
        }
    }

    public Caminhao(string marca, string modelo, int ano, decimal capacidadeCargaToneladas)
        : base(marca, modelo, ano)
    {
        CapacidadeCargaToneladas = capacidadeCargaToneladas;
    }

    public override void Acelerar()
    {
        Console.WriteLine($"O caminhão {Marca} {Modelo} acelerou devagar transportando {CapacidadeCargaToneladas}T de carga.");
    }

    public override string ToString() =>
        $"Caminhão: {Marca} {Modelo} | Ano: {Ano} | Carga: {CapacidadeCargaToneladas}T";
}

class Program
{
    static void Main()
    {
        Caminhao caminhao = new Caminhao("Volvo", "FH 540", 2022, 30.5m);

        Console.WriteLine(caminhao);
        caminhao.Acelerar();
    }
}