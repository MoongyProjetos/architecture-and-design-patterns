using Seguradora.Logica.AbstractFactory.Interfaces;

namespace Seguradora.Logica.AbstractFactory.PessoaFisica;

public class ApolicePessoaFisica : IApolice
{
    public void Emitir()
    {
        Console.WriteLine("Emitindo apólice para pessoa física...");
    }

    public void Cancelar()
    {
        Console.WriteLine("Cancelando apólice para pessoa física...");
    }
}