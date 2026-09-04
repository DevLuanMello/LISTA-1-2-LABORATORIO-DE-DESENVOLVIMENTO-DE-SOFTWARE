using System;
using System.Collections.Generic;

public interface IValidavel
{
    bool Validar();
}

public interface IImprimivel
{
    void Imprimir();
}

public class Pagamento : IValidavel, IImprimivel
{
    private string _id;
    private decimal _valor;
    private string _metodo;
    private bool _pago;

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

    public string Metodo
    {
        get => _metodo;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O método de pagamento não pode ser vazio.");
            }
            _metodo = value;
        }
    }

    public bool Pago => _pago;

    public Pagamento(string id, decimal valor, string metodo)
    {
        Id = id;
        Valor = valor;
        Metodo = metodo;
        _pago = false;
    }

    public bool Validar()
    {
        return !string.IsNullOrWhiteSpace(Id)
            && Valor > 0
            && !string.IsNullOrWhiteSpace(Metodo);
    }

    public void ProcessarPagamento()
    {
        if (!Validar())
        {
            throw new InvalidOperationException("Não é possível processar um pagamento inválido.");
        }
        _pago = true;
    }

    public void Imprimir()
    {
        string status = _pago ? "CONFIRMADO" : "PENDENTE";
        Console.WriteLine($"[PAGAMENTO #{Id}] Valor: R$ {Valor:F2} | Método: {Metodo} | Status: {status}");
    }
}

public class ProcessadorPagamento
{
    public void ExecutarTransacao(IValidavel validavel, IImprimivel imprimivel)
    {
        if (validavel.Validar())
        {
            if (validavel is Pagamento pagamento)
            {
                pagamento.ProcessarPagamento();
            }
            imprimivel.Imprimir();
        }
    }
}

class Program
{
    static void Main()
    {
        Pagamento pagamento = new Pagamento("PGT-9901", 350.50m, "Cartão de Crédito");
        ProcessadorPagamento processador = new ProcessadorPagamento();

        processador.ExecutarTransacao(pagamento, pagamento);
    }
}