namespace Seguradora.Logica.PadroesEstruturais.Decorator;
class CoberturaRoubo : IApólice
{
    private readonly IApólice _apolice;
    public CoberturaRoubo(IApólice apolice) => _apolice = apolice;

    public string Descricao() => _apolice.Descricao() + " + Cobertura Roubo";
    public decimal CalcularPremio() => _apolice.CalcularPremio() + 250;
}