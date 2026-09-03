using System;

public class Animal
{
    private string _nome;
    private int _idade;

    public string Nome
    {
        get => _nome;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O nome não pode ser vazio.");
            }
            _nome = value;
        }
    }

    public int Idade
    {
        get => _idade;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("A idade não pode ser negativa.");
            }
            _idade = value;
        }
    }

    public Animal(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

    public virtual void EmitirSom()
    {
        Console.WriteLine($"{Nome} faz um som genérico.");
    }

    public override string ToString() =>
        $"Animal: {Nome} | Idade: {Idade} anos";
}

public class Cachorro : Animal
{
    public string Raca { get; set; }

    public Cachorro(string nome, int idade, string raca) : base(nome, idade)
    {
        Raca = raca;
    }

    public override void EmitirSom()
    {
        Console.WriteLine($"{Nome} faz: Au Au!");
    }

    public override string ToString() =>
        $"Cachorro: {Nome} | Raça: {Raca} | Idade: {Idade} anos";
}

public class Gato : Animal
{
    public Gato(string nome, int idade) : base(nome, idade) { }

    public override void EmitirSom()
    {
        Console.WriteLine($"{Nome} faz: Miau!");
    }
}

class Program
{
    static void Main()
    {
        Animal a1 = new Animal("Bicho", 5);
        Animal a2 = new Cachorro("Rex", 3, "Pastor Alemão");
        Animal a3 = new Gato("Felix", 2);

        a1.EmitirSom();
        a2.EmitirSom();
        a3.EmitirSom();
    }
}