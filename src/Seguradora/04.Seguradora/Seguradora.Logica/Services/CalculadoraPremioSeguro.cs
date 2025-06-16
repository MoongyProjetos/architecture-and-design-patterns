public class CalculadoraPremioSeguro
{
    public decimal CalcularSeguroAuto(decimal valorVeiculo)
    {
        var config = SystemConfiguration.Instance;
        return valorVeiculo * config.SeguroAutoTaxa;
    }

    public decimal CalcularSeguroVida(decimal salarioAnual)
    {
        var config = SystemConfiguration.Instance;
        return salarioAnual * config.SeguroVidaTaxa;
    }
}