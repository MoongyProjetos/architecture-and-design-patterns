using Seguradora.Logica.AbstractFactory.Interfaces;
using Seguradora.Logica.AbstractFactory.PessoaJuridica;

namespace Seguradora.Logica.AbstractFactory.ConcreteFactory;

public class SeguroPessoaJuridicaFactory : ISeguroFactory
{
    public IApolice CriarApolice() => new ApolicePessoaJuridica();
    public IRelatorioCobertura CriarRelatorio() => new RelatorioPessoaJuridica();
}