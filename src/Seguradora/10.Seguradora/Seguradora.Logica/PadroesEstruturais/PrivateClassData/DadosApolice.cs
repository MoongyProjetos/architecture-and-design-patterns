namespace Seguradora.Logica.PadroesEstruturais.PrivateClassData;

public class DadosApolice
{
    public string Segurado { get; }
    public decimal Premio { get; }
    public string CPF { get; }

    public DadosApolice(string segurado, decimal premio, string cpf)
    {
        Segurado = segurado;
        Premio = premio;
        CPF = cpf;
    }
}