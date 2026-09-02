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

    public void AplicarDesconto(double percentual)
    {
        if (percentual <= 0 || percentual > 100)
        {
            Console.WriteLine("Erro: Percentual de desconto inválido.");
            return;
        }

        decimal valorDesconto = _preco * (decimal)(percentual / 100.0);
        _preco -= valorDesconto;
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

        prod1.AplicarDesconto(10);
        prod1.ExibirDados();

        prod1.AplicarDesconto(-5);
        prod1.AplicarDesconto(150);
    }
}