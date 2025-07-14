namespace Seguradora.Logica.PadroesEstruturais.Composite;

public class CoberturaIncendio : Cobertura
{
    public override decimal CalcularValor()
    {
        // Lógica para calcular o valor da cobertura contra incêndio
        return 1000m; // Exemplo de valor fixo
    }
}