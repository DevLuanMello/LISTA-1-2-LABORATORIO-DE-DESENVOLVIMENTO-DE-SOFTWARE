bool EhPar(int numero)
{
    return numero % 2 == 0;
}

int valor = 42;

if (EhPar(valor))
{
    Console.WriteLine($"{valor} é par.");
}
else
{
    Console.WriteLine($"{valor} não é par.");
}