namespace Seguradora.Logica.PadroesEstruturais.Adapter;

// Interface moderna usada no novo sistema
public interface IPolicyService
{
    PolicyDetails GetPolicy(string policyId);
}
