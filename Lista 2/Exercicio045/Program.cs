int SomarLista(List<int> numeros)
{
    int soma = 0;
    foreach (int numero in numeros)
    {
        soma += numero;
    }
    return soma;
}

List<int> valores = new List<int> { 10, 25, 30, 15 };
int total = SomarLista(valores);

Console.WriteLine($"A soma dos elementos da lista é: {total}");