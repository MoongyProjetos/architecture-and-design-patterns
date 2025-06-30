namespace Seguradora.Logica.PadroesEstruturais.Adapter;

using System.Text.Json;

// Adapter
public class LegacyPolicyAdapter : IPolicyService
{
    private readonly LegacyPolicyService _legacyService;

    public LegacyPolicyAdapter(LegacyPolicyService legacyService)
    {
        _legacyService = legacyService;
    }

    public PolicyDetails GetPolicy(string policyId)
    {
        var json = _legacyService.GetPolicyData(policyId);
        return JsonSerializer.Deserialize<PolicyDetails>(json);
    }
}
