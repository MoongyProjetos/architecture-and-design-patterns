namespace Seguradora.Logica.PadroesCriacionais.FactoryMethod.Seguros;
public class SeguroPet : ISeguro
{
    public string EmitirApolice()
    {
        // Lógica para emitir apólice de seguro de vida
        return "Apólice de Seguro de Animal emitida.";
    }
}