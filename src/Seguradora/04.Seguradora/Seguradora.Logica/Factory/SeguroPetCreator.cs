public class SeguroPetCreator : SeguroCreator
{
    public override ISeguro CriarSeguro() => new SeguroPet();
}