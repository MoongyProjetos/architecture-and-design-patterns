namespace Seguradora.Logica.PadroesComportamentais.Strategy;

public class Seguro
{
    private ICalculoPremioStrategy _estrategia;

    public Seguro(ICalculoPremioStrategy estrategia)
    {
        _estrategia = estrategia;
    }

    public void DefinirEstrategia(ICalculoPremioStrategy estrategia)
    {
        _estrategia = estrategia;
    }

    public decimal Calcular(decimal valor, int idade)
    {
        return _estrategia.CalcularPremio(valor, idade);
    }
}