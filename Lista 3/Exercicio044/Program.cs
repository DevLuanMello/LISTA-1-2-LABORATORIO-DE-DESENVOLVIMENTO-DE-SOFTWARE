using System;

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

    public virtual void Acelerar()
    {
        Console.WriteLine($"O veículo {Marca} {Modelo} está acelerando.");
    }

    public abstract double CalcularConsumo(double distanciaKm);
}

public class Carro : Veiculo
{
    public int QuantidadePortas { get; set; }

    public Carro(string marca, string modelo, int ano, int quantidadePortas)
        : base(marca, modelo, ano)
    {
        QuantidadePortas = quantidadePortas;
    }

    public sealed override void Acelerar()
    {
        Console.WriteLine($"O carro {Marca} {Modelo} acelerou com controle de tração ativado.");
    }

    public override double CalcularConsumo(double distanciaKm)
    {
        return distanciaKm / 11.5;
    }
}

public class CarroEsportivo : Carro
{
    public bool ModoTurboAtivo { get; set; }

    public CarroEsportivo(string marca, string modelo, int ano, int quantidadePortas, bool modoTurboAtivo)
        : base(marca, modelo, ano, quantidadePortas)
    {
        ModoTurboAtivo = modoTurboAtivo;
    }

    public override double CalcularConsumo(double distanciaKm)
    {
        return ModoTurboAtivo ? distanciaKm / 6.0 : base.CalcularConsumo(distanciaKm);
    }
}

class Program
{
    static void Main()
    {
        CarroEsportivo esportivo = new CarroEsportivo("Porsche", "911", 2024, 2, true);

        esportivo.Acelerar();

        double consumo = esportivo.CalcularConsumo(100);
        Console.WriteLine($"Consumo do {esportivo.Marca} {esportivo.Modelo} em 100 km: {consumo:F2} L");
    }
}