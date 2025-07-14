namespace Seguradora.Logica.PadroesComportamentais.State;

public class EmAnalise : IEstadoApolice
{
    public void Processar() => Console.WriteLine("🟡 A apólice está EM ANÁLISE. Aguardando validação.");
}