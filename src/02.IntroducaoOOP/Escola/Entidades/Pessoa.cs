using Escola.Operacoes;

namespace Escola.Entidades;
using System.Diagnostics.Contracts;

public class Pessoa : IEstacionamento
{
    #region Propriedades
    public string? Nome { get; set; }
    public string? NumeroTelefone { get; set; }
    public string? EmailAddress { get; set; }
    public Endereco? Endereco { get; set; }

    #endregion Propriedades

    #region Métodos
    public void ComprarPasseEstacionamento()
    {
        System.Console.WriteLine("Passe comprado");
    }
    #endregion Métodos
}
