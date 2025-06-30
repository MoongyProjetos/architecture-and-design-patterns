using Seguradora.Modelo.Entidades;

namespace Seguradora.Modelo.Repositorios;

public class ClienteRepository : IRepository<Cliente, Guid>
{
    public bool Apagar(Guid chave)
    {
        throw new NotImplementedException();
    }

    public bool Atualizar(Cliente entidade, Guid chave)
    {
        throw new NotImplementedException();
    }

    public bool Guardar(Cliente entidade)
    {
        throw new NotImplementedException();
    }

    public List<Cliente> Listar()
    {
        throw new NotImplementedException();
    }

    public Cliente Obter(Guid chave)
    {
        throw new NotImplementedException();
    }
}
