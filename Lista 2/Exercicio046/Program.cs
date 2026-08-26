string InverterString(string texto)
{
    char[] caracteres = texto.ToCharArray();
    Array.Reverse(caracteres);
    return new string(caracteres);
}

string original = "Desenvolvimento";
string invertida = InverterString(original);

Console.WriteLine($"Original: {original}");
Console.WriteLine($"Invertida: {invertida}");