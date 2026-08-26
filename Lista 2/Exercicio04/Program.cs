Console.WriteLine("Digite o primeiro número:");
int num1 = int.Parse(Console.ReadLine());

Console.WriteLine("Digite o segundo número:");
int num2 = int.Parse(Console.ReadLine());

Console.WriteLine("Digite o terceiro número:");
int num3 = int.Parse(Console.ReadLine());

int maior = Math.Max(num1, Math.Max(num2, num3));

Console.WriteLine($"O maior número é: {maior}");