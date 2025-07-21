namespace Seguradora.Logica.PadroesComportamentais.Interpreter;

// Contexto com os dados de entrada da regra
/// <summary>
/// Representa o contexto que contém os dados necessários para avaliar as expressões.
/// Contém propriedades como Idade e TemSeguroAnterior que são usadas pelas expressões.
/// </summary>
public class Contexto
{
    public int Idade { get; set; }
    public bool TemSeguroAnterior { get; set; }
}