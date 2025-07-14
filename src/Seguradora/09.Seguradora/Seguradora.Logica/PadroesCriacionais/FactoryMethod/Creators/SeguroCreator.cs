namespace Seguradora.Logica.PadroesCriacionais.FactoryMethod.Creators;

using Seguradora.Logica.PadroesCriacionais.Interfaces;

public abstract class SeguroCreator
{
    public abstract ISeguro CriarSeguro();

    public string ProcessarApolice()
    {
        var seguro = CriarSeguro();
        return seguro.EmitirApolice();
    }
}
