// Essa classe representa uma cobertura de seguro que pode ser composta por outras coberturas, como incêndio, roubo e danos a terceiros.

namespace Seguradora.Logica.PadroesEstruturais.Composite;

public class CompositeCobertura : Cobertura
{
    private readonly List<Cobertura> _coberturas = new List<Cobertura>();

    public void AdicionarCobertura(Cobertura cobertura)
    {
        _coberturas.Add(cobertura);
    }

    public override decimal CalcularValor()
    {
        return _coberturas.Sum(c => c.CalcularValor());
    }
}