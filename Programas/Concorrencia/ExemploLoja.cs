using System;
using System.Threading.Tasks;

public class Loja 
{
    private int _estoque = 1;
    private readonly object _lock = new object();

    // Método PERIGOSO (sem lock)
    public void ComprarPerigoso(string cliente)
    {
        if (_estoque > 0)
        {
            Console.WriteLine($"{cliente}: Adicionando ao carrinho...");
            _estoque--;
            Console.WriteLine($"{cliente}: Comprou! Estoque: {_estoque}");
        }
        else
        {
            Console.WriteLine($"{cliente}: Esgotado!");
        }
    }

    // Método SEGURO (com lock)
    public void ComprarSeguro(string cliente)
    {
        lock (_lock)
        {
            if (_estoque > 0)
            {
                Console.WriteLine($"{cliente}: Adicionando ao carrinho...");
                _estoque--;
                Console.WriteLine($"{cliente}: Comprou! Estoque: {_estoque}");
            }
            else
            {
                Console.WriteLine($"{cliente}: Esgotado!");
            }
        }
    }
}

class Program
{
    static async Task Main()
    {
        var loja = new Loja();
        
        Console.WriteLine("===== MÉTODO PERIGOSO =====");
        await SimularCompras(loja.ComprarPerigoso);
        
        loja = new Loja(); // Reset do estoque
        
        Console.WriteLine("\n===== MÉTODO SEGURO =====");
        await SimularCompras(loja.ComprarSeguro);
    }

    static async Task SimularCompras(Action<string> metodoCompra)
    {
        var tasks = new Task[5];
        for (int i = 0; i < 5; i++)
        {
            string cliente = $"Cliente-{i + 1}";
            tasks[i] = Task.Run(() => metodoCompra(cliente));
        }
        await Task.WhenAll(tasks);
    }
}