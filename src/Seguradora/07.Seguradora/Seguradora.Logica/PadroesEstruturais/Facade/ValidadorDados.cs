namespace Seguradora.Logica.PadroesEstruturais.Facade;

public class ValidadorDados
{
    //Verifica se o cliente pode fazer negócios com a seguradora
    public void Validar(string cpf) => Console.WriteLine($"Validação de CPF: {cpf}");
}