namespace Seguradora.Logica.FactoryMethod.Seguros;
public class SeguroVida : ISeguro
{
    public string EmitirApolice()
    {
        // Lógica para emitir apólice de seguro de vida
        return "Apólice de Seguro de Vida emitida.";
    }
}