namespace Seguradora.Logica.PadroesComportamentais.Observer;

public interface IClienteObserver
{
    public void Notificar(string mensagem);
}