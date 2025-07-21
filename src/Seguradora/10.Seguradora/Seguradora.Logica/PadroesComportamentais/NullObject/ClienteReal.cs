namespace Seguradora.Logica.PadroesComportamentais.NullObject;

public class ClienteReal : ICliente
{
    private string _nome;
    private string _codigoFiscal;

    public ClienteReal(string nome, string codigoFiscal)
    {
        _nome = nome;
        _codigoFiscal = codigoFiscal;
    }

    public string ObterNome()
    {
        return _nome;
    }

    public string ObterCodigoFiscal()
    {
        return _codigoFiscal;
    }
}
