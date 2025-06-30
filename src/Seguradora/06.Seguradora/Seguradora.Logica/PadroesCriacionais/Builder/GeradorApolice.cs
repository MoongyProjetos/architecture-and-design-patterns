namespace Seguradora.Logica.PadroesCriacionais.Builder;
public class GeradorApolice
{
    public static ApolicePersonalizada CriarSimples(IApoliceBuilder builder)
    {
        builder.DefinirTipo("Auto Simples");
        builder.AdicionarAssistencia24h();
        builder.DefinirCliente();
        return builder.Construir();
    }

    public static ApolicePersonalizada CriarCompleta(IApoliceBuilder builder)
    {
        builder.DefinirTipo("Auto Completa");
        builder.AdicionarAssistencia24h();
        builder.AdicionarCoberturaInternacional();
        builder.AdicionarProtecaoTerceiros();
        builder.DefinirCliente();
        return builder.Construir();
    }
}