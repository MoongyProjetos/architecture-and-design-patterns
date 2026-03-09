using System.Reflection.Metadata.Ecma335;
using Calculo;

namespace Aula01;

public abstract class Pessoa : ICalcular
{
    public string? Nome { get; set; }
    public string? NIF { get; set; }
    public abstract int Idade {get;}
    public int CalcularIdade()=> 10;
}



