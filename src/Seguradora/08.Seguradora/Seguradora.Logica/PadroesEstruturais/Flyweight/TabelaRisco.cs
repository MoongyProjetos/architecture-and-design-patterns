
namespace Seguradora.Logica.PadroesEstruturais.Flyweight;
public class TabelaRisco
{
    public string Tipo { get; }
    public decimal Fator { get; }

    public TabelaRisco(string tipo, decimal fator) {
        Tipo = tipo;
        Fator = fator;
    }
}