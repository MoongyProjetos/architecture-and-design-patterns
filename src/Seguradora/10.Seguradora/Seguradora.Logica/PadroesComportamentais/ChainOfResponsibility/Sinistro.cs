namespace Seguradora.Logica.PadroesComportamentais.ChainOfResponsibility;

public class Sinistro
{
    public string Descricao { get; set; }
    public decimal Valor { get; set; }

    public Sinistro(string descricao, decimal valor)
    {
        Descricao = descricao;
        Valor = valor;
    }
}