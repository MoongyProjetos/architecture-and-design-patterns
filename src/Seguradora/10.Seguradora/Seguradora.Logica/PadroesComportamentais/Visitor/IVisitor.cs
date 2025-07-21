namespace Seguradora.Logica.PadroesComportamentais.Visitor;

public interface IVisitor
{
    void Visitar(SeguroAuto seguro);
    void Visitar(SeguroVida seguro);
}
