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

public class Moto : Veiculo
{
    private int _cilindradas;

    public int Cilindradas
    {
        get => _cilindradas;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("As cilindradas devem ser maiores que zero.");
            }
            _cilindradas = value;
        }
    }

    public Moto(string marca, string modelo, int ano, int cilindradas)
        : base(marca, modelo, ano)
    {
        Cilindradas = cilindradas;
    }

    public override void Acelerar()
    {
        Console.WriteLine($"A moto {Marca} {Modelo} de {Cilindradas}cc acelerou empinando a roda!");
    }

    public override string ToString() =>
        $"Moto: {Marca} {Modelo} | Ano: {Ano} | Cilindradas: {Cilindradas}cc";
}

class Program
{
    static void Main()
    {
        Moto minhaMoto = new Moto("Honda", "CB 500F", 2023, 500);

        Console.WriteLine(minhaMoto);
        minhaMoto.Acelerar();
    }
}