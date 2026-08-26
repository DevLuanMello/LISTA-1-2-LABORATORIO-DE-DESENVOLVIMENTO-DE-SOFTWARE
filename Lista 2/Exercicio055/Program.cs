using System;

string texto = "paralelepipedo";
Console.WriteLine(texto);

string resultado = ExtrairTresPrimeiros(texto);
Console.WriteLine(resultado);

string ExtrairTresPrimeiros(string entrada)
{
    if (string.IsNullOrEmpty(entrada))
        return entrada;

    return entrada.Length >= 3 ? entrada.Substring(0, 3) : entrada;
}