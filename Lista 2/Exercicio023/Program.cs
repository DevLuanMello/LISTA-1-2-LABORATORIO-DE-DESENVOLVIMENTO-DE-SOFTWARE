int contador = 0;
double soma = 0;
double numero;

do
{
    Console.Write("Digite um número (0 para finalizar e calcular a média): ");
    numero = double.Parse(Console.ReadLine());

    if (numero != 0)
    {
        soma += numero;
        contador++;
    }
} while (numero != 0);

if (contador > 0)
{
    Console.WriteLine($"A média é: {soma / contador}");
}