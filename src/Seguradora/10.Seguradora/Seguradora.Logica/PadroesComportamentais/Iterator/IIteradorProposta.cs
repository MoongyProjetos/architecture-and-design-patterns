namespace Seguradora.Logica.PadroesComportamentais.Iterator;

public interface IIteradorProposta
{
    Proposta Primeiro();
    Proposta Proximo();
    bool TemProximo();
}