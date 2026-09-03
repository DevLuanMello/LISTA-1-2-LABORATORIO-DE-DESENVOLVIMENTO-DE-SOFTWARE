using System;

public class Pedido
{
    private static int _proximoId = 1;

    public int Id { get; }
    public string Cliente { get; set; }
    public decimal ValorTotal { get; set; }

    public Pedido(string cliente, decimal valorTotal)
    {
        Id = _proximoId++;
        Cliente = cliente;
        ValorTotal = valorTotal;
    }

    public override string ToString()
    {
        return $"Pedido ID: {Id} | Cliente: {Cliente} | Total: R$ {ValorTotal:F2}";
    }
}

class Program
{
    static void Main()
    {
        Pedido p1 = new Pedido("Ana", 150.50m);
        Pedido p2 = new Pedido("Bruno", 89.90m);
        Pedido p3 = new Pedido("Carla", 310.00m);

        Console.WriteLine(p1);
        Console.WriteLine(p2);
        Console.WriteLine(p3);
    }
}