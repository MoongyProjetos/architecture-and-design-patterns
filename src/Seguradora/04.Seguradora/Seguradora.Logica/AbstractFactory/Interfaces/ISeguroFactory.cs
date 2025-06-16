namespace Seguradora.Logica.AbstractFactory.Interfaces;

public interface ISeguroFactory
{
    IApolice CriarApolice();
    IRelatorioCobertura CriarRelatorio();
}