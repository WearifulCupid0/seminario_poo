// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main(string[] args)
    {
        double precoProduto = 100.0;
        int quantidade = 2;
        double desconto = 0.1;
        double imposto = 0.2;

        double subtotal = CalcularSubtotal(precoProduto, quantidade);
        double subtotalComDesconto = AplicarDesconto(subtotal, desconto);
        double total = AplicarImposto(subtotalComDesconto, imposto);

        Console.WriteLine($"O preço total é: {total:F2}");
    }

    static double CalcularSubtotal(double precoProduto, int quantidade)
    {
        return precoProduto * quantidade;
    }

    static double AplicarDesconto(double subtotal, double desconto)
    {
        return subtotal * (1 - desconto);
    }

    static double AplicarImposto(double subtotal, double imposto)
    {
        return subtotal * (1 + imposto);
    }
}
