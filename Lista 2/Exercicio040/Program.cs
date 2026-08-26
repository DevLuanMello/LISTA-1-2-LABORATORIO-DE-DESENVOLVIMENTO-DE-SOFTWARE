List<Produto> produtos = new List<Produto>
{
    new Produto { Nome = "Notebook", Preco = 4500.00m },
    new Produto { Nome = "Mouse", Preco = 120.50m },
    new Produto { Nome = "Teclado", Preco = 250.00m }
};

foreach (Produto produto in produtos)
{
    Console.WriteLine($"Produto: {produto.Nome} | Preço: R$ {produto.Preco:F2}");
}

class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
}