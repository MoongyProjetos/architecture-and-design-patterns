namespace Seguradora.Logica.PadroesCriacionais.AbstractFactory.Interfaces;
public interface ISeguroFactory
{
    IApolice CriarApolice();
    IRelatorioCobertura CriarRelatorio();
}