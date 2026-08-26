List<int> numeros = new List<int> { 15, 42, 8, 99, 23, 76, 4 };
int maior = numeros[0];

foreach (int numero in numeros)
{
    if (numero > maior)
    {
        maior = numero;
    }
}

Console.WriteLine($"O maior número é: {maior}");