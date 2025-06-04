
/// <summary>
/// Estudante estende/herda de pessoa
/// </summary>
public class Estudante : Pessoa
{
    #region Propriedades
    public int NumeroEstudante;
    public float NotaMedia;

    #endregion Propriedades

    #region Metodos
    public bool EstaElegivel()
    {
        return NotaMedia >= 10; //Valor máximo é 20
    }

    public List<string> ObterSeminarios()
    {
        List<string> seminarios = new List<string>();
        return seminarios;
    }
    #endregion Metodos
}
