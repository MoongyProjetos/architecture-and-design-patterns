namespace Seguradora.Logica.PadroesComportamentais.Memento;

public class MementoProposta
{
    public string Cliente { get; }
    public string Cobertura { get; }

    public MementoProposta(string cliente, string cobertura)
    {
        Cliente = cliente;
        Cobertura = cobertura;

        // Exemplo de persistência, poderia ser serializado ou armazenado em banco de dados
        PersistirMemento(this);
    }

    /// <summary>
    /// Persistir o memento em um arquivo JSON.
    /// Este método simula a persistência de um memento em um arquivo.
    /// Em uma aplicação real, poderia ser persistido em um banco de dados ou outro armazenamento.
    /// </summary>
    /// <param name="memento"></param>
    private static void PersistirMemento(MementoProposta memento)
    {
        var filePath = $"{memento.Cliente}_memento.json";
        var json = System.Text.Json.JsonSerializer.Serialize(memento);
        File.WriteAllText(filePath, json);
    }


    /// <summary>
    /// Recupera o memento de um cliente específico.
    /// Este método simula a recuperação de um memento persistido em um arquivo JSON.
    /// Em uma aplicação real, poderia ser recuperado de um banco de dados ou outro armazenamento.
    /// </summary>
    /// <param name="cliente"></param>
    /// <returns></returns>
    private static MementoProposta RecuperarMemento(string cliente)
    {
        var filePath = $"{cliente}_memento.json";
        if (!File.Exists(filePath))
        {
            return null; // ou lançar uma exceção
        }
        var json = File.ReadAllText(filePath);
        return System.Text.Json.JsonSerializer.Deserialize<MementoProposta>(json);
    }
}
