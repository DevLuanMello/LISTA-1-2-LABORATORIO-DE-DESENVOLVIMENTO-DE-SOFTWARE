using System;
using System.Collections.Generic;
using System.Linq;

public class Pedido
{
    private static int _proximoId = 1;

    public int Id { get; }
    public string Cliente { get; set; }
    public List<decimal> Itens { get; } = new List<decimal>();

    public decimal ObterValorTotal() => Itens.Sum(item => item);

    public List<decimal> ObterItensAcimaDe(decimal valorMinimo) =>
        Itens.Where(item => item > valorMinimo).ToList();

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

    public override string ToString() =>
        $"Pedido ID: {Id} | Cliente: {Cliente} | Total: R$ {ObterValorTotal():F2}";
}

class Program
{
    static void Main()
    {
        Pedido pedido = new Pedido("Diego");
        pedido.AdicionarItem(50.00m);
        pedido.AdicionarItem(120.00m);
        pedido.AdicionarItem(15.50m);

        Console.WriteLine(pedido);

        var itensCaros = pedido.ObterItensAcimaDe(30.00m);
        Console.WriteLine($"Itens acima de R$ 30,00: {string.Join(", ", itensCaros)}");
    }
}