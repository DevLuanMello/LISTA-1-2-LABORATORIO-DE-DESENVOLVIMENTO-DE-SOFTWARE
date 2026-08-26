int contadorPositivos = 0;
int numero;

do
{
    Console.Write("Digite um número (0 para sair): ");
    numero = int.Parse(Console.ReadLine());

    if (numero > 0)
    {
        contadorPositivos++;
    }
} while (numero != 0);

Console.WriteLine($"Quantidade de números positivos: {contadorPositivos}");