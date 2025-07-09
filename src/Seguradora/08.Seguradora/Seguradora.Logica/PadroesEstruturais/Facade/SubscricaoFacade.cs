namespace Seguradora.Logica.PadroesEstruturais.Facade;


/// <summary>
/// Serve como uma fachada para o processo de subscrição de seguros.
/// Encapsula a lógica de validação de dados, avaliação de risco e geração de contrato.
/// Não utilizar fora desse contexto, com o risco de over-engineering.
/// </summary>
public class SubscricaoFacade
{
    private ValidadorDados _validador = new();
    private AvaliadorRisco _avaliador = new();
    private GeradorContrato _gerador = new();

    public void SubscricaoCompleta(string cpf)
    {
        _validador.Validar(cpf);
        int risco = _avaliador.Avaliar(cpf);
        _gerador.Gerar(cpf, risco);
    }
}