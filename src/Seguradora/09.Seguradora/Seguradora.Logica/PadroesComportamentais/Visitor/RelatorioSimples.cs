namespace Seguradora.Logica.PadroesComportamentais.Visitor;

// Um visitor que gera relatórios simples
public class RelatorioSimples : IVisitor
{
    public void Visitar(SeguroAuto seguro) =>
        Console.WriteLine($"🚗 Relatório do Seguro Auto: Modelo = {seguro.Modelo}");

    public void Visitar(SeguroVida seguro) =>
        Console.WriteLine($"🧬 Relatório do Seguro Vida: Beneficiário = {seguro.Beneficiario}");
}
