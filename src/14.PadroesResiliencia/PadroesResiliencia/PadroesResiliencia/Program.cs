// See https://aka.ms/new-console-template for more information
using PadroesResiliencia;

const string separador = "#####################################################################################";

await Exemplos.ExemploUsoRetry();
Console.WriteLine(separador);

await Exemplos.ExemploUsoCircuitBreaker();
Console.WriteLine(separador);

await Exemplos.ExemploUsoTimeOutCancellationToken();
Console.WriteLine(separador);

await Exemplos.ExemploUsoBulkHead();
Console.WriteLine(separador);