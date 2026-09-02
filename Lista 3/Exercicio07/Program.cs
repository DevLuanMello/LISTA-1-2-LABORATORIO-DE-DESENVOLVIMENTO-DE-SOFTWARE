using System;

public class Produto
{
    private decimal _preco;

    public string Nome { get; set; }

    public decimal Preco
    {
        get => _preco;
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Erro: O preço deve ser maior que zero.");
                return;
            }
            _preco = value;
        }
    }

    public Produto()
    {
    }

    public Produto(string nome)
    {
        Nome = nome;
    }

    public Produto(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }

    public void ExibirDados()
    {
        Console.WriteLine($"Produto: {Nome} | Preço: R$ {Preco:F2}");
    }
}

class Program
{
    static void Main()
    {
        Produto prod1 = new Produto("Notebook", 3500.00m);
        prod1.ExibirDados();

        Produto prod2 = new Produto("Mouse", 0m);
        prod2.ExibirDados();

        Produto prod3 = new Produto("Teclado", -25.50m);
        prod3.ExibirDados();
    }
}