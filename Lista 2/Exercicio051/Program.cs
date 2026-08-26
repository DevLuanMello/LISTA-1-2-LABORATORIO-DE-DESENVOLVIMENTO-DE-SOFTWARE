using System;

string texto = "exemplo de texto";
Console.WriteLine(texto);

string textoMaiusculo = ConverterParaMaiuscula(texto);
Console.WriteLine(textoMaiusculo);

string ConverterParaMaiuscula(string entrada)
{
    if (string.IsNullOrEmpty(entrada))
        return entrada;

    return entrada.ToUpper();
}