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
        Console.WriteLine($"[DOCUMENTO] Título: {Titulo} | Conteúdo: {Conteudo}");
    }
}

public class Relatorio : IImprimivel
{
    private string _autor;

    public string Autor
    {
        get => _autor;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O autor não pode ser vazio.");
            }
            _autor = value;
        }
    }

    public Relatorio(string autor)
    {
        Autor = autor;
    }

    public void Imprimir()
    {
        Console.WriteLine($"[RELATÓRIO EXECUÇÃO] Gerado por: {Autor}");
    }
}

public class Impressora
{
    // A interface IImprimivel é usada como parâmetro no método
    public void ProcessarImpressao(IImprimivel item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "O item para impressão não pode ser nulo.");
        }

        Console.WriteLine("--- Enviando para a fila de impressão ---");
        item.Imprimir();
        Console.WriteLine("------------------------------------------\n");
    }

    // Método que aceita uma coleção de objetos que implementam a interface
    public void ProcessarLote(IEnumerable<IImprimivel> itens)
    {
        foreach (IImprimivel item in itens)
        {
            ProcessarImpressao(item);
        }
    }
}

class Program
{
    static void Main()
    {
        Impressora impressora = new Impressora();

        IImprimivel doc = new Documento("Contrato", "Termos do contrato de serviço.");
        IImprimivel relatorio = new Relatorio("Ana Maria");

        // Passando objetos diretamente para o método que aceita a interface como parâmetro
        impressora.ProcessarImpressao(doc);
        impressora.ProcessarImpressao(relatorio);

        // Processando em lote
        List<IImprimivel> lote = new List<IImprimivel> { doc, relatorio };
        impressora.ProcessarLote(lote);
    }
}