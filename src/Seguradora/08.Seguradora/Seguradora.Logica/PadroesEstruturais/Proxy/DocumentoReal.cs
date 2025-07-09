namespace Seguradora.Logica.PadroesEstruturais.Proxy;

public class DocumentoReal : IApresentadorDocumento
{
    private readonly string _arquivo;

    public DocumentoReal(string arquivo)
    {
        _arquivo = arquivo;
        Console.WriteLine($"Carregando documento: {_arquivo}");
    }
    
    public void Mostrar() => Console.WriteLine($"Mostrando: {_arquivo}");
} 