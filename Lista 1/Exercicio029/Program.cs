if (int.TryParse("abc", out int resultado))
{
    Console.WriteLine($"Sucesso: {resultado}");
}
else
{
    Console.WriteLine("Erro: isso não é um número válido!");
}