namespace Seguradora.Logica.PadroesCriacionais.Builder;
public class ApoliceAutoBuilder : IApoliceBuilder
{
    private readonly ApolicePersonalizada _apolice;

    public ApoliceAutoBuilder()
    {
        _apolice = new ApolicePersonalizada();
    }

    public void DefinirTipo(string tipo)
    {
        _apolice.Tipo = tipo;
    }

    public void AdicionarAssistencia24h()
    {
        _apolice.Assistencia24h = true;
    }

    public void AdicionarCoberturaInternacional()
    {
        _apolice.CoberturaInternacional = true;
    }

    public void AdicionarProtecaoTerceiros()
    {
        _apolice.ProtecaoTerceiros = true;
    }

    public ClienteExemplo DefinirCliente()
    {
        // Aqui você pode definir um cliente padrão ou receber um cliente como parâmetro
        _apolice.Cliente = new ClienteExemplo
        {
            Id = Guid.NewGuid(),
            Nome = "Cliente Padrão",
            Endereco = "Endereço Padrão"
        };
        return _apolice.Cliente;
    }

    public ApolicePersonalizada Construir()
    {
        return _apolice;
    }
}
