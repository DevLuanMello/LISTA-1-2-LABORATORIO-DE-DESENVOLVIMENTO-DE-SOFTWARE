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
        Console.WriteLine($"{Nome} o {Raca} latem com entusiasmo: Au! Au! Au!");
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
        Console.WriteLine($"{Nome} mia suavemente: Miau... Miau!");
    }

    public override string ToString() =>
        $"Gato: {Nome} | Idade: {Idade} anos | Doméstico: {(EhDomestico ? "Sim" : "Não")}";
}

class Program
{
    static void Main()
    {
        Animal animal = new Animal("Sombra", 4);
        Animal cachorro = new Cachorro("Rex", 2, "Boxer");
        Animal gato = new Gato("Mingau", 3, true);

        animal.EmitirSom();
        cachorro.EmitirSom();
        gato.EmitirSom();

        Console.WriteLine(gato);
    }
}