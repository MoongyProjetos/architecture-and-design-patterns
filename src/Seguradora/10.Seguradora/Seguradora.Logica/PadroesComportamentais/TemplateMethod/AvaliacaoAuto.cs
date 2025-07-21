namespace Seguradora.Logica.PadroesComportamentais.TemplateMethod;

public class AvaliacaoAuto : AvaliacaoRisco
{
    protected override void ColetarDados() => Console.WriteLine("Coletando dados de veículo...");
    protected override void CalcularRisco() => Console.WriteLine("Calculando risco para seguro de automóvel...");

    protected override void EmitirRelatorio()
    {
        base.EmitirRelatorio();
        Console.WriteLine("Relatório específico para seguro de automóvel emitido.");
    }
}