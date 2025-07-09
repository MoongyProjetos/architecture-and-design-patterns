namespace Seguradora.Logica.PadroesComportamentais.Strategy;


/// <summary>
/// Calcula o prêmio do seguro de eletrônicos com base no valor do bem segurado e na idade do cliente.
/// O prêmio é calculado como 95% do valor do bem segurado, independente da idade do cliente.
/// </summary>
public class CalculoSeguroEletronicos : ICalculoPremioStrategy
{
    public decimal CalcularPremio(decimal valorBemSegurado, int idadeCliente)
    {
        return (valorBemSegurado * 0.95m) + (idadeCliente < 30 ? 100 : 50);
    }
}
