namespace Seguradora.Logica.PadroesEstruturais.Composite;

public class CoberturaRoubo : Cobertura
{
    public override decimal CalcularValor()
    {
        // Lógica para calcular o valor da cobertura contra roubo
        return 500m; // Exemplo de valor fixo
    }
}