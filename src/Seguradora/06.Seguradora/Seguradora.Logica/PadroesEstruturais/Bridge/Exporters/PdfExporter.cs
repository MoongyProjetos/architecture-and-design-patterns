namespace Seguradora.Logica.PadroesEstruturais.Bridge.Exporters;

// Concrete Implementors
public class PdfExporter : IReportExporter {
    public void Export(string content) => Console.WriteLine($"Exportando PDF: {content}");
}