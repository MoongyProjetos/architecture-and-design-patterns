namespace Calculo;

public interface ICalcular
{
    public int CalcularIdade();

    public int MetodoPadrao()
    {
        return DateTime.Now.Year;
    }
}