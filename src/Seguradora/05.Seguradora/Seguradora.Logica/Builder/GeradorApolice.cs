namespace Seguradora.Logica.Builder;

public class GeradorApolice
{
    public ApolicePersonalizada CriarSimples(IApoliceBuilder builder)
    {
        builder.DefinirTipo("Auto Simples");
        builder.AdicionarAssistencia24h();
        builder.DefinirCliente();
        return builder.Construir();
    }

    public ApolicePersonalizada CriarCompleta(IApoliceBuilder builder)
    {
        builder.DefinirTipo("Auto Completa");
        builder.AdicionarAssistencia24h();
        builder.AdicionarCoberturaInternacional();
        builder.AdicionarProtecaoTerceiros();
        builder.DefinirCliente();
        return builder.Construir();
    }
}