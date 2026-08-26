using System;

DateTime dataInicial = new DateTime(2026, 8, 10);
DateTime dataFinal = new DateTime(2026, 8, 25);

TimeSpan diferenca = CalcularDiferenca(dataInicial, dataFinal);
Console.WriteLine(diferenca.Days);

TimeSpan CalcularDiferenca(DateTime inicio, DateTime fim)
{
    return fim - inicio;
}