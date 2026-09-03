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

class Program
{
    static void Main()
    {
        Animal animal = new Animal("Rex", 3);
        Console.WriteLine(animal);
        animal.EmitirSom();
    }
}