namespace Seguradora.Logica.PadroesEstruturais.PrivateClassData;

public class ApoliceSeguro
{
    private readonly DadosApolice _dadosApolice;

    public ApoliceSeguro(string segurado, decimal premio, string cpf)
    {
        _dadosApolice = new DadosApolice(segurado, premio, cpf);
    }

    public string ObterSegurado() => _dadosApolice.Segurado;
    public decimal ObterPremio() => _dadosApolice.Premio;
    public string ObterCPFMascarado() => $"***.***.{_dadosApolice.CPF[^3..]}";
}