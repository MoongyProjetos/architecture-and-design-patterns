public class SeguroAutomovelCreator : SeguroCreator
{
    public override ISeguro CriarSeguro() => new SeguroAutomovel();
}