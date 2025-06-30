public class ApoliceRepository : IRepository<Apolice, Guid>
{
    public bool Apagar(Guid chave)
    {
        throw new NotImplementedException();
    }

    public bool Atualizar(Apolice entidade, Guid chave)
    {
        throw new NotImplementedException();
    }

    public bool Guardar(Apolice entidade)
    {
        Console.WriteLine("Apolice guardada com sucesso");
        return true;
    }

    public List<Apolice> Listar()
    {
        throw new NotImplementedException();
    }

    public Apolice Obter(Guid chave)
    {
        throw new NotImplementedException();
    }
}