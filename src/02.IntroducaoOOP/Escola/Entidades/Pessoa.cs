namespace Escola.Entidades;using System.Diagnostics.Contracts;

public class Pessoa : IEstacionamento
{
    #region Propriedades
    public string? Nome;
    public string? NumeroTelefone;
    public string? EmailAddress;
    public Endereco? endereco;

    #endregion Propriedades

    #region Métodos
    public void ComprarPasseEstacionamento()
    {
        System.Console.WriteLine("Passe comprado");
    }
    #endregion Métodos
}
