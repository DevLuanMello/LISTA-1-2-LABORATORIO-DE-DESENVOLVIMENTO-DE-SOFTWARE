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

    public void ExibirDados()
    {
        Console.WriteLine($"Titular: {Titular} | Saldo: R$ {Saldo:F2}");
    }
}

class Program
{
    static void Main()
    {
        ContaBancaria conta1 = new ContaBancaria("Carlos", 1500.00m);
        conta1.ExibirDados();

        Console.WriteLine($"Consulta direta ao Saldo via Getter: R$ {conta1.Saldo:F2}");
    }
}