using System;
using System.Collections.Generic;

public interface IValidavel
{
    bool Validar();
}

public class Usuario : IValidavel
{
    private string _email;
    private string _senha;

    public string Email
    {
        get => _email;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O e-mail não pode ser vazio.");
            }
            _email = value;
        }
    }

    public string Senha
    {
        get => _senha;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A senha não pode ser vazia.");
            }
            _senha = value;
        }
    }

    public Usuario(string email, string senha)
    {
        Email = email;
        Senha = senha;
    }

    public bool Validar()
    {
        return !string.IsNullOrWhiteSpace(Email)
            && Email.Contains("@")
            && !string.IsNullOrWhiteSpace(Senha)
            && Senha.Length >= 6;
    }
}

class Program
{
    static void Main()
    {
        IValidavel usuario1 = new Usuario("dev@empresa.com", "senha123");
        IValidavel usuario2 = new Usuario("emailinvalido", "123");

        Console.WriteLine($"Usuário 1 é válido? {usuario1.Validar()}");
        Console.WriteLine($"Usuário 2 é válido? {usuario2.Validar()}");
    }
}