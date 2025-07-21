namespace Seguradora.Logica.PadroesComportamentais.Memento;

public class PropostaSeguro
{
    public string? Cliente { get; set; }
    public string? Cobertura { get; set; }
    public MementoProposta CriarMemento() => new(Cliente, Cobertura);

    public void Restaurar(MementoProposta memento)
    {
        Cliente = memento.Cliente;
        Cobertura = memento.Cobertura;
    }
}
