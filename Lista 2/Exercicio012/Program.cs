Console.Write("Digite a nota (de 0 a 100): ");
int nota = int.Parse(Console.ReadLine());

switch (nota)
{
    case >= 90 and <= 100:
        Console.WriteLine("Classificação: A - Excelente!");
        break;
    case >= 80 and < 90:
        Console.WriteLine("Classificação: B - Muito bom!");
        break;
    case >= 70 and < 80:
        Console.WriteLine("Classificação: C - Bom.");
        break;
    case >= 60 and < 70:
        Console.WriteLine("Classificação: D - Na média.");
        break;
    case >= 0 and < 60:
        Console.WriteLine("Classificação: F - Reprovado.");
        break;
    default:
        Console.WriteLine("Nota inválida! Digite um valor entre 0 e 100.");
        break;
}