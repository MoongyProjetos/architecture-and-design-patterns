namespace Seguradora.Logica.PadroesEstruturais.Flyweight;

public class TabelaRiscoFactory
{
    private Dictionary<string, TabelaRisco> _cache = new();

    public TabelaRisco GetTabela(string tipo)
    {
        if (!_cache.ContainsKey(tipo))
            _cache[tipo] = new TabelaRisco(tipo, tipo == "Alta" ? 1.5m : 1.0m);
        return _cache[tipo];
    }
}