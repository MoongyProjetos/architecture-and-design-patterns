using Seguradora.Logica.FactoryMethod.Seguros;

namespace Seguradora.Logica.FactoryMethod.Creators;

public class SeguroAutomovelCreator : SeguroCreator
{
    public override ISeguro CriarSeguro() => new SeguroAutomovel();
}