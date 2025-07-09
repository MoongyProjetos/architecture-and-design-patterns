namespace Seguradora.Logica.PadroesComportamentais.Command;
public class CancelarApoliceCommand : IComandoApolice
{
    private readonly GestorApolices _gestor;
    private readonly string _numero;

    public CancelarApoliceCommand(GestorApolices gestor, string numero)
    {
        _gestor = gestor;
        _numero = numero;
    }

    public void Executar()
    {
        _gestor.Cancelar(_numero);
    }
}