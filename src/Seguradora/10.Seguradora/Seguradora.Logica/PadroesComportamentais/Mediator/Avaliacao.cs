namespace Seguradora.Logica.PadroesComportamentais.Mediator;

public class Avaliacao : Departamento
{
    public Avaliacao(IMediador m) : base(m) { }

    public override void Receber(string mensagem)
    {
        Console.WriteLine($"Avaliacao recebeu a mensagem: {mensagem}");
        _mediador.EnviarMensagem("Proposta avaliada com sucesso.", this);
    }
    public void EnviarMensagem(string msg) => _mediador.EnviarMensagem(msg, this);
}