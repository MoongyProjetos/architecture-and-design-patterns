namespace Seguradora.Logica.PadroesCriacionais.FactoryMethod.Seguros;

using Seguradora.Logica.PadroesCriacionais.Interfaces;

public class SeguroAutomovel : ISeguro
{
    public string EmitirApolice()
    {
        // Lógica para emitir apólice de seguro de automóvel
        return "Apólice de Seguro de Automóvel emitida.";
    }
}