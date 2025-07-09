namespace Seguradora.Logica;

using Seguradora.Logica.PadroesCriacionais.Interfaces;
using Seguradora.Modelo.Entidades;
using Seguradora.Modelo.Repositorios;

public class GerenciadorApolice : ICalcular
{
    public readonly IRepository<Apolice, Guid> _repository;
    public readonly Apolice _apolice;


    public GerenciadorApolice(IRepository<Apolice, Guid> repository, Apolice apolice)
    {
        _repository = repository;
        _apolice = apolice;
    }

    public void CriarNovoSeguro()
    {
        _repository.Guardar(_apolice);
    }

    public void CancelarSeguro()
    {
        _repository.Apagar(_apolice.Id);
    }

    public decimal Calcular()
    {
        throw new NotImplementedException();
    }
}
