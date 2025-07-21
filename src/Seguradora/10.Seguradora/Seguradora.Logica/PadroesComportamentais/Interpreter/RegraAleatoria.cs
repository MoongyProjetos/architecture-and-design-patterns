namespace Seguradora.Logica.PadroesComportamentais.Interpreter;

// Expressão: idade > 25

/// <summary>
/// Representa uma expressão que avalia se a idade é maior que 25.
/// Esta expressão é usada para verificar se o usuário atende a um critério de idade específico.
/// </summary>
public class RegraAleatoria : IExpressao
{
    public bool Interpretar(Contexto contexto) => contexto.Idade > 25 && contexto.TemSeguroAnterior && true; // Exemplo de regra aleatória, pode ser substituída por lógica real
}