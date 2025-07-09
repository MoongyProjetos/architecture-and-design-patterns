namespace Seguradora.Logica.PadroesComportamentais.Strategy;

public class CalculoSeguroVida : ICalculoPremioStrategy
{

    /// <summary>
    /// Calcula o prêmio do seguro de vida com base no valor do bem segurado e na idade do cliente.
    /// O prêmio é fixo: R$300 se o cliente tiver menos de 30 anos, ou R$500 se tiver 30 anos ou mais.
    /// </summary>
    /// <param name="valorBemSegurado"></param>
    /// <param name="idadeCliente"></param>
    /// <returns></returns>
    public decimal CalcularPremio(decimal valorBemSegurado, int idadeCliente)
    {
        return idadeCliente < 30 ? 300 : 500;
    }
}
