using System;

public class Aluno
{
    private double _nota;

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

    public Aluno()
    {
        DataMatricula = DateTime.Now;
    }

    public Aluno(string nome, double nota) : this()
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
        Console.WriteLine($"Aluno: {Nome} | Nota: {Nota:F1} | Status: {status} | Data de Matrícula: {DataMatricula:dd/MM/yyyy HH:mm:ss}");
    }
}

class Program
{
    static void Main()
    {
        Aluno a1 = new Aluno("Lucas", 8.5);
        a1.ExibirDados();

        Console.WriteLine($"Acessando propriedade DataMatricula (somente leitura externa): {a1.DataMatricula}");
    }
}