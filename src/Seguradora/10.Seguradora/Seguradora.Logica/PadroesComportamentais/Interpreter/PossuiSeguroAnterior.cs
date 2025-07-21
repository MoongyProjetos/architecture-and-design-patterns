namespace Seguradora.Logica.PadroesComportamentais.Interpreter;

// Expressão: possui seguro anterior

/// <summary>
/// Representa uma expressão que avalia se o usuário possui um seguro anterior.
/// Esta expressão é usada para verificar se o usuário já teve um seguro antes, o que pode
/// influenciar na aceitação de um novo seguro.
/// </summary>
public class PossuiSeguroAnterior : IExpressao
{
    public bool Interpretar(Contexto contexto) => contexto.TemSeguroAnterior;
}
