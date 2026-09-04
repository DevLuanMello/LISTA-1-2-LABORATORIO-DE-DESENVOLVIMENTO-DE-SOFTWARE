using System;
using System.Collections.Generic;

public class Pessoa
{
    protected string _nome;
    protected int _idade;

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
        Console.WriteLine($"Olá, meu nome é {_nome} e tenho {_idade} anos.");
    }

    public override string ToString() =>
        $"Pessoa: {_nome} | Idade: {_idade}";
}

public class Funcionario : Pessoa
{
    protected string _cargo;
    protected decimal _salario;

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
        Console.WriteLine($"Sou {_nome}, tenho {_idade} anos, atuo como {_cargo} e ganho {_salario:C2}.");
    }

    public virtual decimal CalcularRemuneracaoTotal()
    {
        return _salario;
    }

    public override string ToString() =>
        $"Funcionário: {_nome} | Cargo: {_cargo} | Salário: {_salario:C2}";
}

public class Gerente : Funcionario
{
    protected decimal _bonus;

    public decimal Bonus
    {
        get => _bonus;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("O bônus não pode ser negativo.");
            }
            _bonus = value;
        }
    }

    public Gerente(string nome, int idade, decimal salario, decimal bonus)
        : base(nome, idade, "Gerente", salario)
    {
        Bonus = bonus;
    }

    public override void Apresentar()
    {
        Console.WriteLine($"Sou {_nome}, gerencio a equipe. Salário base: {_salario:C2} | Bônus: {_bonus:C2}.");
    }

    public override decimal CalcularRemuneracaoTotal()
    {
        return _salario + _bonus;
    }

    public override string ToString() =>
        $"Gerente: {_nome} | Remuneração Total: {CalcularRemuneracaoTotal():C2}";
}

class Program
{
    static void Main()
    {
        List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa("Carlos", 28),
            new Funcionario("Mariana", 32, "Desenvolvedora C#", 7500.00m),
            new Gerente("Roberto", 45, 12000.00m, 3500.00m)
        };

        foreach (Pessoa p in pessoas)
        {
            p.Apresentar();
        }
    }
}