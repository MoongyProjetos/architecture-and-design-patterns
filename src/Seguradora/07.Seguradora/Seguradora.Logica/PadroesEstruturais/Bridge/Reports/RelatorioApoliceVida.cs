using Seguradora.Logica.PadroesEstruturais.Bridge.Exporters;

namespace Seguradora.Logica.PadroesEstruturais.Bridge.Reports;

public class RelatorioApoliceVida : RelatorioApolice
{
    public RelatorioApoliceVida(IReportExporter exporter) : base(exporter) { }

    public override void Gerar()
    {
        // buscar dados necessários para o relatório de apólice de vida
        // Lógica específica para gerar o relatório de apólice de vida
        _exporter.Export("Relatório de Apólice de Vida");
    }
}
