namespace Seguradora.Logica.PadroesEstruturais.Adapter;

// Sistema legado (interface diferente)
public class LegacyPolicyService
{
    public string GetPolicyData(string id)
    {
        // retorna JSON string com dados da apólice
        return "{ \"policyNumber\": \"ABC123\" }";
    }
}
