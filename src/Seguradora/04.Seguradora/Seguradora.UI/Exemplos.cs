using Seguradora.Logica;
using Seguradora.Logica.Services;
using Seguradora.Modelo;
using Seguradora.Logica.FactoryMethod.Creators;
using Seguradora.Logica.FactoryMethod.Seguros;

using Seguradora.Logica.AbstractFactory.Services;
using Seguradora.Logica.AbstractFactory.Interfaces;
using Seguradora.Logica.AbstractFactory.PessoaFisica;
using Seguradora.Logica.AbstractFactory.PessoaJuridica;
using Seguradora.Logica.AbstractFactory.ConcreteFactory;

public static class Exemplos
{
    /// <summary>
    /// Exemplo de uso do Singleton SystemConfiguration.
    /// </summary>
    public static void ExemploUsoSingleton()
    {
        System.Console.WriteLine("Exemplo de uso do Singleton SystemConfiguration:");

        //Exemplo de uso do Singleton
        var config = SystemConfiguration.Instance;
        Console.WriteLine($"Id Instancia 1: {config.Id}");
        Console.WriteLine($"Taxa Seguro Vida: {config.SeguroVidaTaxa}");
        Console.WriteLine($"Taxa Seguro Auto: {config.SeguroAutoTaxa}");
        Console.WriteLine($"API Key Serviço Externo: {config.ApiKeyServicoExterno}");

        // Demonstrating that the singleton instance is the same
        var config2 = SystemConfiguration.Instance;
        Console.WriteLine($"Id Instancia (config2): {config2.Id}");
        Console.WriteLine($"Taxa Seguro Vida (config2): {config2.SeguroVidaTaxa}");
        Console.WriteLine($"Taxa Seguro Auto (config2): {config2.SeguroAutoTaxa}");
        Console.WriteLine($"API Key Serviço Externo (config2): {config2.ApiKeyServicoExterno}");

        // Demonstrating that the singleton instance is the same
        var config3 = SystemConfiguration.Instance;
        Console.WriteLine($"Id Instancia (config3): {config3.Id}");
        Console.WriteLine($"Taxa Seguro Vida (config3): {config3.SeguroVidaTaxa}");
        Console.WriteLine($"Taxa Seguro Auto (config3): {config3.SeguroAutoTaxa}");
        Console.WriteLine($"API Key Serviço Externo (config3): {config3.ApiKeyServicoExterno}");
    }


    /// <summary>
    /// Exemplo de uso do Factory Method para criar um seguro.
    /// Reparem na simplicidade que é derivar entre os tipos diferentes de seguro.
    /// </summary>
    public static void ExemploUsoFactoryMethod()
    {
        Console.WriteLine("Exemplo de uso do Factory Method:");

        SeguroCreator criador;

        criador = new SeguroVidaCreator();
        Console.WriteLine(criador.ProcessarApolice());

        criador = new SeguroAutomovelCreator();
        Console.WriteLine(criador.ProcessarApolice());

        criador = new SeguroResidencialCreator();
        Console.WriteLine(criador.ProcessarApolice());

        criador = new SeguroPetCreator();
        Console.WriteLine(criador.ProcessarApolice());
    }


    /// <summary>
    /// Exemplo de uso do Abstract Factory para criar seguros.
    /// Reparem na simplicidade que é derivar entre os tipos diferentes de seguro.
    /// </summary>
    public static void ExemploUsoAbstractFactory()
    {
        Console.WriteLine("Exemplo de uso do Abstract Factory com Seguro:");

        ISeguroFactory factory = new SeguroPessoaFisicaFactory();
        var servico = new ServicoSeguro(factory);
        servico.Processar();

        factory = new SeguroPessoaJuridicaFactory();
        servico = new ServicoSeguro(factory);
        servico.Processar();
    }
}