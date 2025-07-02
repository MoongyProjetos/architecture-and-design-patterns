namespace Seguradora.Logica.PadroesEstruturais.Decorator;
public class CoberturaRoubo : IApolice
{
    private readonly IApolice _apolice;
    public CoberturaRoubo(IApolice apolice) => _apolice = apolice;

    public string Descricao() => _apolice.Descricao() + " + Cobertura Roubo";
    public decimal CalcularPremio() => _apolice.CalcularPremio() + 250;
}