namespace Aula01;

using Aula01.Dominio;

public class PessoaSingular : Pessoa
{
    public PessoaSingular() { }

    public PessoaSingular(string nome, Sexo sexo)
    {
        Nome = nome;
        Sexo = sexo;
    }

    public PessoaSingular(string nome, Sexo sexo, DateTime dataNascimento)
    {
        Nome = nome;
        Sexo = sexo;
        DataNascimento = dataNascimento;
    }

    public DateTime DataNascimento {get;set;}
    public override int Idade => DateTime.Now.Year - DataNascimento.Year;
    public readonly Sexo Sexo;
}