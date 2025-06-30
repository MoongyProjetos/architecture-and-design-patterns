namespace Seguradora.Logica.PadroesCriacionais.FactoryMethod.Creators;

public class SeguroAutomovelCreator : SeguroCreator
{
    public override ISeguro CriarSeguro() => new SeguroAutomovel();
}
