using System;
using System.Collections.Generic;

public interface IPagamento
{
    bool Processar();
}

public interface IImprimivel
{
    void Imprimir();
}

public abstract class Pagamento : IPagamento, IImprimivel
{
    private string _id;
    private decimal _valor;
    protected bool _pago;

    public string Id
    {
        get => _id;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O ID do pagamento não pode ser vazio.");
            }
            _id = value;
        }
    }

    public decimal Valor
    {
        get => _valor;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("O valor do pagamento deve ser maior que zero.");
            }
            _valor = value;
        }
    }

    public bool Pago => _pago;

    protected Pagamento(string id, decimal valor)
    {
        Id = id;
        Valor = valor;
        _pago = false;
    }

    public abstract bool Processar();

    public virtual void Imprimir()
    {
        string status = _pago ? "CONFIRMADO" : "PENDENTE";
        Console.WriteLine($"[PAGAMENTO #{Id}] Valor: R$ {Valor:F2} | Status: {status}");
    }
}

public class PagamentoPix : Pagamento
{
    private string _chavePix;

    public string ChavePix
    {
        get => _chavePix;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A chave Pix não pode ser vazia.");
            }
            _chavePix = value;
        }
    }

    public PagamentoPix(string id, decimal valor, string chavePix)
        : base(id, valor)
    {
        ChavePix = chavePix;
    }

    public override bool Processar()
    {
        if (_pago) return false;
        _pago = true;
        return true;
    }

    public override void Imprimir()
    {
        base.Imprimir();
        Console.WriteLine($"   Tipo: Pix | Chave: {ChavePix}");
    }
}

public class PagamentoCartao : Pagamento
{
    private string _numeroCartao;
    private int _parcelas;

    public string NumeroCartao
    {
        get => _numeroCartao;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 13)
            {
                throw new ArgumentException("Número de cartão inválido.");
            }
            _numeroCartao = value;
        }
    }

    public int Parcelas
    {
        get => _parcelas;
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("O número de parcelas deve ser no mínimo 1.");
            }
            _parcelas = value;
        }
    }

    public PagamentoCartao(string id, decimal valor, string numeroCartao, int parcelas)
        : base(id, valor)
    {
        NumeroCartao = numeroCartao;
        Parcelas = parcelas;
    }

    public override bool Processar()
    {
        if (_pago) return false;
        _pago = true;
        return true;
    }

    public override void Imprimir()
    {
        base.Imprimir();
        string cartaoMascarado = $"****.****.****.{NumeroCartao.Substring(NumeroCartao.Length - 4)}";
        Console.WriteLine($"   Tipo: Cartão | Cartão: {cartaoMascarado} | Parcelas: {Parcelas}x");
    }
}

class Program
{
    static void Main()
    {
        List<IPagamento> transacoes = new List<IPagamento>
        {
            new PagamentoPix("PIX-101", 120.50m, "suporte@empresa.com"),
            new PagamentoCartao("CC-202", 450.00m, "1234567890123456", 3)
        };

        foreach (IPagamento pagamento in transacoes)
        {
            pagamento.Processar();

            if (pagamento is IImprimivel itemImprimivel)
            {
                itemImprimivel.Imprimir();
                Console.WriteLine(new string('-', 55));
            }
        }
    }
}