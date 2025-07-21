namespace Seguradora.Logica.PadroesComportamentais.Mediator;

public class Emissao : Departamento
{
  public Emissao(IMediador m) : base(m) { }
    public override void Receber(string mensagem) => Console.WriteLine("Emissão recebeu: " + mensagem);
}