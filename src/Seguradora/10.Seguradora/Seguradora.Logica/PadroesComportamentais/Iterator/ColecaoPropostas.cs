namespace Seguradora.Logica.PadroesComportamentais.Iterator;

public class ColecaoPropostas
{
    private List<Proposta> _propostas = new();

    public void Adicionar(Proposta proposta) => _propostas.Add(proposta);
    public IIteradorProposta CriarIterador() => new IteradorPropostas(_propostas);
}