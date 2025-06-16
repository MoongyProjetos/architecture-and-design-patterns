using Seguradora.Logica.AbstractFactory.Interfaces;

namespace Seguradora.Logica.AbstractFactory.PessoaJuridica;

public class ApolicePessoaJuridica : IApolice
{
    public void Emitir()
    {
        Console.WriteLine("Emitindo apólice para pessoa jurídica...");
    }

    public void Cancelar()
    {
        Console.WriteLine("Cancelando apólice para pessoa jurídica...");
    }
}