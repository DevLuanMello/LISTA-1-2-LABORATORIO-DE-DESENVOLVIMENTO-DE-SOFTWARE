using System;

public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Pessoa()
    {
    }

    public Pessoa(string nome)
    {
        Nome = nome;
    }

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

    public void Apresentar()
    {
        Console.WriteLine($"Olá, meu nome é {Nome} e tenho {Idade} anos.");
    }
}

class Program
{
    static void Main()
    {
        Pessoa p1 = new Pessoa();
        p1.Nome = "Ana";
        p1.Idade = 20;

        Pessoa p2 = new Pessoa("Carlos");
        p2.Idade = 25;

        Pessoa p3 = new Pessoa("Mariana", 30);

        p1.Apresentar();
        p2.Apresentar();
        p3.Apresentar();
    }
}