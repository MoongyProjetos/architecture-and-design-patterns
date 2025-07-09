namespace Seguradora.Logica.PadroesCriacionais.FactoryMethod.Seguros;

using Seguradora.Logica.PadroesCriacionais.Interfaces;

public class SeguroResidencial : ISeguro
{
    public string EmitirApolice()
    {
        // Lógica para emitir apólice de seguro residencial
        return "Apólice de Seguro Residencial emitida.";
    }
}
