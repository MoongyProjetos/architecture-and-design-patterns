namespace Seguradora.Logica.PadroesComportamentais.Mediator;


/// <summary>
/// Classe abstrata representando um departamento na seguradora.
/// Cada departamento pode enviar e receber mensagens através de um mediador.
/// </summary>
public abstract class Departamento
{
    protected IMediador _mediador;
    public Departamento(IMediador mediador) => _mediador = mediador;
    public abstract void Receber(string mensagem);
}