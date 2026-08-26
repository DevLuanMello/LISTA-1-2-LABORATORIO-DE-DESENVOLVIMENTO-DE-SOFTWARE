using System;
using System.Linq;

Console.WriteLine(ValidarSenha("senha123"));
Console.WriteLine(ValidarSenha("SenhaForte123"));

bool ValidarSenha(string senha)
{
    if (string.IsNullOrWhiteSpace(senha) || senha.Length < 8)
        return false;

    return senha.Any(char.IsUpper) &&
           senha.Any(char.IsLower) &&
           senha.Any(char.IsDigit);
}