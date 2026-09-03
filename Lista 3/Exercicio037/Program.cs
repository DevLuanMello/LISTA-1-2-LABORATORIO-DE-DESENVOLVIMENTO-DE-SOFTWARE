using System;

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

class Program
{
    static void Main()
    {
        Veiculo v = new Veiculo("Chevrolet", "Celta", 2012);
        Console.WriteLine(v);
        v.Acelerar();
    }
}