using System;

public class Pessoa
{
    private int _idade;

    public string Nome { get; set; }

    public int Idade
    {
        get => _idade;
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Erro: A idade não pode ser negativa.");
                return;
            }
            _idade = value;
        }
    }

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
        Pessoa p1 = new Pessoa("Ana", 20);
        p1.Apresentar();

        Pessoa p2 = new Pessoa("Carlos", -5);
        p2.Apresentar();

        p1.Idade = -10;
        p1.Apresentar();
    }
}