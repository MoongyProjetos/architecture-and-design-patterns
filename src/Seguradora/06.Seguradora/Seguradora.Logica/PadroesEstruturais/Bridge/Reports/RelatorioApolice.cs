using Seguradora.Logica.PadroesEstruturais.Bridge.Exporters;

namespace Seguradora.Logica.PadroesEstruturais.Bridge.Reports;

// Abstraction
public abstract class RelatorioApolice
{
    protected readonly IReportExporter _exporter;
    public RelatorioApolice(IReportExporter exporter) => _exporter = exporter;
    public abstract void Gerar();
}
