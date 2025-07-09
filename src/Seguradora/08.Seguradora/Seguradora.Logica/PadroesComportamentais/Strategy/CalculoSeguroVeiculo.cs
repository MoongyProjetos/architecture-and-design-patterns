namespace Seguradora.Logica.PadroesComportamentais.Strategy;

public class CalculoSeguroVeiculo : ICalculoPremioStrategy
{
    /// <summary>
    /// Calcula o prêmio do seguro de veículo com base no valor do bem segurado e na idade do cliente.
    /// O prêmio é calculado como 5% do valor do bem segurado mais um adicional baseado na idade do cliente:
    /// - Se o cliente tiver menos de 25 anos, adiciona R$200.
    /// </summary>
    /// <param name="valorBemSegurado"></param>
    /// <param name="idadeCliente"></param>
    /// <returns></returns>
    public decimal CalcularPremio(decimal valorBemSegurado, int idadeCliente)
    {
        return (valorBemSegurado * 0.05m) + (idadeCliente < 25 ? 200 : 100);
    }
}
