namespace Seguradora.Logica.PadroesCriacionais.AbstractFactory.ConcreteFactory;

public class SeguroPessoaFisicaFactory : ISeguroFactory
{
    public IApolice CriarApolice() => new ApolicePessoaFisica();
    public IRelatorioCobertura CriarRelatorio() => new RelatorioPessoaFisica();
}
