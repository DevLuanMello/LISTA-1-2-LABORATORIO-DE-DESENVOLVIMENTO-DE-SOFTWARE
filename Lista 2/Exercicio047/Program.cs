DateTime nascimento = new DateTime(1998, 5, 20);
int idadeAtual = CalcularIdade(nascimento);

Console.WriteLine($"A idade é: {idadeAtual} anos.");

int CalcularIdade(DateTime dataNascimento)
{
    DateTime hoje = DateTime.Today;
    int idade = hoje.Year - dataNascimento.Year;

    // Subtrai 1 se o aniversário ainda não ocorreu neste ano
    if (dataNascimento.Date > hoje.AddYears(-idade))
    {
        idade--;
    }

    return idade;
}