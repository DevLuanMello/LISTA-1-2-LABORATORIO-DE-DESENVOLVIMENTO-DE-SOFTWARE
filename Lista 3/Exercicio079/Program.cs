using System;
using System.Collections.Generic;

public interface IAutenticavel
{
    bool Autenticar(string senha);
}

public interface IImprimivel
{
    void Imprimir();
}

public abstract class Funcionario : IImprimivel
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

    public virtual void Imprimir()
    {
        Console.WriteLine($"Cargo: {Cargo,-15} | Nome: {Nome,-10} | CPF: {Cpf} | Salário Final: R$ {CalcularSalario():F2}");
    }
}

public class Administrador : Funcionario, IAutenticavel
{
    private string _senha;

    public override string Cargo => "Administrador";

    public string Senha
    {
        private get => _senha;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 6)
            {
                throw new ArgumentException("A senha deve ter no mínimo 6 caracteres.");
            }
            _senha = value;
        }
    }

    public Administrador(string nome, string cpf, decimal salarioBase, string senha)
        : base(nome, cpf, salarioBase)
    {
        Senha = senha;
    }

    public bool Autenticar(string senha)
    {
        return _senha == senha;
    }

    public override decimal CalcularSalario() => _salarioBase + (_salarioBase * 0.25m);
}

class Program
{
    static void Main()
    {
        IAutenticavel admin = new Administrador("Roberto", "777.888.999-00", 7500.00m, "admin123");

        Console.WriteLine($"Tentativa 1 ('errada'): {admin.Autenticar("errada")}");
        Console.WriteLine($"Tentativa 2 ('admin123'): {admin.Autenticar("admin123")}");
    }
}