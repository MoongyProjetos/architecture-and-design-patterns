namespace Seguradora.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;


public class Artefato
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Descrição é obrigatória."), MaxLength(200), MinLength(3)]
    public string? Descricao { get; set; }

    [Range(0, 1000000, ErrorMessage = "Valor deve ser entre 0 e 1.000.000.")]
    public decimal Valor { get; set; }
    public virtual Apolice? Apolice { get; set; }
}