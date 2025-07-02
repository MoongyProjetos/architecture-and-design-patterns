

public class Program
{
    static void Main(string[] args)
    {
        var carroSimples = new CarroModelo("POLO");
        var carroNormal = new Carro(carroSimples, "Azul");


        System.Console.WriteLine(carroSimples.Id);
        System.Console.WriteLine(carroNormal.Modelo.Id);
    }
}

class CarroModelo
{
    public Guid Id { get; }
    public string Modelo { get; }
    public CarroModelo(string modelo)
    {
        Modelo = modelo;
        Id = Guid.NewGuid();
    }
}

class Carro
{
    public CarroModelo Modelo { get; }
    public string Cor { get; }

    public Carro(CarroModelo modelo, string cor)
    {
        Modelo = modelo;
        Cor = cor;
    }
}