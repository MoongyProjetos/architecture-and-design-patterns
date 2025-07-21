namespace Seguradora.Logica.PadroesComportamentais.Command;

//Recebe comandos de apólices e executa ações correspondentes
// Este é um exemplo básico e pode ser expandido com mais funcionalidades, como adicionar, remover
public class GestorApolices
{
    /// <summary>
    /// Emite uma apólice de seguro com o número fornecido.
    /// </summary>
    /// <param name="numero"></param>
    public void Emitir(string numero)
    {
        Console.WriteLine($"Apólice {numero} emitida com sucesso.");
    }

    /// <summary>
    /// Cancela uma apólice de seguro com o número fornecido.
    /// </summary>
    /// <param name="numero"></param>
    public void Cancelar(string numero)
    {
        Console.WriteLine($"Apólice {numero} cancelada.");
    }
}