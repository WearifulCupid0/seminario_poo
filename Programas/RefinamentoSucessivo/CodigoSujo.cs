using System;

public class ProcessadorPedido
{
    // Método "sujo" com múltiplas responsabilidades
    public void ProcessarDados(string input)
    {
        // Parsing (extração de dados)
        string[] partes = input.Split(',');
        if (partes.Length != 3)
        {
            throw new ArgumentException("Formato inválido!");
        }

        string nomeProduto = partes[0];
        double preco = double.Parse(partes[1]);
        int quantidade = int.Parse(partes[2]);

        // Validação
        if (preco <= 0 || quantidade <= 0)
        {
            throw new ArgumentException("Dados inválidos!");
        }

        // "Salvamento no banco" (simulado)
        Console.WriteLine($"Salvando no banco: {nomeProduto}, R${preco}, Quantidade: {quantidade}");
    }
}