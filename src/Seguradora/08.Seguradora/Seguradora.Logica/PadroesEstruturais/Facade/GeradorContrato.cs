namespace Seguradora.Logica.PadroesEstruturais.Facade;

public class GeradorContrato
{

    //.NET CORE em diante
    //public void Gerar(string cpf, int risco) => Console.WriteLine($"Contrato gerado para {cpf} com risco {risco}");

    //.NET desde o início
    // Gera um contrato de seguro com base nas informações do cliente
    public void Gerar(string cpf, int risco)
    {
        // Aqui, você poderia chamar os métodos de ValidadorDados e AvaliadorRisco
        // para validar o CPF e avaliar o risco antes de gerar o contrato.
        Console.WriteLine($"Contrato gerado para {cpf} com risco {risco}");
    }
}