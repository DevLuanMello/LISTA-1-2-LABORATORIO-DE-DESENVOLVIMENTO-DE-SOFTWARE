using System;
using System.Collections.Generic;

public interface IImprimivel
{
    void Imprimir();
}

public interface IBonificavel
{
    decimal PercentualBonificacao { get; }
    decimal CalcularBonificacao();
}

public abstract class Funcionario : IBonificavel, IImprimivel
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
    public abstract decimal PercentualBonificacao { get; }

    protected Funcionario(string nome, string cpf, decimal salarioBase)
    {
        Nome = nome;
        Cpf = cpf;
        SalarioBase = salarioBase;
    }

    public virtual decimal CalcularBonificacao()
    {
        return _salarioBase * PercentualBonificacao;
    }

    public abstract decimal CalcularSalario();

    // Implementação do método da interface IImprimivel
    public virtual void Imprimir()
    {
        Console.WriteLine($"[RELATÓRIO DE FUNCIONÁRIO]");
        Console.WriteLine($"Cargo: {Cargo} | Nome: {Nome} | CPF: {Cpf}");
        Console.WriteLine($"Salário Base: R$ {_salarioBase:F2} | Bônus: R$ {CalcularBonificacao():F2} | Salário Final: R$ {CalcularSalario():F2}");
    }
}

public class Desenvolvedor : Funcionario
{
    private string _linguagemPrincipal;

    public override string Cargo => "Desenvolvedor";
    public override decimal PercentualBonificacao => 0.15m;

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

    public override decimal CalcularSalario() => _salarioBase + CalcularBonificacao();

    public override void Imprimir()
    {
        base.Imprimir();
        Console.WriteLine($"Linguagem Principal: {LinguagemPrincipal}");
    }
}

public class Gerente : Funcionario
{
    private decimal _bonusGerencial;

    public override string Cargo => "Gerente";
    public override decimal PercentualBonificacao => 0.20m;

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

    public override decimal CalcularBonificacao()
    {
        return base.CalcularBonificacao() + _bonusGerencial;
    }

    public override decimal CalcularSalario() => _salarioBase + CalcularBonificacao();

    public override void Imprimir()
    {
        base.Imprimir();
        Console.WriteLine($"Bônus Gerencial Adicional: R$ {BonusGerencial:F2}");
    }
}

class Program
{
    static void Main()
    {
        List<IImprimivel> listaImprimiveis = new List<IImprimivel>
        {
            new Desenvolvedor("Lucas", "987.654.321-11", 6000.00m, "C#"),
            new Gerente("Ana", "123.456.789-00", 9000.00m, 2500.00m)
        };

        Console.WriteLine("=== IMPRESSÃO VIA INTERFACE IImprimivel ===\n");

        foreach (IImprimivel item in listaImprimiveis)
        {
            item.Imprimir();
            Console.WriteLine(new string('-', 55));
        }
    }
}