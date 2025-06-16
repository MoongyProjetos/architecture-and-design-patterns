using Seguradora.Logica.FactoryMethod.Seguros;

namespace Seguradora.Logica.FactoryMethod.Creators;

public class SeguroResidencialCreator : SeguroCreator
{
    public override ISeguro CriarSeguro() => new SeguroResidencial();
}