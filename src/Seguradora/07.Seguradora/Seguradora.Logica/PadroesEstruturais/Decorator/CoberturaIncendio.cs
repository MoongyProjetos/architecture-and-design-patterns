namespace Seguradora.Logica.PadroesEstruturais.Decorator;

public class CoberturaIncendio : IApolice
{
    private readonly IApolice _apolice;
    public CoberturaIncendio(IApolice apolice) => _apolice = apolice;

    public string Descricao() => _apolice.Descricao() + " + Cobertura Incêndio" + ExemploComplexo();
    public decimal CalcularPremio() => _apolice.CalcularPremio() + 400;

    /// <summary>
    /// Exemplo complexo de uso do Decorator
    /// Este método simula uma lógica complexa que poderia ser aplicada
    /// </summary>
    /// <returns></returns>
    private static string ExemploComplexo()
    {
        //Buscar dados do banco de dados
        // Validar dados
        // Realizar cálculos complexos
        // Exemplo complexo de uso do Decorator
        // Aqui você pode adicionar lógica adicional que envolva a apólice
        return "Exemplo complexo de uso do Decorator";
    }
}