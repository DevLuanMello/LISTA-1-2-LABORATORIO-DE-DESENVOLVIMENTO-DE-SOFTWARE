using System;
using System.Collections.Generic;

public interface IImprimivel
{
    void Imprimir();
}

public class Documento : IImprimivel
{
    private string _titulo;
    private string _conteudo;

    public string Titulo
    {
        get => _titulo;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O título não pode ser vazio.");
            }
            _titulo = value;
        }
    }

    public string Conteudo
    {
        get => _conteudo;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O conteúdo não pode ser vazio.");
            }
            _conteudo = value;
        }
    }

    public Documento(string titulo, string conteudo)
    {
        Titulo = titulo;
        Conteudo = conteudo;
    }

    public void Imprimir()
    {
        Console.WriteLine($"[DOCUMENTO: {Titulo.ToUpper()}]");
        Console.WriteLine($"Conteúdo: {Conteudo}");
    }
}

class Program
{
    static void Main()
    {
        IImprimivel doc = new Documento("Relatório Mensal", "Resumo das atividades do período.");
        doc.Imprimir();
    }
}