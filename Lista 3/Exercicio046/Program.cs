using System;

public class Pessoa
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

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

    public virtual void Apresentar()
    {
        Console.WriteLine($"Olá, meu nome é {Nome} e tenho {Idade} anos.");
    }

    public override string ToString() =>
        $"Pessoa: {Nome} | Idade: {Idade}";
}

public class Funcionario : Pessoa
{
    private string _cargo;
    private decimal _salario;

    public string Cargo
    {
        get => _cargo;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O cargo não pode ser vazio.");
            }
            _cargo = value;
        }
    }

    public decimal Salario
    {
        get => _salario;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("O salário não pode ser negativo.");
            }
            _salario = value;
        }
    }

    public Funcionario(string nome, int idade, string cargo, decimal salario)
        : base(nome, idade)
    {
        Cargo = cargo;
        Salario = salario;
    }

    public override void Apresentar()
    {
        Console.WriteLine($"Olá, sou {Nome}, tenho {Idade} anos, atuo como {Cargo} e ganho {Salario:C2}.");
    }

    public override string ToString() =>
        $"Funcionário: {Nome} | Cargo: {Cargo} | Salário: {Salario:C2}";
}

class Program
{
    static void Main()
    {
        Pessoa p = new Pessoa("Carlos", 28);
        Funcionario f = new Funcionario("Mariana", 32, "Desenvolvedora C#", 7500.00m);

        p.Apresentar();
        f.Apresentar();
    }
}