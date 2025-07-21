namespace Seguradora.Logica.PadroesComportamentais.Iterator;

public class IteradorPropostas : IIteradorProposta
{
    private readonly List<Proposta> _propostas;
    private int _indiceAtual = 0;

    public IteradorPropostas(List<Proposta> propostas)
    {
        _propostas = propostas;
    }

    public bool TemProximo() => _indiceAtual < _propostas.Count;
    public Proposta Proximo() => _propostas[_indiceAtual++];
    public Proposta Primeiro()
    {
        _indiceAtual = 0;
        return _propostas[_indiceAtual];
    }
}