namespace Seguradora.Logica.PadroesCriacionais.Prototype;

public interface IApolicePrototype
{
    Apolice Clone();
    Apolice SimpleClone();
}