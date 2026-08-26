using System;

string data = FormatarDataAtual();
Console.WriteLine(data);

string FormatarDataAtual()
{
    return DateTime.Now.ToString("dd/MM/yyyy");
}