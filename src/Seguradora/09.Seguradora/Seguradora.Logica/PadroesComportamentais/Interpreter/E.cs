namespace Seguradora.Logica.PadroesComportamentais.Interpreter;

// Expressão composta: E lógico

/// <summary>
/// Representa uma expressão lógica composta que avalia se ambas as expressões
/// (esquerda e direita) são verdadeiras.
/// </summary>
public class E : IExpressao
{
    private readonly IExpressao _esq, _dir, _complemento;
    public E(IExpressao esquerda, IExpressao direita, IExpressao complemento)
    {
        _esq = esquerda;
        _dir = direita;
        _complemento = complemento;
    }

    public bool Interpretar(Contexto contexto) => _esq.Interpretar(contexto) && _dir.Interpretar(contexto) && _complemento.Interpretar(contexto);
}