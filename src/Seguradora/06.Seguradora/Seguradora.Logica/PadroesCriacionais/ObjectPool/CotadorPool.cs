namespace Seguradora.Logica.PadroesCriacionais.ObjectPool;

public class CotadorPool
{
    private readonly Stack<Cotador> _disponiveis = new();
    private readonly int _maximo;
    private int _emUso;

    // Exemplo .net 6.0
    // public CotadorPool(int maximo) => _maximo = maximo;

    public CotadorPool(int maximo)
    {
        _maximo = maximo;
    }

    public Cotador ObterCotador()
    {
        if (_disponiveis.Count > 0)
        {
            _emUso++;
            return _disponiveis.Pop();
        }

        if (_emUso < _maximo)
        {
            _emUso++;
            return new Cotador();
        }

        throw new InvalidOperationException("Nenhum cotador disponível no pool.");
    }

    public void DevolverCotador(Cotador cotador)
    {
        _disponiveis.Push(cotador);
        _emUso--;
    }
}