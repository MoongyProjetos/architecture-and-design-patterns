public class SeguroResidencialCreator : SeguroCreator
{
    public override ISeguro CriarSeguro() => new SeguroResidencial();
}