namespace Seguradora.Logica.PadroesComportamentais.ChainOfResponsibility;

// Nível 3
public class Diretor : Aprovador
{
    public override void Aprovar(Sinistro s)
    {
        if (s.Valor < 150000)
        {
            Console.WriteLine($"Diretor aprovou o sinistro: {s.Descricao} (Valor: {s.Valor:C})");
        }
        else
        {
            Console.WriteLine($"Sinistro de valor muito alto! Escalar para conselho: {s.Descricao} (Valor: {s.Valor:C})");
        }
    }
}