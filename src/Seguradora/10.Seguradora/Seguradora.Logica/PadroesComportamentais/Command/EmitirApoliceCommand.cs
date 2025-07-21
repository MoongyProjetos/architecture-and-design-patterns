namespace Seguradora.Logica.PadroesComportamentais.Command;

public class EmitirApoliceCommand : IComandoApolice
{
    private readonly GestorApolices _gestor;
    private readonly string _numero;

    public EmitirApoliceCommand(GestorApolices gestor, string numero)
    {
        _gestor = gestor;
        _numero = numero;
    }

    public void Executar()
    {
        _gestor.Emitir(_numero);
    }
}
