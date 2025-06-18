public interface IRepository<T, K>
{
    T Obter(K chave);
    List<T> Listar();
    bool Guardar(T entidade);
    bool Atualizar(T entidade, K chave);
    bool Apagar(K chave);    
}