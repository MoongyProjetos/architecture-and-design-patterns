namespace Seguradora.Logica.PadroesComportamentais.Interpreter;

// Interface de expressão
public interface IExpressao
{
    bool Interpretar(Contexto contexto);
}