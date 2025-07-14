namespace Seguradora.Logica.PadroesComportamentais.ChainOfResponsibility;

// Nível 2
public class Gerente : Aprovador
{
    public override void Aprovar(Sinistro s)
    {
        if (s.Valor < 15000)
        {
            Console.WriteLine($"Gerente aprovou o sinistro: {s.Descricao} (Valor: {s.Valor:C})");
        }
        else
        {
            Proximo?.Aprovar(s);
        }
    }
}