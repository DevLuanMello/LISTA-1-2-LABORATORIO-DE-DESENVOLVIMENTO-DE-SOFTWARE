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

    public bool Aprovado()
    {
        return _nota >= 7.0;
    }

    public void ExibirDados()
    {
        string status = Aprovado() ? "Aprovado" : "Reprovado";
        Console.WriteLine($"Aluno: {Nome} | Nota: {Nota:F1} | Status: {status}");
    }
}

class Program
{
    static void Main()
    {
        Aluno a1 = new Aluno("Lucas", 8.5);
        a1.ExibirDados();
        Console.WriteLine($"Lucas está aprovado? {a1.Aprovado()}");

        Aluno a2 = new Aluno("Beatriz", 5.5);
        a2.ExibirDados();
        Console.WriteLine($"Beatriz está aprovada? {a2.Aprovado()}");
    }
}