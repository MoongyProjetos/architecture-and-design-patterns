namespace Seguradora.Logica.PadroesEstruturais.Bridge.Exporters;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

public class WordExporter : IReportExporter
{
    public void Export(string content)
    {
        Console.WriteLine($"Exportando Word: {content}");
        var filePath = @"c:\temp\ExemploExportacao.docx";
        CriarDocumentoWord(filePath);
    }


    private static void CriarDocumentoWord(string caminho)
    {
        using var documento = WordprocessingDocument.Create(caminho, DocumentFormat.OpenXml.WordprocessingDocumentType.Document);

        // Adiciona a estrutura principal
        var mainPart = documento.AddMainDocumentPart();
        mainPart.Document = new Document();
        var corpo = new Body();

        // Adiciona um título
        var titulo = new Paragraph(new Run(new Text("Exportação para Word com C#")))
        {
            ParagraphProperties = new ParagraphProperties(new ParagraphStyleId() { Val = "Title" })
        };

        // Adiciona um parágrafo
        var paragrafo = new Paragraph(new Run(new Text("Este é um exemplo simples de como gerar um arquivo Word usando C# e Open XML.")));

        // Adiciona ao corpo
        corpo.Append(titulo);
        corpo.Append(paragrafo);

        mainPart.Document.Append(corpo);
        mainPart.Document.Save();
    }
}
