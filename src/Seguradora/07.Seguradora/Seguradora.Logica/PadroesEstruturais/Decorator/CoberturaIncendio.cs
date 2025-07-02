class CoberturaIncendio : IApólice {
    private readonly IApólice _apolice;
    public CoberturaIncendio(IApólice apolice) => _apolice = apolice;

    public string Descricao() => _apolice.Descricao() + " + Cobertura Incêndio";
    public decimal CalcularPremio() => _apolice.CalcularPremio() + 400;
}