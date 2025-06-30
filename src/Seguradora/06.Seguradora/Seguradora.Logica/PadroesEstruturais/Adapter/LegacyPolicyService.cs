namespace Seguradora.Logica.PadroesEstruturais.Adapter;

// Sistema legado (interface diferente)
public class LegacyPolicyService
{
    public static string GetPolicyData(string id)
    {
        // retorna JSON string com dados da apólice
        Console.WriteLine(id);
        return /*lang=json,strict*/ "{ \"policyNumber\": \"ABC123\" }";
    }
}
