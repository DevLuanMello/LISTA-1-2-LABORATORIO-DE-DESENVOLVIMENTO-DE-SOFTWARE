Dictionary<string, double> alunosNotas = new Dictionary<string, double>
{
    { "Ana", 8.5 },
    { "Bruno", 7.0 },
    { "Carlos", 9.2 },
    { "Diana", 6.5 }
};

foreach (KeyValuePair<string, double> aluno in alunosNotas)
{
    Console.WriteLine($"{aluno.Key}: {aluno.Value}");
}