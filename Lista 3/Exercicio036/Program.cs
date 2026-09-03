using System;
using System.Collections.Generic;

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
        Console.WriteLine($"{Nome} ({Raca}): Au! Au! Au!");
    }

    public override string ToString() =>
        $"Cachorro: {Nome} | Raça: {Raca} | Idade: {Idade} anos";
}

public class Gato : Animal
{
    public bool EhDomestico { get; set; }

    public Gato(string nome, int idade, bool ehDomestico = true) : base(nome, idade)
    {
        EhDomestico = ehDomestico;
    }

    public override void EmitirSom()
    {
        Console.WriteLine($"{Nome}: Miau... Miau!");
    }

    public override string ToString() =>
        $"Gato: {Nome} | Idade: {Idade} anos | Doméstico: {(EhDomestico ? "Sim" : "Não")}";
}

class Program
{
    static void Main()
    {
        List<Animal> animais = new List<Animal>
        {
            new Cachorro("Rex", 3, "Pastor Alemão"),
            new Gato("Mingau", 2, true),
            new Animal("Bicho Generico", 5),
            new Cachorro("Thor", 1, "Poodle")
        };

        foreach (Animal animal in animais)
        {
            Console.WriteLine(animal);
            animal.EmitirSom();
            Console.WriteLine("----------------------------------------");
        }
    }
}