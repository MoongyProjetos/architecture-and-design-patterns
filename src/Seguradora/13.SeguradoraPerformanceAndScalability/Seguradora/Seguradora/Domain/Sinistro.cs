namespace Seguradora.Domain
{
    public class Sinistro
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NumeroApolice { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataOcorrencia { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pendente";
    }
}
