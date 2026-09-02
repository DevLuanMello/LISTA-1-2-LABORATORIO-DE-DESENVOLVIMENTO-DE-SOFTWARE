using System;

public class Aluno
{
    private double _nota;

    public string Nome { get; set; }

    public double Nota
    {
        get => _nota;
        set
        {
            if (value < 0 || value > 10)
            {
                Console.WriteLine("Erro: A nota deve estar entre 0 e 10.");
                return;
            }
            _nota = value;
        }
    }

    public Aluno()
    {
    }

    public Aluno(string nome, double nota)
    {
        Nome = nome;
        Nota = nota;
    }

    public void ExibirDados()
    {
        Console.WriteLine($"Aluno: {Nome} | Nota: {Nota:F1}");
    }
}

class Program
{
    static void Main()
    {
        Aluno a1 = new Aluno("Lucas", 8.5);
        a1.ExibirDados();

        Aluno a2 = new Aluno("Beatriz", 11.0);
        a2.ExibirDados();

        a1.Nota = -2.0;
        a1.ExibirDados();
    }
}