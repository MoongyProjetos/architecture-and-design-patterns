namespace Seguradora.Domain.Repository;

public interface IRepository<T, K> where T : class
{
    T Obter(K chave);
    K Criar(T entidade);
    K Atualizar(T entidade, K chave);
    List<T> Listar();
    bool Apagar(K chave);
}

