using System;

public class Configuracao
{
    public string ChaveApi { get; init; }
    public string Ambiente { get; init; }
    public int TimeoutSegundos { get; set; }

    public Configuracao(string chaveApi, string ambiente)
    {
        ChaveApi = chaveApi;
        Ambiente = ambiente;
        TimeoutSegundos = 30;
    }

    public override string ToString() =>
        $"Ambiente: {Ambiente} | Timeout: {TimeoutSegundos}s | Chave: {ChaveApi}";
}

class Program
{
    static void Main()
    {
        Configuracao config1 = new Configuracao("ABC-123-XYZ", "Producao")
        {
            TimeoutSegundos = 60
        };

        Configuracao config2 = new Configuracao("DEV-999-TEST", "Desenvolvimento")
        {
            ChaveApi = "DEV-NOVA-CHAVE",
            TimeoutSegundos = 15
        };

        Console.WriteLine(config1);
        Console.WriteLine(config2);

        config1.TimeoutSegundos = 45;
        // config1.ChaveApi = "NOVA-CHAVE"; // Erro de compilação: propriedade 'init' não pode ser alterada após a inicialização
    }
}