namespace Seguradora.Logica.PadroesComportamentais.ChainOfResponsibility;

// Nível 1
public class Atendente : Aprovador
{
    public override void Aprovar(Sinistro s)
    {
        if (s.Valor < 5000)
        {
            Console.WriteLine($"Atendente aprovou o sinistro: {s.Descricao} (Valor: {s.Valor:C})");
        }
        else
        {
            Proximo?.Aprovar(s);
        }
    }
}