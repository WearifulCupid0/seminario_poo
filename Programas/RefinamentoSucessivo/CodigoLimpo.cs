using System;

public class Pedido
{
    public string NomeProduto { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }
}

public class ProcessadorPedidoRefinado
{
    // Método principal (fluxo claro)
    public void ProcessarDados(string input)
    {
        ValidarFormato(input);
        Pedido pedido = ExtrairDados(input);
        ValidarDados(pedido);
        SalvarNoBanco(pedido);
    }

    // Responsabilidade única: validação do formato
    private void ValidarFormato(string input)
    {
        if (input.Split(',').Length != 3)
            throw new ArgumentException("Formato inválido!");
    }

    // Responsabilidade única: extração de dados
    private Pedido ExtrairDados(string input)
    {
        string[] partes = input.Split(',');
        return new Pedido
        {
            NomeProduto = partes[0],
            Preco = double.Parse(partes[1]),
            Quantidade = int.Parse(partes[2])
        };
    }

    // Responsabilidade única: validação de regras de negócio
    private void ValidarDados(Pedido pedido)
    {
        if (pedido.Preco <= 0 || pedido.Quantidade <= 0)
            throw new ArgumentException("Dados inválidos!");
    }

    // Responsabilidade única: persistência
    private void SalvarNoBanco(Pedido pedido)
    {
        Console.WriteLine($"Salvando no banco: {pedido.NomeProduto}, R${pedido.Preco}, Quantidade: {pedido.Quantidade}");
    }
}