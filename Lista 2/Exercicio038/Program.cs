Dictionary<int, string> produtos = new Dictionary<int, string>
{
    { 101, "Teclado" },
    { 102, "Mouse" },
    { 103, "Monitor" }
};

foreach (KeyValuePair<int, string> item in produtos)
{
    Console.WriteLine($"Chave: {item.Key} - Valor: {item.Value}");
}