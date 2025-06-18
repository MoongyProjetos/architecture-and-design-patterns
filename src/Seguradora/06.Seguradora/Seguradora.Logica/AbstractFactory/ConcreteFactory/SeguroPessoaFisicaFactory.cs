using Seguradora.Logica.AbstractFactory.Interfaces;
using Seguradora.Logica.AbstractFactory.PessoaFisica;

namespace Seguradora.Logica.AbstractFactory.ConcreteFactory;

public class SeguroPessoaFisicaFactory : ISeguroFactory
{
    public IApolice CriarApolice() => new ApolicePessoaFisica();
    public IRelatorioCobertura CriarRelatorio() => new RelatorioPessoaFisica();
}