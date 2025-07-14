namespace Seguradora.Logica.PadroesComportamentais.State;

public class Expirada : IEstadoApolice
{
    public void Processar() => Console.WriteLine("⚪ A apólice está EXPIRADA. Precisa ser renovada.");
}