namespace Seguradora.Logica.PadroesCriacionais.Prototype;
public class Apolice : IApolicePrototype
{
    public Guid Id { get; set; }
    public string? Tipo { get; set; }
    public string? Cobertura { get; set; }
    public decimal ValorMensal { get; set; }

    public Apolice Clone()
    {
        // This method creates a shallow copy of the current object.
        // Ou seja, uma cópia superficial do objeto atual.
        //https://learn.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone?view=net-9.0
        return (Apolice)this.MemberwiseClone();
    }

    public Apolice SimpleClone()
    {
        // Esse cria uma nova instância de Apolice e copia apenas as propriedades que interessam.
        var clone = new Apolice
        {
            Tipo = this.Tipo,
            Cobertura = this.Cobertura
        };
        return clone;
    }
}