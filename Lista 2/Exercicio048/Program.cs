using System;

int numero = 15;
Console.WriteLine(numero);

AtualizarValor(ref numero);

Console.WriteLine(numero);

void AtualizarValor(ref int valor)
{
    valor = valor * 2;
}