namespace Seguradora.Logica.PadroesEstruturais.Flyweight;

public class Apolice
{
    public string Cliente { get; }
    public TabelaRisco Risco { get; }

    public Apolice(string cliente, TabelaRisco risco)
    {
        Cliente = cliente;
        Risco = risco;
    }

    public void Imprimir() =>
        Console.WriteLine($"{Cliente} usa tabela {Risco.Tipo} (fator {Risco.Fator})");
}