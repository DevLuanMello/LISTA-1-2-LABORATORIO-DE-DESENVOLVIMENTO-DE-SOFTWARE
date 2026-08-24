string textoComNumeros = "50 25";

string[] valores = textoComNumeros.Split(' ');

int valor1 = int.Parse(valores[0]);
int valor2 = int.Parse(valores[1]);

int soma = valor1 + valor2;

Console.WriteLine(soma); 