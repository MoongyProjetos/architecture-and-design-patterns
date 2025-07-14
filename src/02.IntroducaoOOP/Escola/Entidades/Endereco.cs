namespace Escola.Entidades;

public class Endereco
{
    #region Propriedades
    public string? Rua;
    public string? Cidade;
    public string? Estado;
    public string? CodigoPostal;
    public string? Pais;
    #endregion Propriedades

    #region Metodos
    public bool Validar()
    {
        var ruaValido = string.IsNullOrEmpty(Rua);
        var cidadeValido = string.IsNullOrEmpty(Cidade);
        var estadoValido = string.IsNullOrEmpty(Estado);
        var codigoPostalValido = string.IsNullOrEmpty(CodigoPostal) && CodigoPostal.Length >= 4;
        var PaisValido = string.IsNullOrEmpty(Pais);

        return ruaValido && cidadeValido && estadoValido && codigoPostalValido && PaisValido;
    }

    public void GerarEtiqueta()
    {

    }

    #endregion Metodos
}