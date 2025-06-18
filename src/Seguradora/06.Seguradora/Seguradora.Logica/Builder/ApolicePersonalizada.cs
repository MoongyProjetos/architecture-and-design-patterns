namespace Seguradora.Logica.Builder;

public class ApolicePersonalizada
{
    public string? Tipo { get; set; }
    public bool Assistencia24h { get; set; }
    public bool CoberturaInternacional { get; set; }
    public bool ProtecaoTerceiros { get; set; }

    public ClienteExemplo? Cliente { get; set; }

    public override string ToString()
    {
        return $"{Tipo}: " +
               $"Assistência 24h: {Assistencia24h}, " +
               $"Internacional: {CoberturaInternacional}, " +
               $"Proteção a terceiros: {ProtecaoTerceiros}, " +
               $"Cliente: {Cliente?.Nome}";
    }
}