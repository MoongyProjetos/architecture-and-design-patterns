namespace Seguradora.Logica.PadroesComportamentais.Mediator;

public interface IMediador
{
    void EnviarMensagem(string mensagem, Departamento origem);
}