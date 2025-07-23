
namespace Seguradora.Data.QueueService
{
    public class QueueServiceSimulado : IQueueService
    {
        public Task EnqueueAsync(string message)
        {
            Console.WriteLine($"[FILA] {message}");
            return Task.CompletedTask;
        }
    }
}
