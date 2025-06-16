using Seguradora.Logica.FactoryMethod.Seguros;

namespace Seguradora.Logica.FactoryMethod.Creators;

public class SeguroVidaCreator : SeguroCreator
{
    public override ISeguro CriarSeguro() => new SeguroVida();
}