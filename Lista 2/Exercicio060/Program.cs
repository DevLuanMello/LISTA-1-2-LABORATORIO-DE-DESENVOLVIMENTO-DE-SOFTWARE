using System;

int diasRestantes = CalcularDiasAteFinalDoAno();
Console.WriteLine(diasRestantes);

int CalcularDiasAteFinalDoAno()
{
    DateTime hoje = DateTime.Today;
    DateTime finalDoAno = new DateTime(hoje.Year, 12, 31);
    return (finalDoAno - hoje).Days;
}