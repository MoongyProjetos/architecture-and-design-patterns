public abstract class SeguroCreator
{
  public abstract ISeguro CriarSeguro();

  public string ProcessarApolice()
  {
    var seguro = CriarSeguro();
    return seguro.EmitirApolice();
  }
}