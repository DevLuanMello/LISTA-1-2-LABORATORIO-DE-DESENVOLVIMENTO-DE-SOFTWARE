using System;

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
        Console.WriteLine($"[DEPÓSITO BASE] R$ {valor:F2} depositado na conta {Numero}. Saldo: R$ {_saldo:F2}");
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
            Console.WriteLine($"[SAQUE BASE] R$ {valor:F2} na conta {Numero}. Saldo restante: R$ {_saldo:F2}");
            return true;
        }

        Console.WriteLine($"[SAQUE RECUSADO BASE] Saldo insuficiente na conta {Numero}. Saldo atual: R$ {_saldo:F2}");
        return false;
    }

    public override string ToString() =>
        $"Conta: {Numero} | Titular: {_titular.Nome} | Saldo: R$ {_saldo:F2}";
}

public class ContaCorrente : Conta
{
    private decimal _limite;

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
            Console.WriteLine($"[SAQUE SOBRESCRITO - CORRENTE] R$ {valor:F2} realizado usando limite. Saldo atual: R$ {_saldo:F2} (Limite: R$ {_limite:F2})");
            return true;
        }

        Console.WriteLine($"[SAQUE RECUSADO - CORRENTE] Valor excede o saldo e o limite disponível de R$ {_saldo + _limite:F2}.");
        return false;
    }

    public override string ToString() =>
        base.ToString() + $" | Limite: R$ {_limite:F2}";
}

public class ContaPoupanca : Conta
{
    private decimal _taxaRendimento;

    public decimal TaxaRendimento
    {
        get => _taxaRendimento;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("A taxa de rendimento não pode ser negativa.");
            }
            _taxaRendimento = value;
        }
    }

    public ContaPoupanca(string numero, Pessoa titular, decimal saldoInicial, decimal taxaRendimento)
        : base(numero, titular, saldoInicial)
    {
        TaxaRendimento = taxaRendimento;
    }

    public override bool Sacar(decimal valor)
    {
        decimal taxaOperacao = 2.50m;
        decimal valorTotal = valor + taxaOperacao;

        if (valor <= 0)
        {
            throw new ArgumentException("O valor do saque deve ser maior que zero.");
        }

        if (_saldo >= valorTotal)
        {
            _saldo -= valorTotal;
            Console.WriteLine($"[SAQUE SOBRESCRITO - POUPANÇA] R$ {valor:F2} (+ R$ {taxaOperacao:F2} taxa de saque). Saldo restante: R$ {_saldo:F2}");
            return true;
        }

        Console.WriteLine($"[SAQUE RECUSADO - POUPANÇA] Saldo insuficiente para cobrir o saque e a taxa de R$ {taxaOperacao:F2}.");
        return false;
    }

    public override string ToString() =>
        base.ToString() + $" | Taxa Rendimento: {_taxaRendimento}%";
}

class Program
{
    static void Main()
    {
        Pessoa titular = new Pessoa("Carlos", 28);

        Conta cBase = new Conta("001", titular, 500.00m);
        ContaCorrente cCorrente = new ContaCorrente("002", titular, 200.00m, 300.00m);
        ContaPoupanca cPoupanca = new ContaPoupanca("003", titular, 500.00m, 0.5m);

        cBase.Sacar(400.00m);
        cCorrente.Sacar(450.00m);
        cPoupanca.Sacar(100.00m);
    }
}