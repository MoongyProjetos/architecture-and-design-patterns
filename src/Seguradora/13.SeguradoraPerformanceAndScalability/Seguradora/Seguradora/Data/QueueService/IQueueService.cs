namespace Seguradora.Data.QueueService
{
    // 5. Queue Service (simulado)
    public interface IQueueService
    {
        Task EnqueueAsync(string message);
    }
}
