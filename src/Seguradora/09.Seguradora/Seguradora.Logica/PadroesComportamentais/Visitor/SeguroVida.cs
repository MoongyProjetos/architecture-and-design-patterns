namespace Seguradora.Logica.PadroesComportamentais.Visitor;

public class SeguroVida : ISeguro
{
    public string Beneficiario { get; set; } = "João";
    public void Aceitar(IVisitor visitor) => visitor.Visitar(this);
}