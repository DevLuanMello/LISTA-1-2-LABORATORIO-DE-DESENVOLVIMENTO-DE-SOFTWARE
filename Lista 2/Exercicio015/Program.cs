Console.WriteLine("=== CALCULADORA SIMPLES ===");

Console.Write("Digite o primeiro número: ");
double num1 = double.Parse(Console.ReadLine());

Console.Write("Digite o operador (+, -, *, /): ");
char operador = char.Parse(Console.ReadLine());

Console.Write("Digite o segundo número: ");
double num2 = double.Parse(Console.ReadLine());

Console.WriteLine("---------------------------");

switch (operador)
{
    case '+':
        Console.WriteLine($"Resultado: {num1} + {num2} = {num1 + num2}");
        break;
    case '-':
        Console.WriteLine($"Resultado: {num1} - {num2} = {num1 - num2}");
        break;
    case '*':
        Console.WriteLine($"Resultado: {num1} * {num2} = {num1 * num2}");
        break;
    case '/':
        if (num2 != 0)
        {
            Console.WriteLine($"Resultado: {num1} / {num2} = {num1 / num2}");
        }
        else
        {
            Console.WriteLine("Erro: Não é possível dividir um número por zero!");
        }
        break;
    default:
        Console.WriteLine("Operador inválido! Tente usar apenas +, -, * ou /.");
        break;
}