namespace Seguradora.Logica.PadroesCriacionais.ObjectPool;
public class Cotador
{
    // Já inicializa com um ID aleatório
    public Guid Id => Guid.NewGuid();

    public void RealizarCotacao(string nif)
    {
        Console.WriteLine($"Cotações em execução para: {nif}");
        // Simula processamento pesado
        Thread.Sleep(1000);  //Demora 1 segundo para simular uma operação de cotação
    }
}