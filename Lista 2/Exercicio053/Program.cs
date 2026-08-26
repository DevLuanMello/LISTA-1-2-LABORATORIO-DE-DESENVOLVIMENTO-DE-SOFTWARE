using System;

string frase = "aprendendo programação em csharp";
Console.WriteLine(ContemPalavra(frase, "programação"));
Console.WriteLine(ContemPalavra(frase, "java"));

bool ContemPalavra(string texto, string palavra)
{
    if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(palavra))
        return false;

    return texto.Contains(palavra);
}