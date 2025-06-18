using Seguradora.Logica.AbstractFactory.Interfaces;

namespace Seguradora.Logica.AbstractFactory.PessoaFisica;

public class RelatorioPessoaFisica : IRelatorioCobertura
{
    public void GerarRelatorio()
    {
        // Implementação do método para gerar relatório de pessoa física
        Console.WriteLine("Relatório de Pessoa Física gerado com sucesso.");
    }
}