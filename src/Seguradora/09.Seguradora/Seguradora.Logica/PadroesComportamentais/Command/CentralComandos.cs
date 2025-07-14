//Invoca os comandos de apólice
//É o exemplo de uma central de comandos que recebe e executa comandos de apólice

namespace Seguradora.Logica.PadroesComportamentais.Command;

public class CentralComandos
{
    /// <summary>
    /// Executa um comando de apólice.
    /// Este método recebe um comando que implementa a interface IComandoApolice e chama
    /// seu método Executar. Isso permite que diferentes ações relacionadas a apólices sejam
    /// encapsuladas em comandos distintos, seguindo o padrão Command.
    /// </summary>
    /// <param name="comando"></param>
    public void ExecutarComando(IComandoApolice comando)
    {
        comando.Executar();
    }
}
