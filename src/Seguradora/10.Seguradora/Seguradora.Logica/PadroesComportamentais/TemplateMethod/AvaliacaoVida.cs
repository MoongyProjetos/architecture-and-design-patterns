namespace Seguradora.Logica.PadroesComportamentais.TemplateMethod;

public class AvaliacaoVida : AvaliacaoRisco
{
    protected override void ColetarDados() => Console.WriteLine("Coletando dados de saúde...");
    protected override void CalcularRisco() => Console.WriteLine("Calculando risco para seguro de vida...");
}