namespace Seguradora.Logica.PadroesCriacionais.FactoryMethod.Creators;

using Seguradora.Logica.PadroesCriacionais.Interfaces;

public class SeguroVidaCreator : SeguroCreator
{
    public override ISeguro CriarSeguro() => new SeguroVida();
}
