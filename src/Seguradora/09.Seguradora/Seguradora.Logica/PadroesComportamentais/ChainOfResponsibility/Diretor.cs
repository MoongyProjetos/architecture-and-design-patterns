namespace Seguradora.Logica.PadroesComportamentais.ChainOfResponsibility;

// Nível 3
public class Diretor : Aprovador
{
    public override void Aprovar(Sinistro sinistro)
    {
        if (sinistro.Valor < 150000)
        {
            Console.WriteLine($"Diretor aprovou o sinistro: {sinistro.Descricao} (Valor: {sinistro.Valor:C})");
        }
        else
        {
            Console.WriteLine($"Sinistro de valor muito alto! Escalar para conselho: {sinistro.Descricao} (Valor: {sinistro.Valor:C})");
        }
    }
}