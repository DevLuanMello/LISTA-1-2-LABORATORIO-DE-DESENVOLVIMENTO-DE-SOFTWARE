Console.Write("Digite o valor de N: ");
int n = int.Parse(Console.ReadLine());

int soma = 0; 

for (int i = 1; i <= n; i++)
{
    soma += i; 
}

Console.WriteLine($"A soma dos números de 1 até {n} é: {soma}");