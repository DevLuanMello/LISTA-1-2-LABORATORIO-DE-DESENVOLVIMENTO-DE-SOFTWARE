using System;

DateTime data1 = new DateTime(2026, 8, 22);
DateTime data2 = new DateTime(2026, 8, 25);

Console.WriteLine(EhFimDeSemana(data1));
Console.WriteLine(EhFimDeSemana(data2));

bool EhFimDeSemana(DateTime data)
{
    return data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday;
}