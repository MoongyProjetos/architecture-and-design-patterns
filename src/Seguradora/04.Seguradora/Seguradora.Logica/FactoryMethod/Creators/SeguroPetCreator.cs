using Seguradora.Logica.FactoryMethod.Seguros;

namespace Seguradora.Logica.FactoryMethod.Creators;

public class SeguroPetCreator : SeguroCreator
{
    public override ISeguro CriarSeguro() => new SeguroPet();
}