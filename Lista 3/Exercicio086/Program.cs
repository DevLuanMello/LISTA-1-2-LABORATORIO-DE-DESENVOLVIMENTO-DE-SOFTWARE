using System;
using System.Collections.Generic;

public interface IPagavel
{
    bool Processar();
}

public interface IImprimivel
{
    void Imprimir();
}

public abstract class Pagamento : IPagavel, IImprimivel
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
    private string _qrCode;

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

    public string QrCode => _qrCode;

    public PagamentoPix(string id, decimal valor, string chavePix)
        : base(id, valor)
    {
        ChavePix = chavePix;
        _qrCode = $"00020126360014BR.GOV.BCB.PIX0114{ChavePix}5204000053039865405{valor:F2}";
    }

    public override bool Processar()
    {
        if (_pago)
        {
            return false;
        }

        _pago = true;
        return true;
    }

    public override void Imprimir()
    {
        base.Imprimir();
        Console.WriteLine($"   Tipo: Pix | Chave: {ChavePix}");
        Console.WriteLine($"   Copia e Cola (QR Code): {QrCode}");
    }
}

class Program
{
    static void Main()
    {
        PagamentoPix pix = new PagamentoPix("PIX-8821", 150.00m, "dev@empresa.com");

        pix.Imprimir();
        Console.WriteLine();

        bool sucesso = pix.Processar();
        Console.WriteLine($"Processamento efetuado: {sucesso}\n");

        pix.Imprimir();
    }
}