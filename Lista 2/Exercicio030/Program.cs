List<int> numeros = new List<int> { 10, 20, 30, 40, 50 };
List<int> invertida = new List<int>();

for (int i = numeros.Count - 1; i >= 0; i--)
{
    invertida.Add(numeros[i]);
}

foreach (int numero in invertida)
{
    Console.WriteLine(numero);
}