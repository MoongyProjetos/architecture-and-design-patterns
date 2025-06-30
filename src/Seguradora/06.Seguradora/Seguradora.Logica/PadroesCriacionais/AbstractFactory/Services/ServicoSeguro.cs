namespace Seguradora.Logica.PadroesCriacionais.AbstractFactory.Services;

public class ServicoSeguro
{
    private readonly IApolice _apolice;
    private readonly IRelatorioCobertura _relatorio;

    public ServicoSeguro(ISeguroFactory factory)
    {
        _apolice = factory.CriarApolice();
        _relatorio = factory.CriarRelatorio();
    }

    public void Processar()
    {
        _apolice.Emitir();
        _apolice.Cancelar();
        _relatorio.GerarRelatorio();
    }
}
