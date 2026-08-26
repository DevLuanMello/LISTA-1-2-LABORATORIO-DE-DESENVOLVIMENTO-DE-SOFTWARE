Console.WriteLine("Digite o tamanho do primeiro lado:");
double lado1 = double.Parse(Console.ReadLine());

Console.WriteLine("Digite o tamanho do segundo lado:");
double lado2 = double.Parse(Console.ReadLine());

Console.WriteLine("Digite o tamanho do terceiro lado:");
double lado3 = double.Parse(Console.ReadLine());

bool formaTriangulo = (lado1 + lado2 > lado3) &&
                      (lado1 + lado3 > lado2) &&
                      (lado2 + lado3 > lado1);

if (formaTriangulo)
{
    if (lado1 == lado2 && lado2 == lado3)
    {
        Console.WriteLine("É um triângulo EQUILÁTERO (todos os lados iguais).");
    }
    else if (lado1 == lado2 || lado1 == lado3 || lado2 == lado3)
    {
        Console.WriteLine("É um triângulo ISÓSCELES (dois lados iguais).");
    }
    else
    {
        Console.WriteLine("É um triângulo ESCALENO (todos os lados diferentes).");
    }
}
else
{
    Console.WriteLine("Os valores informados NÃO podem formar um triângulo.");
}