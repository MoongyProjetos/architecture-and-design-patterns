namespace Seguradora.Logica.PadroesComportamentais.ChainOfResponsibility;

// Nível 2
public class Gerente : Aprovador
{
    public override void Aprovar(Sinistro sinistro)
    {
        if (sinistro.Valor < 15000)
        {
            Console.WriteLine($"Gerente aprovou o sinistro: {sinistro.Descricao} (Valor: {sinistro.Valor:C})");
        }
        else
        {
            Proximo?.Aprovar(sinistro);
        }
    }
}