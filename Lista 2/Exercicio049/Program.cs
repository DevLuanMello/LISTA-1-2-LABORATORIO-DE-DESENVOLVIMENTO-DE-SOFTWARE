using System;
using System.Collections.Generic;

var meusPares = ObterPares();

foreach (var par in meusPares)
{
    Console.WriteLine(par);
}

List<(int, string)> ObterPares()
{
    return new List<(int, string)>
    {
        (1, "Primeiro"),
        (2, "Segundo"),
        (3, "Terceiro")
    };
}