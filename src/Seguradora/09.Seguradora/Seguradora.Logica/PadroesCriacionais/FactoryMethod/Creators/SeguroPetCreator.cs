namespace Seguradora.Logica.PadroesCriacionais.FactoryMethod.Creators;

using Seguradora.Logica.PadroesCriacionais.Interfaces;

public class SeguroPetCreator : SeguroCreator
{
    public override ISeguro CriarSeguro() => new SeguroPet();
}
