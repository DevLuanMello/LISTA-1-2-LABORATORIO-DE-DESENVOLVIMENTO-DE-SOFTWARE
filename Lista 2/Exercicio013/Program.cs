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
    Console.WriteLine("Os três lados formam um triângulo!");
}
else
{
    Console.WriteLine("Esses lados não podem formar um triângulo.");
}