List<int> numeros = new List<int> { 42, 15, 99, 8, 23 };

numeros.Sort();
numeros.Reverse();

foreach (int numero in numeros)
{
    Console.WriteLine(numero);
}