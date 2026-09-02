using System;

public class ContaBancaria
{
    private decimal _saldo;

    public string Titular { get; set; }

    public decimal Saldo
    {
        get => _saldo;
    }

    public ContaBancaria()
    {
    }

    public ContaBancaria(string titular, decimal saldoInicial)
    {
        Titular = titular;
        if (saldoInicial > 0)
        {
            _saldo = saldoInicial;
        }
    }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("Erro: O valor do depósito deve ser maior que zero.");
            return;
        }

        _saldo += valor;
        Console.WriteLine($"Depósito de R$ {valor:F2} realizado com sucesso.");
    }

    public void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("Erro: O valor do saque deve ser maior que zero.");
            return;
        }

        if (valor > _saldo)
        {
            Console.WriteLine("Erro: Saldo insuficiente para realizar o saque.");
            return;
        }

        _saldo -= valor;
        Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso.");
    }

    public void ExibirDados()
    {
        Console.WriteLine($"Titular: {Titular} | Saldo: R$ {Saldo:F2}");
    }
}

class Program
{
    static void Main()
    {
        ContaBancaria conta = new ContaBancaria("Carlos", 1000.00m);
        conta.ExibirDados();

        conta.Depositar(500.00m);
        conta.ExibirDados();

        conta.Sacar(300.00m);
        conta.ExibirDados();

        conta.Sacar(1500.00m);
        conta.Depositar(-50.00m);

        conta.ExibirDados();
    }
}