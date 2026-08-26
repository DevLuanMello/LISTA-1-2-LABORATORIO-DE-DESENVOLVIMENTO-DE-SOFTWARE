List<int> numeros = new List<int> { 15, 23, 42, 8, 99 };

Console.Write("Digite um número para buscar: ");
int numeroBuscado = int.Parse(Console.ReadLine());

if (numeros.Contains(numeroBuscado))
{
    Console.WriteLine("A lista contém o número informado.");
}
else
{
    Console.WriteLine("A lista não contém o número informado.");
}