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

public class Cliente : IAutenticavel, IImprimivel
{
    private string _nome;
    private string _cpf;
    private string _senha;

    public string Nome
    {
        get => _nome;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O nome não pode ser vazio.");
            }
            _nome = value;
        }
    }

    public string Cpf
    {
        get => _cpf;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O CPF não pode ser vazio.");
            }
            _cpf = value;
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

    public Cliente(string nome, string cpf, string senha)
    {
        Nome = nome;
        Cpf = cpf;
        Senha = senha;
    }

    public bool Autenticar(string senha)
    {
        return _senha == senha;
    }

    public void Imprimir()
    {
        Console.WriteLine($"[CLIENTE] Nome: {Nome,-15} | CPF: {Cpf}");
    }
}

class Program
{
    static void Main()
    {
        List<IAutenticavel> usuariosDoSistema = new List<IAutenticavel>
        {
            new Cliente("Mariana", "333.222.111-00", "cliente123")
        };

        foreach (IAutenticavel usuario in usuariosDoSistema)
        {
            if (usuario is IImprimivel imprimivel)
            {
                imprimivel.Imprimir();
            }

            Console.WriteLine($"Autenticação: {usuario.Autenticar("cliente123")}");
        }
    }
}