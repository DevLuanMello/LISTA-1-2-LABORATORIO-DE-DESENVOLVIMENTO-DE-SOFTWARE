using System;
using System.Collections.Generic;

public interface IBonificavel
{
    decimal PercentualBonificacao { get; }
    decimal CalcularBonificacao();
}

public abstract class Funcionario : IBonificavel
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

    // Membro da interface implementado como abstrato (obriga as derivadas a definir o percentual)
    public abstract decimal PercentualBonificacao { get; }

    protected Funcionario(string nome, string cpf, decimal salarioBase)
    {
        Nome = nome;
        Cpf = cpf;
        SalarioBase = salarioBase;
    }

    // Membro da interface com implementação concreta/padrão compartilhada por todas as derivadas
    public virtual decimal CalcularBonificacao()
    {
        return _salarioBase * PercentualBonificacao;
    }

    public abstract decimal CalcularSalario();

    public virtual void ExibirHolerite()
    {
        Console.WriteLine($"Cargo: {Cargo,-15} | Nome: {Nome,-10} | Salário Base: R$ {_salarioBase:F2} | Bônus: R$ {CalcularBonificacao():F2} | Total: R$ {CalcularSalario():F2}");
    }
}

public class Desenvolvedor : Funcionario
{
    private string _linguagemPrincipal;

    public override string Cargo => "Desenvolvedor";

    // Implementação da propriedade exigida pela interface via classe abstrata
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

    // Sobrescreve o método da interface para incluir o bônus gerencial no cálculo da bonificação
    public override decimal CalcularBonificacao()
    {
        return base.CalcularBonificacao() + _bonusGerencial;
    }

    public override decimal CalcularSalario() => _salarioBase + CalcularBonificacao();
}

class Program
{
    static void Main()
    {
        List<IBonificavel> bonificaveis = new List<IBonificavel>
        {
            new Desenvolvedor("Lucas", "987.654.321-11", 6000.00m, "C#"),
            new Gerente("Ana", "123.456.789-00", 9000.00m, 2500.00m)
        };

        Console.WriteLine("=== PROCESSAMENTO DE INTERFACE (IBonificavel) ===\n");

        foreach (IBonificavel item in bonificaveis)
        {
            if (item is Funcionario f)
            {
                f.ExibirHolerite();
            }
        }
    }
}