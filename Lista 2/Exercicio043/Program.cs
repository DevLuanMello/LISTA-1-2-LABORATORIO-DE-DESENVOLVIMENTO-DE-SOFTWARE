double CalcularMedia(List<double> numeros)
{
    if (numeros.Count == 0)
    {
        return 0;
    }

    double soma = 0;
    foreach (double numero in numeros)
    {
        soma += numero;
    }

    return soma / numeros.Count;
}

List<double> notas = new List<double> { 8.5, 7.0, 9.2, 6.5 };
double media = CalcularMedia(notas);

Console.WriteLine($"A média é: {media}");