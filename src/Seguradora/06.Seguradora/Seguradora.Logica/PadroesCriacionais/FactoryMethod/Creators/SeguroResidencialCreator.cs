namespace Seguradora.Logica.PadroesCriacionais.FactoryMethod.Creators;

public class SeguroResidencialCreator : SeguroCreator
{
    public override ISeguro CriarSeguro() => new SeguroResidencial();
}
