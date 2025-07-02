using Seguradora.Logica.PadroesEstruturais.Bridge.Exporters;

namespace Seguradora.Logica.PadroesEstruturais.Bridge.Reports;

public class RelatorioApoliceAutomovel : RelatorioApolice
{
    public RelatorioApoliceAutomovel(IReportExporter exporter) : base(exporter) { }

    public override void Gerar()
    {
        // buscar dados necessários para o relatório de apólice de automóvel
        // Lógica específica para gerar o relatório de apólice de automóvel
        _exporter.Export("Relatório de Apólice de Automóvel");
    }
}
