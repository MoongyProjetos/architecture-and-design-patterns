namespace Seguradora.Domain.Repository;

public interface IRepository<T> where T : class
{
    Task<T> ObterPorId(Guid id);
    Task<IEnumerable<T>> ListarAsync();
    Task CriarAsync(T entity);
    void Atualizar(T entity);
    void Apagar(T entity);
}