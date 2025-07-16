namespace Seguradora.Domain.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

public class Apolice
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }

    [Range(0, 1000000, ErrorMessage = "Valor deve ser entre 0 e 1.000.000.")]
    public decimal Valor { get; set; }
    public virtual Segurado? Segurado { get; set; }

    public virtual List<Artefato> Artefatos { get; set; } = new List<Artefato>();

    public bool Ativa { get; set; } = true;
}