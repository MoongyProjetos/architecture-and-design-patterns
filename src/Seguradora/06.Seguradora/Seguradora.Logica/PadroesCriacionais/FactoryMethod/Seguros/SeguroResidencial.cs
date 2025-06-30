namespace Seguradora.Logica.PadroesCriacionais.FactoryMethod.Seguros;
public class SeguroResidencial : ISeguro
{
    public string EmitirApolice()
    {
        // Lógica para emitir apólice de seguro residencial
        return "Apólice de Seguro Residencial emitida.";
    }
}
