using System;

DateTime dataFutura = AdicionarTrintaDias();
Console.WriteLine(dataFutura.ToString("dd/MM/yyyy"));

DateTime AdicionarTrintaDias()
{
    return DateTime.Now.AddDays(30);
}