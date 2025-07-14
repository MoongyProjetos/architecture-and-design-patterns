namespace Seguradora.Logica.PadroesComportamentais.Visitor;

// Um visitor que gera relatórios simples
public class RelatorioComplexo : IVisitor
{
    public void Visitar(SeguroAuto seguro) =>
        Console.WriteLine($"🚗 Relatório Completo do Seguro Auto: Modelo = {seguro.Modelo}");

    public void Visitar(SeguroVida seguro) =>
        Console.WriteLine($"🧬 Relatório Completo do Seguro Vida: Beneficiário = {seguro.Beneficiario}");
}
