namespace Seguradora.Logica.PadroesComportamentais.Mediator;

/// <summary>
/// MediadorCentral é a classe que atua como o ponto central de comunicação entre os departamentos.
/// Ela implementa a interface IMediador e gerencia o envio de mensagens entre os departamentos
/// </summary>
public class MediadorCentral : IMediador
{
    private Avaliacao _avaliacao { get; set; }
    private Emissao _emissao { get; set; }

    public void RegistrarDepartamento(Departamento departamento)
    {
        if (departamento is Avaliacao avaliacao)
        {
            _avaliacao = avaliacao;
        }
        else if (departamento is Emissao emissao)
        {
            _emissao = emissao;
        }    
    }


    public void EnviarMensagem(string mensagem, Departamento origem)
    {
        if (origem == _avaliacao)
        {
            _emissao.Receber(mensagem);
        }
        else
        {
            _avaliacao.Receber(mensagem);
        }
    }
}