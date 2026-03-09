namespace Aula01;
public class PessoaColetiva : Pessoa
{
    public DateTime DataCriacao {get;set;}
    public override int Idade => DateTime.Now.Year - DataCriacao.Year;
}