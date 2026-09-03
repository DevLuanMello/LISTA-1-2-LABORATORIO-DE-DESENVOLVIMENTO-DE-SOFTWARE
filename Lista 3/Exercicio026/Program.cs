using System;
using System.Collections.Generic;
using System.Linq;

public class Pedido
{
    private static int _proximoId = 1;

    public int Id { get; }
    public string Cliente { get; set; }
    public List<decimal> Itens { get; } = new List<decimal>();

    public Pedido(string cliente)
    {
        Id = _proximoId++;
        Cliente = cliente;
    }

    public void AdicionarItem(decimal valor)
    {
        if (valor > 0)
        {
            Itens.Add(valor);
        }
    }

    public decimal ObterValorTotal() => Itens.Sum(item => item);

    public decimal CalcularTotalComDesconto(decimal descontoPercentual = 0m, decimal taxaEntrega = 0m)
    {
        decimal total = ObterValorTotal();
        decimal valorDesconto = total * (descontoPercentual / 100m);
        return (total - valorDesconto) + taxaEntrega;
    }

    public override string ToString() =>
        $"Pedido ID: {Id} | Cliente: {Cliente} | Total Base: R$ {ObterValorTotal():F2}";
}

class Program
{
    static void Main()
    {
        Pedido pedido = new Pedido("Fernanda");
        pedido.AdicionarItem(100.00m);
        pedido.AdicionarItem(50.00m);

        Console.WriteLine(pedido);
        Console.WriteLine($"Total padrão: R$ {pedido.CalcularTotalComDesconto():F2}");
        Console.WriteLine($"Total com 10% de desconto: R$ {pedido.CalcularTotalComDesconto(10m):F2}");
        Console.WriteLine($"Total com 10% desconto + R$ 15 entrega: R$ {pedido.CalcularTotalComDesconto(10m, 15m):F2}");
        Console.WriteLine($"Total apenas com taxa de entrega (R$ 20): R$ {pedido.CalcularTotalComDesconto(taxaEntrega: 20m):F2}");
    }
}