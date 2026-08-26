using System;

string frase = "Esta é uma frase de teste.";
Console.WriteLine(frase);

int totalCaracteres = ContarCaracteres(frase);
Console.WriteLine(totalCaracteres);

int ContarCaracteres(string texto)
{
    if (string.IsNullOrEmpty(texto))
        return 0;

    return texto.Length;
}