namespace Seguradora.Logica.PadroesComportamentais.Strategy;


/// <summary>
/// Calcula o prêmio do seguro residencial com base no valor do bem segurado e na idade do cliente.
/// O prêmio é calculado como 85% do valor do bem segurado, independente da idade do cliente.
/// </summary>
public class CalculoSeguroResidencial : ICalculoPremioStrategy
{
    public decimal CalcularPremio(decimal valorBemSegurado, int idadeCliente)
    {
        return valorBemSegurado * 0.85m;
    }
}
