namespace Seguradora.Logica.PadroesEstruturais.Decorator;
public class ApoliceBasica : IApolice
{
    public string Descricao() => "Apolice Básica";
    public decimal CalcularPremio() => 1000;
}