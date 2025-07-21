namespace Seguradora.Logica.PadroesComportamentais.Strategy;

public interface ICalculoPremioStrategy
{
    public decimal CalcularPremio(decimal valorBemSegurado, int idadeCliente);
}