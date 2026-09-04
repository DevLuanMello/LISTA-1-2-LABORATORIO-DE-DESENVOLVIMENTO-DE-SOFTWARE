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

public class Gerente : Funcionario, IAutenticavel
{
    private decimal _bonusGerencial;
    private string _senha;

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

    public Gerente(string nome, string cpf, decimal salarioBase, decimal bonusGerencial, string senha)
        : base(nome, cpf, salarioBase)
    {
        BonusGerencial = bonusGerencial;
        Senha = senha;
    }

    public bool Autenticar(string senha)
    {
        return _senha == senha;
    }

    public override decimal CalcularSalario() => _salarioBase + (_salarioBase * 0.20m) + _bonusGerencial;
}

public class Diretor : Funcionario, IAutenticavel
{
    private string _senha;

    public override string Cargo => "Diretor";

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

    public Diretor(string nome, string cpf, decimal salarioBase, string senha)
        : base(nome, cpf, salarioBase)
    {
        Senha = senha;
    }

    public bool Autenticar(string senha)
    {
        return _senha == senha;
    }

    public override decimal CalcularSalario() => _salarioBase + (_salarioBase * 0.50m);
}

class Program
{
    static void Main()
    {
        List<IAutenticavel> usuariosSistema = new List<IAutenticavel>
        {
            new Gerente("Ana", "123.456.789-00", 9000.00m, 2500.00m, "senha123"),
            new Diretor("Carlos", "555.444.333-22", 18000.00m, "admin456")
        };

        string senhaTentativa = "senha123";

        Console.WriteLine($"=== AUTENTICAÇÃO COM A SENHA '{senhaTentativa}' ===\n");

        foreach (IAutenticavel usuario in usuariosSistema)
        {
            bool autenticado = usuario.Autenticar(senhaTentativa);

            if (usuario is Funcionario f)
            {
                Console.WriteLine($"Usuário: {f.Nome} ({f.Cargo}) -> Autenticado: {autenticado}");
            }
        }
    }
}