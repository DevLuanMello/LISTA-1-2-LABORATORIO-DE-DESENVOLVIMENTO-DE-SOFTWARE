List<string> palavras = new List<string> { "sol", "computador", "casa", "desenvolvimento", "livro", "teclado" };
int contador = 0;

foreach (string palavra in palavras)
{
    if (palavra.Length > 5)
    {
        contador++;
    }
}

Console.WriteLine($"Quantidade de palavras com mais de 5 letras: {contador}");