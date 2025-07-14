namespace Seguradora.Logica.PadroesComportamentais.State;

public class Emitida : IEstadoApolice
{
    public void Processar() => Console.WriteLine("🔵 A apólice está EMITIDA e pode ser paga.");
}