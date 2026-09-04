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

    // Método abstrato: obrigatório para cada classe derivada implementar sua própria regra de salário
    public abstract decimal CalcularSalario();

    // Método virtual: fornece uma implementação padrão (10% de PLR), mas permite sobrescrita se necessário
    public virtual decimal CalcularPlr()
    {
        return _salarioBase * 0.10m;
    }

    // Método virtual para exibição que faz chamada ao método abstrato e ao virtual
    public virtual void ExibirHolerite()
    {
        Console.WriteLine($"Cargo: {Cargo,-15} | Nome: {Nome,-10} | Salário Final: R$ {CalcularSalario():F2} | PLR: R$ {CalcularPlr():F2}");
    }
}

public class Desenvolvedor : Funcionario
{
    private string _linguagemPrincipal;

    public override string Cargo => "Desenvolvedor";

    public string LinguagemPrincipal
    {
        get => _linguagemPrincipal;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A linguagem principal não pode ser vazia.");
            }
            _linguagemPrincipal = value;
        }
    }

    public Desenvolvedor(string nome, string cpf, decimal salarioBase, string linguagemPrincipal)
        : base(nome, cpf, salarioBase)
    {
        LinguagemPrincipal = linguagemPrincipal;
    }

    // Implementação obrigatória do método abstrato
    public override decimal CalcularSalario() => _salarioBase + (_salarioBase * 0.15m);

    // Herda a implementação padrão de CalcularPlr() sem sobrescrevê-la

    public override void ExibirHolerite()
    {
        base.ExibirHolerite();
        Console.WriteLine($"   Linguagem: {LinguagemPrincipal}");
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

    // Implementação obrigatória do método abstrato
    public override decimal CalcularSalario() => _salarioBase + (_salarioBase * 0.20m) + _bonusGerencial;

    // Sobrescrita opcional do método virtual (Gerente recebe 25% de PLR em vez de 10%)
    public override decimal CalcularPlr()
    {
        return _salarioBase * 0.25m;
    }

    public override void ExibirHolerite()
    {
        base.ExibirHolerite();
        Console.WriteLine($"   Bônus Adicional: R$ {BonusGerencial:F2}");
    }
}

class Program
{
    static void Main()
    {
        List<Funcionario> equipe = new List<Funcionario>
        {
            new Desenvolvedor("Lucas", "987.654.321-11", 6000.00m, "C#"),
            new Gerente("Ana", "123.456.789-00", 9000.00m, 2500.00m)
        };

        foreach (Funcionario f in equipe)
        {
            f.ExibirHolerite();
            Console.WriteLine(new string('-', 60));
        }
    }
}