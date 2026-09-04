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
        Console.WriteLine($"Olá, meu nome é {Nome} e tenho {Idade} anos.");
    }

    public override string ToString() =>
        $"Pessoa: {Nome} | Idade: {Idade}";
}

public class Conta
{
    private string _numero;
    protected decimal _saldo;
    protected Pessoa _titular;

    public string Numero
    {
        get => _numero;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O número da conta não pode ser vazio.");
            }
            _numero = value;
        }
    }

    public decimal Saldo => _saldo;

    public Pessoa Titular
    {
        get => _titular;
        set => _titular = value ?? throw new ArgumentNullException(nameof(value), "O titular não pode ser nulo.");
    }

    public Conta(string numero, Pessoa titular, decimal saldoInicial = 0m)
    {
        Numero = numero;
        Titular = titular;

        if (saldoInicial < 0)
        {
            throw new ArgumentException("O saldo inicial não pode ser negativo.");
        }
        _saldo = saldoInicial;
    }

    public virtual void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor do depósito deve ser maior que zero.");
        }
        _saldo += valor;
        Console.WriteLine($"[CONTA] Depósito de R$ {valor:F2} realizado. Saldo atual: R$ {_saldo:F2}");
    }

    public virtual bool Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor do saque deve ser maior que zero.");
        }

        if (_saldo >= valor)
        {
            _saldo -= valor;
            Console.WriteLine($"[CONTA BASE] Saque de R$ {valor:F2} realizado. Saldo restante: R$ {_saldo:F2}");
            return true;
        }

        Console.WriteLine($"[CONTA BASE] Saldo insuficiente. Saldo atual: R$ {_saldo:F2}");
        return false;
    }

    public override string ToString() =>
        $"Conta: {Numero} | Titular: {_titular.Nome} | Saldo: R$ {_saldo:F2}";
}

public class ContaCorrente : Conta
{
    protected decimal _limite;

    public decimal Limite
    {
        get => _limite;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("O limite não pode ser negativo.");
            }
            _limite = value;
        }
    }

    public ContaCorrente(string numero, Pessoa titular, decimal saldoInicial, decimal limite)
        : base(numero, titular, saldoInicial)
    {
        Limite = limite;
    }

    public override bool Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor do saque deve ser maior que zero.");
        }

        if (_saldo + _limite >= valor)
        {
            _saldo -= valor;
            Console.WriteLine($"[CONTA CORRENTE] Saque de R$ {valor:F2} realizado. Saldo atual: R$ {_saldo:F2} (Limite: R$ {_limite:F2})");
            return true;
        }

        Console.WriteLine($"[CONTA CORRENTE] Saque recusado. Limite excedido.");
        return false;
    }

    public override string ToString() =>
        base.ToString() + $" | Limite: R$ {_limite:F2}";
}

public class ContaCorrenteEspecialCorporate : ContaCorrente
{
    private string _cnpjEmpresa;

    public string CnpjEmpresa
    {
        get => _cnpjEmpresa;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O CNPJ não pode ser vazio.");
            }
            _cnpjEmpresa = value;
        }
    }

    public ContaCorrenteEspecialCorporate(string numero, Pessoa titular, decimal saldoInicial, decimal limite, string cnpjEmpresa)
        : base(numero, titular, saldoInicial, limite)
    {
        CnpjEmpresa = cnpjEmpresa;
    }

    public override bool Sacar(decimal valor)
    {
        Console.WriteLine($"[CORPORATE - CNPJ: {_cnpjEmpresa}] Processando saque corporativo...");
        return base.Sacar(valor);
    }

    public override string ToString() =>
        base.ToString() + $" | CNPJ: {_cnpjEmpresa}";
}

class Program
{
    static void ProcessarTransacaoBancaria(Conta conta, decimal valorOperacao)
    {
        Console.WriteLine($"\n--- Processando Conta N°: {conta.Numero} ({conta.GetType().Name}) ---");
        Console.WriteLine(conta);

        conta.Depositar(200.00m);
        conta.Sacar(valorOperacao);

        Console.WriteLine($"Saldo final: R$ {conta.Saldo:F2}");
        Console.WriteLine(new string('-', 50));
    }

    static void Main()
    {
        Pessoa titular = new Pessoa("Carlos", 28);

        Conta c1 = new Conta("100-1", titular, 1000.00m);
        ContaCorrente c2 = new ContaCorrente("200-2", titular, 500.00m, 300.00m);
        ContaCorrenteEspecialCorporate c3 = new ContaCorrenteEspecialCorporate("300-3", titular, 5000.00m, 2000.00m, "12.345.678/0001-90");

        ProcessarTransacaoBancaria(c1, 400.00m);
        ProcessarTransacaoBancaria(c2, 900.00m);
        ProcessarTransacaoBancaria(c3, 6000.00m);
    }
}