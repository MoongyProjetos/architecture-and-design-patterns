namespace Seguradora.Logica.PadroesCriacionais.FactoryMethod.Creators;

public class SeguroVidaCreator : SeguroCreator
{
    public override ISeguro CriarSeguro() => new SeguroVida();
}
