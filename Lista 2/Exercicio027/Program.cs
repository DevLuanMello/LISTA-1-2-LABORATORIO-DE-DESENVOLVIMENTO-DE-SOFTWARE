List<int> numeros = new List<int> { 10, 25, 30, 45, 50 };
int soma = 0;

foreach (int numero in numeros)
{
    soma += numero;
}

Console.WriteLine($"A soma dos elementos é: {soma}");