using System;

public class Funcionario
{
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }

    public Funcionario(string nome, string cargo, decimal salario)
    {
        Nome = nome;
        Cargo = cargo;
        Salario = salario;
    }

    public string ObterResumoFormatado()
    {
        return $"Colaborador: {Nome.ToUpper()} | Cargo: {Cargo} | Remuneração: {Salario:C2}";
    }
}

class Program
{
    static void Main()
    {
        Funcionario f1 = new Funcionario("Gabriel", "Desenvolvedor C#", 6500.50m);
        Funcionario f2 = new Funcionario("Mariana", "Analista de Sistemas", 7200.00m);

        Console.WriteLine(f1.ObterResumoFormatado());
        Console.WriteLine(f2.ObterResumoFormatado());
    }
}