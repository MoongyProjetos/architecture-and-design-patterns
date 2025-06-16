public class SeguroVidaCreator : SeguroCreator
{
    public override ISeguro CriarSeguro() => new SeguroVida();
}