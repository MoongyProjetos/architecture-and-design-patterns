namespace Seguradora.Logica.PadroesComportamentais.State;

public class Apolice
{
    private IEstadoApolice? _estado;

    /// <summary>
    /// Define o estado atual da apólice.
    /// Atualiza o estado e exibe uma mensagem indicando a mudança.
    /// </summary>
    /// <param name="estado"></param>
    public void DefinirEstado(IEstadoApolice estado)
    {
        _estado = estado;
        Console.WriteLine($"[Estado atualizado: {estado.GetType().Name}]");
    }

    /// <summary>
    /// Processa a apólice de acordo com o estado atual.
    /// Se o estado não estiver definido, exibe uma mensagem de aviso.
    /// </summary>
    public void Processar()
    {
        if (_estado == null)
        {
            Console.WriteLine("⚠️ Nenhum estado definido para a apólice.");
        }
        else
        {
            _estado.Processar();
        }
    }
}
