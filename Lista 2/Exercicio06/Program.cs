int ano = 2024;

bool ehBissexto = (ano % 4 == 0 && ano % 100 != 0) || (ano % 400 == 0);

if (ehBissexto)
{
    Console.WriteLine($"{ano} é um ano bissexto!");
}
else
{
    Console.WriteLine($"{ano} não é um ano bissexto.");
}