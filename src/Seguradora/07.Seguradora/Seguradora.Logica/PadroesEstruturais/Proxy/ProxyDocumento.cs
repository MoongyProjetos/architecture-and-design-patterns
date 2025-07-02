namespace Seguradora.Logica.PadroesEstruturais.Proxy;

public class ProxyDocumento : IApresentadorDocumento
{
    private DocumentoReal _real;
    private readonly string _arquivo;
    private readonly string _usuario;

    public ProxyDocumento(string arquivo, string usuario)
    {
        _arquivo = arquivo;
        _usuario = usuario;
    }

    public void Mostrar()
    {
        if (_usuario != "corretor")
        {
            Console.WriteLine("Acesso negado.");
            //Mostrar mensagem de erro ou log
            //Mostrar documento de erro
        }
        else
        {
            _real ??= new DocumentoReal(_arquivo);
            _real.Mostrar();
        }
    }
}