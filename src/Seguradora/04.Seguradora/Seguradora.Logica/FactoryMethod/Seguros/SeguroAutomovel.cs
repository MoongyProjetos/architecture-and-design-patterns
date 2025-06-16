namespace Seguradora.Logica.FactoryMethod.Seguros;

public class SeguroAutomovel : ISeguro
{
    public string EmitirApolice()
    {
        // Lógica para emitir apólice de seguro de automóvel
        return "Apólice de Seguro de Automóvel emitida.";
    }
}