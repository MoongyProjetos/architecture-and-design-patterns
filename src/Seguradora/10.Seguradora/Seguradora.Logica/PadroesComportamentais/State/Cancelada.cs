namespace Seguradora.Logica.PadroesComportamentais.State;

public class Cancelada : IEstadoApolice
{
    public void Processar() => Console.WriteLine("❌ A apólice está CANCELADA. Nenhuma ação permitida.");
}