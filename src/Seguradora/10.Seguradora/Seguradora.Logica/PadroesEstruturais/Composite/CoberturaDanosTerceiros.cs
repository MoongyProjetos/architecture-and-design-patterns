namespace Seguradora.Logica.PadroesEstruturais.Composite;

public class CoberturaDanosTerceiros : Cobertura
{
    public override decimal CalcularValor()
    {
        // Lógica para calcular o valor da cobertura contra danos a terceiros
        return 300m; // Exemplo de valor fixo
    }
}