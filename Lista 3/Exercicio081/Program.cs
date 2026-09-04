using System;
using System.Collections.Generic;

public interface IAutenticavel
{
    bool Autenticar(string senha);
}

public interface IImprimivel
{
    void Imprimir();
}

public class UsuarioSistema : IAutenticavel, IImprimivel
{
    private string _login;
    private string _email;
    private string _senha;

    public string Login
    {
        get => _login;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O login não pode ser vazio.");
            }
            _login = value;
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
            {
                throw new ArgumentException("O e-mail informado é inválido.");
            }
            _email = value;
        }
    }

    public string Senha
    {
        private get => _senha;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 6)
            {
                throw new ArgumentException("A senha deve ter no mínimo 6 caracteres.");
            }
            _senha = value;
        }
    }

    public UsuarioSistema(string login, string email, string senha)
    {
        Login = login;
        Email = email;
        Senha = senha;
    }

    public bool Autenticar(string senha)
    {
        return _senha == senha;
    }

    public void Imprimir()
    {
        Console.WriteLine($"[USUÁRIO SISTEMA] Login: {Login,-12} | E-mail: {Email}");
    }
}

class Program
{
    static void Main()
    {
        UsuarioSistema usuario = new UsuarioSistema("marcos.dev", "marcos@empresa.com", "senha123");

        // Utilizando como IImprimivel
        IImprimivel imprimivel = usuario;
        imprimivel.Imprimir();

        // Utilizando como IAutenticavel
        IAutenticavel autenticavel = usuario;
        bool sucesso = autenticavel.Autenticar("senha123");
        Console.WriteLine($"Autenticação efetuada com sucesso: {sucesso}");
    }
}