public static class Calculos
{
    public static double CalcularSubtotal(double precoProduto, int quantidade)
    {
        return precoProduto * quantidade;
    }

    public static double AplicarDesconto(double subtotal, double desconto)
    {
        return subtotal * (1 - desconto);
    }

    public static double AplicarImposto(double subtotal, double imposto)
    {
        return subtotal * (1 + imposto);
    }
}