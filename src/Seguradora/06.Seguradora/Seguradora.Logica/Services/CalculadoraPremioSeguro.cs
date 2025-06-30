namespace Seguradora.Logica.Services;
public class CalculadoraPremioSeguro
{
    public static decimal CalcularSeguroAuto(decimal valorVeiculo)
    {
        var config = SystemConfiguration.Instance;
        return valorVeiculo * config.SeguroAutoTaxa;
    }

    public static decimal CalcularSeguroVida(decimal salarioAnual)
    {
        var config = SystemConfiguration.Instance;
        return salarioAnual * config.SeguroVidaTaxa;
    }
}