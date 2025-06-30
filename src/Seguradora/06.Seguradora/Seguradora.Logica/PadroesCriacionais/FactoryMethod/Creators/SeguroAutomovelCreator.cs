namespace Seguradora.Logica.PadroesCriacionais.FactoryMethod.Creators;

using Seguradora.Logica.PadroesCriacionais.Interfaces;

public class SeguroAutomovelCreator : SeguroCreator
{
    public override ISeguro CriarSeguro() => new SeguroAutomovel();
}
