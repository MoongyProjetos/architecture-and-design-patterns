namespace Seguradora.Logica.PadroesComportamentais.TemplateMethod;

/// <summary>
/// Classe abstrata que define o template method para avaliação de risco.
/// Este método template define o esqueleto do algoritmo de avaliação, permitindo que subclasses implementem
/// </summary>
public abstract class AvaliacaoRisco
{

    // Método template que define o esqueleto do algoritmo. Reparem que ele é final, ou seja, não pode ser sobrescrito.
    public void RealizarAvaliacao()
    {
        ColetarDados();
        CalcularRisco();
        EmitirRelatorio();
    }

    #region Métodos Abstratos
    // Métodos abstratos devem ser implementados pelas subclasses

    /// <summary>
    /// Método abstrato que deve ser implementado pelas subclasses para coletar os dados necessários para a avaliação de risco.
    /// Este método é chamado no início do processo de avaliação.
    /// </summary>
    protected abstract void ColetarDados();
    protected abstract void CalcularRisco();

    #endregion Métodos Abstratos

    /// <summary>
    /// Método opcional que pode ser sobrescrito pelas subclasses.
    /// Este método é chamado após o cálculo do risco e antes da emissão do relatório.
    /// </summary>
    protected virtual void EmitirRelatorio()
    {
        Console.WriteLine("Relatório emitido.");
    }
}