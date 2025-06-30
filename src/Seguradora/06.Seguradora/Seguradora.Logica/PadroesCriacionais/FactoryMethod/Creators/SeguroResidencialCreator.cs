namespace Seguradora.Logica.PadroesCriacionais.FactoryMethod.Creators;

using Seguradora.Logica.PadroesCriacionais.Interfaces;

public class SeguroResidencialCreator : SeguroCreator
{
    public override ISeguro CriarSeguro() => new SeguroResidencial();
}
