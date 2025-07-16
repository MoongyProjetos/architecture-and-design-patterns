using Seguradora.Domain.Entities;
using Seguradora.Infrastructure;


namespace Seguradora.Domain.Repository;

public class ApoliceRepository : IRepository<Apolice, Guid>
{
    public bool Apagar(Guid chave)
    {
        throw new NotImplementedException();
    }

    public Guid Atualizar(Apolice entidade, Guid chave)
    {
        throw new NotImplementedException();
    }

    public Guid Criar(Apolice entidade)
    {
        throw new NotImplementedException();
    }

    public List<Apolice> Listar()
    {
        throw new NotImplementedException();
        //var contexto = new SeguradoraDBContext();
        //var apolices = contexto.Apolices.ToList();
        //return apolices;
    }

    public Apolice Obter(Guid chave)
    {
        throw new NotImplementedException();
    }
}
