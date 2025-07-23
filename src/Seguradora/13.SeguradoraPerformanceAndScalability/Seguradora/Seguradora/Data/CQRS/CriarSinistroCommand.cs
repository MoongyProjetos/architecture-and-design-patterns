namespace Seguradora.Data.CQRS
{
    public record CriarSinistroCommand(string NumeroApolice, string Descricao) : IRequest<Guid>;
}
