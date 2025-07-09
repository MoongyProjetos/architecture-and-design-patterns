namespace Seguradora.Logica.PadroesComportamentais.Observer;

//A implementacão do padrão Observer para notificar os clientes sobre eventos importantes.

public class ClienteObserver : IClienteObserver
{
    public string Nome { get; }

    public ClienteObserver(string nome)
    {
        Nome = nome;
    }

    public void Notificar(string mensagem)
    {
        Console.WriteLine($"{Nome} recebeu notificação: {mensagem}");
    }
}