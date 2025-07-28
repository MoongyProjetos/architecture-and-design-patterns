using Polly;
using Polly.CircuitBreaker;

namespace PadroesResiliencia
{
    public static class Exemplos
    {

        /// <summary>
        /// Exemplo de uso do padrão Retry com Polly.
        /// Este exemplo demonstra como implementar uma política de retry para lidar com falhas temporárias em chamadas HTTP.
        /// A política tenta novamente a operação até 3 vezes, com um tempo de espera exponencial entre as tentativas.
        /// É útil para melhorar a resiliência de aplicações que dependem de serviços externos.
        /// </summary>
        /// <returns></returns>
        public static async Task ExemploUsoRetry()
        {
            var retryPolicy = Policy
                                .Handle<HttpRequestException>()
                                .WaitAndRetryAsync(3, retryAttempt =>
                                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            var client = new HttpClient();
            await retryPolicy.ExecuteAsync(async () =>
            {
                var response = await client.GetAsync("https://meuservico.azurewebsites.net/api/dados");
                response.EnsureSuccessStatusCode();
            });
        }



        /// <summary>
        /// Exemplo de uso do padrão Circuit Breaker com Polly.
        /// Este exemplo demonstra como implementar um circuito que abre após um número específico de falhas consecutivas,
        /// evitando chamadas a um serviço que está falhando repetidamente.
        /// O circuito permanece aberto por um período definido, permitindo que o serviço se recupere antes de novas tentativas.
        /// </summary>
        /// <returns></returns>
        public static async Task ExemploUsoCircuitBreaker()
        {
            var breakerPolicy = Policy
                            .Handle<HttpRequestException>()
                            .CircuitBreakerAsync(
                                exceptionsAllowedBeforeBreaking: 2,
                                durationOfBreak: TimeSpan.FromSeconds(30));

            var client = new HttpClient();
            try
            {
                await breakerPolicy.ExecuteAsync(async () =>
                {
                    var response = await client.GetAsync("https://servico-interno/api/falhas");
                    response.EnsureSuccessStatusCode();
                });
            }
            catch (BrokenCircuitException)
            {
                Console.WriteLine("Circuito aberto. Ignorando chamada.");
            }
        }



        /// <summary>
        /// Exemplo de uso do padrão Timeout com CancellationToken.
        /// Este exemplo demonstra como implementar um timeout para operações assíncronas,
        /// permitindo que uma operação seja cancelada se não for concluída dentro de um período específico.
        /// É útil para evitar que operações pendentes bloqueiem recursos por muito tempo.
        /// </summary>
        /// <returns></returns>
        public static async Task ExemploUsoTimeOutCancellationToken()
        {
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            var client = new HttpClient();
            try
            {
                var response = await client.GetAsync("https://servico-lento", cts.Token);
                response.EnsureSuccessStatusCode();
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Timeout atingido.");
            }
        }


        /// <summary>
        /// Exemplo de uso do padrão Bulkhead com Polly.
        /// Este exemplo demonstra como limitar o número de operações concorrentes e o número de requisições
        /// pendentes em uma fila, evitando sobrecarga de recursos.
        /// O Bulkhead é útil para isolar falhas e garantir que um serviço não seja sobrecarregado por muitas requisições simultâneas.
        /// </summary>
        /// <returns></returns>
        public static async Task ExemploUsoBulkHead()
        {
            var bulkhead = Policy.BulkheadAsync<HttpResponseMessage>(maxParallelization: 3, maxQueuingActions: 2);
            var client = new HttpClient();

            await bulkhead.ExecuteAsync(async () =>
            {
                return await client.GetAsync("https://servico-concorrente");
            });
        }
    }
}
