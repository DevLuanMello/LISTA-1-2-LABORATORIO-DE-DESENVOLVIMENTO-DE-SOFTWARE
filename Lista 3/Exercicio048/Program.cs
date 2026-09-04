using System;
using System.Collections.Generic;

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
        Console.WriteLine($"[Nível 1 - Pessoa] Olá, meu nome é {Nome} e tenho {Idade} anos.");
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
        Console.WriteLine($"[Nível 2 - Funcionario] Sou {Nome}, atuo como {Cargo} e ganho {Salario:C2}.");
    }

    public virtual decimal CalcularRemuneracaoTotal()
    {
        return Salario;
    }

    public override string ToString() =>
        $"Funcionário: {Nome} | Cargo: {Cargo} | Salário: {Salario:C2}";
}

public class Gerente : Funcionario
{
    private decimal _bonus;

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
        Console.WriteLine($"[Nível 3 - Gerente] Sou {Nome}, gerencio a equipe. Salário base: {Salario:C2} | Bônus: {Bonus:C2}.");
    }

    public override decimal CalcularRemuneracaoTotal()
    {
        return Salario + Bonus;
    }

    public override string ToString() =>
        $"Gerente: {Nome} | Remuneração Total: {CalcularRemuneracaoTotal():C2}";
}

public class Diretor : Gerente
{
    private decimal _participacaoLucros;

    public decimal ParticipacaoLucros
    {
        get => _participacaoLucros;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("A participação nos lucros não pode ser negativa.");
            }
            _participacaoLucros = value;
        }
    }

    public Diretor(string nome, int idade, decimal salario, decimal bonus, decimal participacaoLucros)
        : base(nome, idade, salario, bonus)
    {
        Cargo = "Diretor Executivo";
        ParticipacaoLucros = participacaoLucros;
    }

    public override void Apresentar()
    {
        Console.WriteLine($"[Nível 4 - Diretor] Sou {Nome}, direciono a empresa. Remuneração total com PLR: {CalcularRemuneracaoTotal():C2}.");
    }

    public override decimal CalcularRemuneracaoTotal()
    {
        return base.CalcularRemuneracaoTotal() + ParticipacaoLucros;
    }

    public override string ToString() =>
        $"Diretor: {Nome} | Remuneração Total: {CalcularRemuneracaoTotal():C2}";
}

class Program
{
    static void Main()
    {
        List<Pessoa> hierarquia = new List<Pessoa>
        {
            new Pessoa("Carlos", 28),
            new Funcionario("Mariana", 32, "Desenvolvedora C#", 7500.00m),
            new Gerente("Roberto", 45, 12000.00m, 3500.00m),
            new Diretor("Beatriz", 50, 25000.00m, 10000.00m, 15000.00m)
        };

        foreach (Pessoa p in hierarquia)
        {
            p.Apresentar();
            Console.WriteLine(p);

            if (p is Funcionario f)
            {
                Console.WriteLine($"Cálculo de Remuneração via Polimorfismo: {f.CalcularRemuneracaoTotal():C2}");
            }

            Console.WriteLine(new string('-', 50));
        }
    }
}