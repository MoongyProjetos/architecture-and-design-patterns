namespace Seguradora.Logica.PadroesComportamentais.ChainOfResponsibility;

// Nível 1
public class Atendente : Aprovador
{
    public override void Aprovar(Sinistro sinistro)
    {
        if (sinistro.Valor < 5000)
        {
            Console.WriteLine($"Atendente aprovou o sinistro: {sinistro.Descricao} (Valor: {sinistro.Valor:C})");
        }
        else
        {
            Proximo?.Aprovar(sinistro);
        }
    }
}