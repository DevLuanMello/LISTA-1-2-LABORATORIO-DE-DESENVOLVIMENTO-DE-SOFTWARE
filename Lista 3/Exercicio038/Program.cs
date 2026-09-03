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

public class Carro : Veiculo
{
    private int _quantidadePortas;

    public int QuantidadePortas
    {
        get => _quantidadePortas;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("A quantidade de portas deve ser maior que zero.");
            }
            _quantidadePortas = value;
        }
    }

    public Carro(string marca, string modelo, int ano, int quantidadePortas)
        : base(marca, modelo, ano)
    {
        QuantidadePortas = quantidadePortas;
    }

    public override void Acelerar()
    {
        Console.WriteLine($"O carro {Marca} {Modelo} acelerou rapidamente de 0 a 100 km/h!");
    }

    public override string ToString() =>
        $"Carro: {Marca} {Modelo} | Ano: {Ano} | Portas: {QuantidadePortas}";
}

class Program
{
    static void Main()
    {
        Veiculo veiculoGenérico = new Veiculo("Chevrolet", "Celta", 2012);
        Carro meuCarro = new Carro("Toyota", "Corolla", 2024, 4);

        Console.WriteLine(veiculoGenérico);
        veiculoGenérico.Acelerar();

        Console.WriteLine(meuCarro);
        meuCarro.Acelerar();
    }
}