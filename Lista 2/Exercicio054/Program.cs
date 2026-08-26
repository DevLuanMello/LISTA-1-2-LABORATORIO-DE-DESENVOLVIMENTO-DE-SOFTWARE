using System;

string frase = "Eu gosto de maçã.";
Console.WriteLine(frase);

string resultado = SubstituirPalavra(frase, "maçã", "banana");
Console.WriteLine(resultado);

string SubstituirPalavra(string texto, string palavraAntiga, string palavraNova)
{
    if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(palavraAntiga))
        return texto;

    return texto.Replace(palavraAntiga, palavraNova);
}