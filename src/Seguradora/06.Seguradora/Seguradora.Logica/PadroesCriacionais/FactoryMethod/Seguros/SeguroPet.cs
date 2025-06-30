namespace Seguradora.Logica.PadroesCriacionais.FactoryMethod.Seguros;

using Seguradora.Logica.PadroesCriacionais.Interfaces;

public class SeguroPet : ISeguro
{
    public string EmitirApolice()
    {
        // Lógica para emitir apólice de seguro de vida
        return "Apólice de Seguro de Animal emitida.";
    }
}