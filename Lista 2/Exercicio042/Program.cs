int ObterMaior(int a, int b)
{
    if (a > b)
    {
        return a;
    }
    return b;
}

int maior = ObterMaior(42, 89);
Console.WriteLine($"O maior número é: {maior}");