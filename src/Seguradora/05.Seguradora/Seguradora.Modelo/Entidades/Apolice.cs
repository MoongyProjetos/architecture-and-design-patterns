using System.Text;
using Seguradora.Modelo;

public class Apolice
{
    public Guid Id { get; set; }
    public string? CondicoesEspeciais { get; set; }
    public Cliente? Cliente { get; set; }
    public DateTime DataEfetivacao { get; set; }
    public DateTime DataCancelamento { get; set; }
    public void ImprimirDados()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Id: {Id}");
        sb.AppendLine($"Nome Cliente: {Cliente?.Nome}");
        sb.AppendLine($"Data Efetivacao: {DataEfetivacao}");
        sb.AppendLine($"Data Cancelamento: {DataCancelamento}");
    }
}