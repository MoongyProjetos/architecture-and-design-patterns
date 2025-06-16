public static class Exemplos
{
    /// <summary>
    /// Exemplo de uso do Singleton SystemConfiguration.
    /// </summary>
    public static ExemploUsoSingleton()
    {
        System.Console.WriteLine("Exemplo de uso do Singleton SystemConfiguration:");

        //Exemplo de uso do Singleton
        var config = SystemConfiguration.Instance;
        Console.WriteLine($"Id Instancia 1: {config.Id}");
        Console.WriteLine($"Taxa Seguro Vida: {config.SeguraVidaTaxa}");
        Console.WriteLine($"Taxa Seguro Auto: {config.SeguraAutoTaxa}");
        Console.WriteLine($"API Key Serviço Externo: {config.ApiKeyServicoExterno}");

        // Demonstrating that the singleton instance is the same
        var config2 = SystemConfiguration.Instance;
        Console.WriteLine($"Id Instancia (config2): {config2.Id}");
        Console.WriteLine($"Taxa Seguro Vida (config2): {config2.SeguraVidaTaxa}");
        Console.WriteLine($"Taxa Seguro Auto (config2): {config2.SeguraAutoTaxa}");
        Console.WriteLine($"API Key Serviço Externo (config2): {config2.ApiKeyServicoExterno}");

        // Demonstrating that the singleton instance is the same
        var config3 = SystemConfiguration.Instance;
        Console.WriteLine($"Id Instancia (config3): {config3.Id}");
        Console.WriteLine($"Taxa Seguro Vida (config3): {config3.SeguraVidaTaxa}");
        Console.WriteLine($"Taxa Seguro Auto (config3): {config3.SeguraAutoTaxa}");
        Console.WriteLine($"API Key Serviço Externo (config3): {config3.ApiKeyServicoExterno}");
    }
}