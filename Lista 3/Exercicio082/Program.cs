using System;
using System.Collections.Generic;

public interface IIdentificavel
{
    string Id { get; }
    string CodigoFormatado { get; }
}

public class Produto : IIdentificavel
{
    private string _id;
    private string _nome;
    private decimal _preco;

    public string Id
    {
        get => _id;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O ID não pode ser vazio.");
            }
            _id = value;
        }
    }

    public string Nome
    {
        get => _nome;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O nome do produto não pode ser vazio.");
            }
            _nome = value;
        }
    }

    public decimal Preco
    {
        get => _preco;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("O preço deve ser maior que zero.");
            }
            _preco = value;
        }
    }

    public string CodigoFormatado => $"PRD-{Id}";

    public Produto(string id, string nome, decimal preco)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
    }
}

class Program
{
    static void Main()
    {
        IIdentificavel produto = new Produto("1052", "Teclado Mecânico", 250.00m);

        Console.WriteLine($"ID: {produto.Id}");
        Console.WriteLine($"Código Formatado: {produto.CodigoFormatado}");
    }
}