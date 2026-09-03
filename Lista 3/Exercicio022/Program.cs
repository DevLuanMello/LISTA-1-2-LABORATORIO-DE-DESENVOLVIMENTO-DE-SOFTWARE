using System;

public class Carro
{
    public string Modelo { get; set; }
    public string Cor { get; set; }
    public double Velocidade { get; private set; }

    public Carro()
    {
        this.Velocidade = 0;
    }

    public Carro(string modelo) : this()
    {
        this.Modelo = modelo;
    }

    public Carro(string modelo, string cor) : this(modelo)
    {
        this.Cor = cor;
    }

    public void Acelerar(double incremento)
    {
        if (incremento <= 0)
        {
            Console.WriteLine("Erro: O valor de aceleração deve ser maior que zero.");
            return;
        }

        this.Velocidade += incremento;
        Console.WriteLine($"O {this.Modelo} acelerou. Velocidade atual: {this.Velocidade} km/h");
    }

    public override string ToString()
    {
        return $"Modelo: {this.Modelo} | Cor: {this.Cor ?? "Não especificada"} | Velocidade: {this.Velocidade} km/h";
    }
}

class Program
{
    static void Main()
    {
        Carro carro1 = new Carro("Sedan");
        Console.WriteLine(carro1);

        Carro carro2 = new Carro("Hatch", "Vermelho");
        Console.WriteLine(carro2);

        carro2.Acelerar(50);
        Console.WriteLine(carro2);
    }
}