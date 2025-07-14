namespace Seguradora.Logica.PadroesComportamentais.Observer;

public class Apolice
{
    private readonly List<IClienteObserver> _clientes = [];
    public string Numero { get; }

    public Apolice(string numero)
    {
        Numero = numero;
    }

    public void AdicionarCliente(IClienteObserver cliente)
    {
        _clientes.Add(cliente);
    }


    public void AtualizarApolice(string detalhe)
    {
        Console.WriteLine($"Apólice {Numero} atualizada: {detalhe}");
        NotificarClientes($"Sua apólice {Numero} foi atualizada: {detalhe}");
    }

    private void NotificarClientes(string mensagem)
    {
        foreach (var cliente in _clientes)
        {
            cliente.Notificar(mensagem);
        }
    }
}