Dictionary<string, double> alunosNotas = new Dictionary<string, double>
{
    { "Ana", 8.5 },
    { "Bruno", 7.0 },
    { "Carlos", 9.2 },
    { "Diana", 6.5 }
};

Console.Write("Digite o nome do aluno: ");
string nomeBuscado = Console.ReadLine();

if (alunosNotas.ContainsKey(nomeBuscado))
{
    Console.WriteLine($"A nota de {nomeBuscado} é: {alunosNotas[nomeBuscado]}");
}
else
{
    Console.WriteLine("Aluno não encontrado.");
}