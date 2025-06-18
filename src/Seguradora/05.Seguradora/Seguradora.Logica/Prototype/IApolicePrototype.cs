namespace Seguradora.Logica.Prototype;

public interface IApolicePrototype
{
    Apolice Clone();
    Apolice SimpleClone();
}