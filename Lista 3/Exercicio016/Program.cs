using System;

public class Aluno
{
    private double _nota;

    public readonly string Matricula;
    public string Nome { get; set; }
    public DateTime DataMatricula { get; private set; }

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

    public bool EstaAprovado => _nota >= 7.0;

    public Aluno(string matricula)
    {
        Matricula = matricula;
        DataMatricula = DateTime.Now;
    }

    public Aluno(string matricula, string nome, double nota) : this(matricula)
    {
        Nome = nome;
        Nota = nota;
    }

    public bool Aprovado()
    {
        return EstaAprovado;
    }

    public void ExibirDados()
    {
        string status = EstaAprovado ? "Aprovado" : "Reprovado";
        Console.WriteLine($"Matrícula: {Matricula} | Aluno: {Nome} | Nota: {Nota:F1} | Status: {status}");
    }
}

class Program
{
    static void Main()
    {
        Aluno a1 = new Aluno("2026001", "Lucas", 8.5);
        a1.ExibirDados();

        Console.WriteLine($"Matrícula do aluno (readonly): {a1.Matricula}");
    }
}