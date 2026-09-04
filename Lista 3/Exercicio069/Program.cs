using System;
using System.Collections.Generic;

public abstract class Funcionario
{
    private string _nome;
    private string _cpf;
    protected decimal _salarioBase;

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

    public string Cpf
    {
        get => _cpf;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O CPF não pode ser vazio.");
            }
            _cpf = value;
        }
    }

    public decimal SalarioBase
    {
        get => _salarioBase;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("O salário base não pode ser negativo.");
            }
            _salarioBase = value;
        }
    }

    public abstract string Cargo { get; }

    protected Funcionario(string nome, string cpf, decimal salarioBase)
    {
        Nome = nome;
        Cpf = cpf;
        SalarioBase = salarioBase;
    }

    public abstract decimal CalcularSalario();

    public virtual void ExibirHolerite()
    {
        Console.WriteLine($"Cargo: {Cargo,-15} | Nome: {Nome,-10} | Salário Final: R$ {CalcularSalario():F2}");
    }
}

public class Gerente : Funcionario
{
    private decimal _bonusGerencial;

    public override string Cargo => "Gerente";

    public decimal BonusGerencial
    {
        get => _bonusGerencial;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("O bônus gerencial não pode ser negativo.");
            }
            _bonusGerencial = value;
        }
    }

    public Gerente(string nome, string cpf, decimal salarioBase, decimal bonusGerencial)
        : base(nome, cpf, salarioBase)
    {
        BonusGerencial = bonusGerencial;
    }

    public override decimal CalcularSalario() => _salarioBase + (_salarioBase * 0.20m) + _bonusGerencial;
}

public class Desenvolvedor : Funcionario
{
    public override string Cargo => "Desenvolvedor";

    public Desenvolvedor(string nome, string cpf, decimal salarioBase)
        : base(nome, cpf, salarioBase)
    {
    }

    public override decimal CalcularSalario() => _salarioBase + (_salarioBase * 0.10m);
}

class Program
{
    static void Main()
    {
        List<Funcionario> equipe = new List<Funcionario>
        {
            new Gerente("Ana", "123.456.789-00", 8000.00m, 2000.00m),
            new Desenvolvedor("Lucas", "987.654.321-11", 5000.00m)
        };

        foreach (Funcionario f in equipe)
        {
            f.ExibirHolerite();
        }
    }
}