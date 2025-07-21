namespace Seguradora.Logica.PadroesComportamentais.Visitor;

public class SeguroAuto : ISeguro
{
    public string Modelo { get; set; } = "Sedan";

    public void Aceitar(IVisitor visitor)
    {
        visitor.Visitar(this);
    }
}