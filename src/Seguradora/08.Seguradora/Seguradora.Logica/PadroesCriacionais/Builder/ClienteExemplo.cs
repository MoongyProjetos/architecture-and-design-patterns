namespace Seguradora.Logica.PadroesCriacionais.Builder;

public class ClienteExemplo
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Endereco { get; set; }

    public override string ToString()
    {
        return $"Cliente: {Nome}, Endereço: {Endereco}, ID: {Id}";
    }
}