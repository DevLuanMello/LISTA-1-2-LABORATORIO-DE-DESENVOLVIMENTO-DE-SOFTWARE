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
        Console.WriteLine($"{Nome} está latindo: Au Au!");
    }

    public override string ToString() =>
        $"Cachorro: {Nome} | Raça: {Raca} | Idade: {Idade} anos";
}

class Program
{
    static void Main()
    {
        Animal animalGenerico = new Animal("Bicho", 5);
        Cachorro meuCachorro = new Cachorro("Thor", 3, "Golden Retriever");

        Console.WriteLine(animalGenerico);
        animalGenerico.EmitirSom();

        Console.WriteLine(meuCachorro);
        meuCachorro.EmitirSom();
    }
}