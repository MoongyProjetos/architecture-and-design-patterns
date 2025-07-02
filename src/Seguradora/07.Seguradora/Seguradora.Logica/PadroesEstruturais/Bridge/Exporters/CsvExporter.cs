namespace Seguradora.Logica.PadroesEstruturais.Bridge.Exporters;

public class CsvExporter : IReportExporter {
    public void Export(string content) => Console.WriteLine($"Exportando CSV: {content}, com lógica específica para CSV");
}