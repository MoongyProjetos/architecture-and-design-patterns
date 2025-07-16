namespace Seguradora.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

public class Segurado
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [MaxLength(100,ErrorMessage = "Nome deve ter entre 3 e 100 caracteres."), MinLength(3, ErrorMessage = "Nome deve ter entre 3 e 100 caracteres.")]
    [Required(ErrorMessage = "Nome é obrigatório.")]
    public string? Nome { get; set; }

    public DateTime DataNascimento { get; set; }

    [MaxLength(20)]
    [Required(ErrorMessage = "Documento é obrigatório.")]
    public string? Documento { get; set; }

    public virtual List<Apolice>? Apolices { get; set; } = new List<Apolice>();
}