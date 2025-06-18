using Seguradora.Logica.AbstractFactory.Interfaces;

namespace Seguradora.Logica.AbstractFactory.PessoaJuridica;

public class RelatorioPessoaJuridica : IRelatorioCobertura
{
    public void GerarRelatorio()
    {
        // Implementação do método para gerar relatório de pessoa jurídica
        Console.WriteLine("Relatório de Pessoa Jurídica gerado com sucesso.");
    }
}