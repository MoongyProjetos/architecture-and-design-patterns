namespace Seguradora.Logica.PadroesComportamentais.Visitor;

public interface ISeguro
{
    void Aceitar(IVisitor visitor);
}