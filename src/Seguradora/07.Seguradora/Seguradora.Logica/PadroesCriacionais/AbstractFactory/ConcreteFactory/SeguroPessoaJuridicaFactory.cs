namespace Seguradora.Logica.PadroesCriacionais.AbstractFactory.ConcreteFactory;

public class SeguroPessoaJuridicaFactory : ISeguroFactory
{
    public IApolice CriarApolice() => new ApolicePessoaJuridica();
    public IRelatorioCobertura CriarRelatorio() => new RelatorioPessoaJuridica();
}
