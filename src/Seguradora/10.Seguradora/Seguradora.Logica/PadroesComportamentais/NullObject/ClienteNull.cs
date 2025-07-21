namespace Seguradora.Logica.PadroesComportamentais.NullObject;

public class ClienteNull : ICliente
{
    public string ObterNome()
    {
        return "Cliente não encontrado";
    }

    public string ObterCodigoFiscal()
    {
        return "000.000.000-00";
    }
}
