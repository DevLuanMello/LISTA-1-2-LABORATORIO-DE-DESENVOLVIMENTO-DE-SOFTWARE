using System;

public class Carro
{
    public string Modelo { get; set; }
    public double Velocidade { get; private set; }

    public Carro(string modelo)
    {
        Modelo = modelo;
        Velocidade = 0;
    }

    public void Acelerar(double incremento)
    {
        if (incremento <= 0)
        {
            Console.WriteLine("Erro: O valor de aceleração deve ser maior que zero.");
            return;
        }

        Velocidade += incremento;
        Console.WriteLine($"O {Modelo} acelerou. Velocidade atual: {Velocidade} km/h");
    }

    public override string ToString()
    {
        return $"Modelo: {Modelo} | Velocidade: {Velocidade} km/h";
    }
}

class Program
{
    static void Main()
    {
        Carro meuCarro = new Carro("Sedan");
        Console.WriteLine(meuCarro);

        meuCarro.Acelerar(20);
        meuCarro.Acelerar(30);
        meuCarro.Acelerar(-10);

        Console.WriteLine(meuCarro);
    }
}