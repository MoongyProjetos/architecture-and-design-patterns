namespace Seguradora.Logica.Builder;

public interface IApoliceBuilder
{
    ClienteExemplo DefinirCliente();
    void DefinirTipo(string tipo);
    void AdicionarAssistencia24h();
    void AdicionarCoberturaInternacional();
    void AdicionarProtecaoTerceiros();
    ApolicePersonalizada Construir(); //Esse de fato é o método que constrói a apólice personalizada, o builder por assim dizer :)
}