Console.WriteLine("=== MENU PRINCIPAL ===");
Console.WriteLine("1 - Cadastrar novo usuário");
Console.WriteLine("2 - Consultar saldo");
Console.WriteLine("3 - Alterar senha");
Console.WriteLine("4 - Sair do sistema");
Console.Write("Escolha uma opção: ");

int opcaoEscolhida = int.Parse(Console.ReadLine());

Console.WriteLine("-------------------------");

switch (opcaoEscolhida)
{
    case 1:
        Console.WriteLine("Você escolheu: Cadastrar novo usuário.");
        break;
    case 2:
        Console.WriteLine("Você escolheu: Consultar saldo.");
        break;
    case 3:
        Console.WriteLine("Você escolheu: Alterar senha.");
        break;
    case 4:
        Console.WriteLine("Você escolheu: Sair do sistema.");
        break;
    default:
        Console.WriteLine("Opção inválida! Escolha um número entre 1 e 4.");
        break;
}