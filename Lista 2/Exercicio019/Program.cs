Console.Write("Digite um número para calcular o fatorial: ");
int numero = int.Parse(Console.ReadLine());

long fatorial = 1;

for (int i = 1; i <= numero; i++)
{
    fatorial *= i;
}

Console.WriteLine($"O fatorial de {numero}! é: {fatorial}");