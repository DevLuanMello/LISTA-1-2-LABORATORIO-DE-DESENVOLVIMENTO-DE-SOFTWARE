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

    public override decimal CalcularSalario() => _salarioBase + (_salarioBase * 0.15m);

    public override void ExibirHolerite()
    {
        base.ExibirHolerite();
        Console.WriteLine($"   Linguagem: {LinguagemPrincipal}");
    }
}

class Program
{
    static void Main()
    {
        Desenvolvedor dev = new Desenvolvedor("Lucas", "987.654.321-11", 6000.00m, "C#");
        dev.ExibirHolerite();
    }
}