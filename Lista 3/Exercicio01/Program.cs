using System;

public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Pessoa()
    {
    }

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }
}

class Program
{
    static void Main()
    {
        Pessoa pessoa1 = new Pessoa();
        pessoa1.Nome = "Ana";
        pessoa1.Idade = 20;

        Pessoa pessoa2 = new Pessoa("Carlos", 25);

        Console.WriteLine($"Pessoa 1 - Nome: {pessoa1.Nome}, Idade: {pessoa1.Idade}");
        Console.WriteLine($"Pessoa 2 - Nome: {pessoa2.Nome}, Idade: {pessoa2.Idade}");
    }
}