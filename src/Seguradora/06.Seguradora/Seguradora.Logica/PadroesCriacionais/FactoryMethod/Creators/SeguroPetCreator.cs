namespace Seguradora.Logica.PadroesCriacionais.FactoryMethod.Creators;

public class SeguroPetCreator : SeguroCreator
{
    public override ISeguro CriarSeguro() => new SeguroPet();
}
