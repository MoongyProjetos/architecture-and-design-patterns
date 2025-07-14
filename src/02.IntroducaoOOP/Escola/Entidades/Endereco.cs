namespace Escola.Entidades;

public class Endereco
{
    #region Propriedades
    public string? Rua { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public string? CodigoPostal { get; set; }
    public string? Pais { get; set; }
    #endregion Propriedades

    #region Metodos
    public bool Validar()
    {
        var ruaValido = string.IsNullOrEmpty(Rua);
        var cidadeValido = string.IsNullOrEmpty(Cidade);
        var estadoValido = string.IsNullOrEmpty(Estado);
        var codigoPostalValido = string.IsNullOrEmpty(CodigoPostal) && CodigoPostal?.Length >= 4;
        var PaisValido = string.IsNullOrEmpty(Pais);

        return ruaValido && cidadeValido && estadoValido && codigoPostalValido && PaisValido;
    }

    public static void GerarEtiqueta()
    {

    }

    #endregion Metodos
}