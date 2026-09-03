using System;

public class Funcionario
{
    private string _nome;
    private string _cargo;
    private decimal _salario;

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

    public string Cargo
    {
        get => _cargo;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O cargo não pode ser vazio.");
            }
            _cargo = value;
        }
    }

    public decimal Salario
    {
        get => _salario;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("O salário não pode ser negativo.");
            }
            _salario = value;
        }
    }

    public Funcionario(string nome, string cargo, decimal salarioInicial)
    {
        Nome = nome;
        Cargo = cargo;
        Salario = salarioInicial;
    }

    public void AumentarSalario(decimal percentual)
    {
        if (percentual <= 0)
        {
            throw new ArgumentException("O percentual de aumento deve ser positivo.");
        }

        Salario += Salario * (percentual / 100m);
    }

    public override string ToString() =>
        $"Nome: {Nome} | Cargo: {Cargo} | Salário: {Salario:C2}";
}

class Program
{
    static void Main()
    {
        Funcionario func = new Funcionario("Beatriz", "Analista de TI", 5000.00m);
        Console.WriteLine(func);

        func.Cargo = "Engenheira de Software";
        func.AumentarSalario(15);
        Console.WriteLine(func);
    }
}