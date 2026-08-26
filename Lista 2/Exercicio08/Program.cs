double peso = 75.5; 
double altura = 1.75; 
double imc = peso / (altura * altura);

Console.WriteLine($"Seu IMC é: {imc:F2}");

if (imc < 18.5)
{
    Console.WriteLine("Classificação: Abaixo do peso");
}
else if (imc < 25)
{
    Console.WriteLine("Classificação: Peso normal");
}
else if (imc < 30)
{
    Console.WriteLine("Classificação: Sobrepeso");
}
else if (imc < 35)
{
    Console.WriteLine("Classificação: Obesidade Grau I");
}
else if (imc < 40)
{
    Console.WriteLine("Classificação: Obesidade Grau II");
}
else
{
    Console.WriteLine("Classificação: Obesidade Grau III (Mórbida)");
}