namespace Seguradora.Logica.PadroesComportamentais.ChainOfResponsibility;

public abstract class Aprovador
{
    protected Aprovador Proximo;

    public void DefinirProximo(Aprovador proximo) => Proximo = proximo;
    public abstract void Aprovar(Sinistro sinistro);
}