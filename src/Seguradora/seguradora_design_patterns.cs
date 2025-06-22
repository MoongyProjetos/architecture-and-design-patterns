// Mini projeto console integrando Decorator, Facade, Flyweight e Proxy
using System;
using System.Collections.Generic;
using System.Linq;

#region Decorator
interface IApólice {
    string Descricao();
    decimal CalcularPremio();
}

class ApoliceBasica : IApólice {
    public string Descricao() => "Apolice Básica";
    public decimal CalcularPremio() => 1000;
}

class CoberturaRoubo : IApólice {
    private readonly IApólice _apolice;
    public CoberturaRoubo(IApólice apolice) => _apolice = apolice;
    public string Descricao() => _apolice.Descricao() + " + Roubo";
    public decimal CalcularPremio() => _apolice.CalcularPremio() + 250;
}

class CoberturaIncendio : IApólice {
    private readonly IApólice _apolice;
    public CoberturaIncendio(IApólice apolice) => _apolice = apolice;
    public string Descricao() => _apolice.Descricao() + " + Incêndio";
    public decimal CalcularPremio() => _apolice.CalcularPremio() + 400;
}
#endregion

#region Flyweight
class TabelaRisco {
    public string Tipo { get; }
    public decimal Fator { get; }
    public TabelaRisco(string tipo, decimal fator) {
        Tipo = tipo;
        Fator = fator;
    }
}

class TabelaRiscoFactory {
    private readonly Dictionary<string, TabelaRisco> _cache = new();
    public TabelaRisco GetTabela(string tipo) {
        if (!_cache.ContainsKey(tipo)) {
            decimal fator = tipo == "Alta" ? 1.5m : 1.0m;
            _cache[tipo] = new TabelaRisco(tipo, fator);
        }
        return _cache[tipo];
    }
}
#endregion

#region Proxy
interface IApresentadorDocumento {
    void Mostrar();
}

class DocumentoReal : IApresentadorDocumento {
    private readonly string _arquivo;
    public DocumentoReal(string arquivo) {
        _arquivo = arquivo;
        Console.WriteLine($"[Carregando {_arquivo}]...");
    }
    public void Mostrar() => Console.WriteLine($"Mostrando documento: {_arquivo}");
}

class ProxyDocumento : IApresentadorDocumento {
    private DocumentoReal _real;
    private readonly string _arquivo;
    private readonly string _usuario;
    public ProxyDocumento(string arquivo, string usuario) {
        _arquivo = arquivo;
        _usuario = usuario;
    }
    public void Mostrar() {
        if (_usuario != "corretor") {
            Console.WriteLine("Acesso negado ao documento.");
        } else {
            _real ??= new DocumentoReal(_arquivo);
            _real.Mostrar();
        }
    }
}
#endregion

#region Facade
class ValidadorDados {
    public void Validar(string cpf) => Console.WriteLine($"Validando CPF: {cpf}");
}

class AvaliadorRisco {
    public string Avaliar(decimal premio) => premio > 1500 ? "Alta" : "Normal";
}

class GeradorContrato {
    public void Gerar(string cliente, string tipoRisco, decimal premio) =>
        Console.WriteLine($"Contrato: {cliente} | Risco: {tipoRisco} | Premio Final: {premio:C}");
}

class SubscricaoFacade {
    private readonly ValidadorDados _validador = new();
    private readonly AvaliadorRisco _avaliador = new();
    private readonly GeradorContrato _gerador = new();
    private readonly TabelaRiscoFactory _factory = new();

    public void SubscricaoCompleta(string cliente, string cpf, IApólice apolice) {
        _validador.Validar(cpf);

        decimal premioBase = apolice.CalcularPremio();
        string risco = _avaliador.Avaliar(premioBase);
        decimal premioFinal = premioBase * _factory.GetTabela(risco).Fator;

        _gerador.Gerar(cliente, risco, premioFinal);
    }
}
#endregion

class Program {
    static void Main() {
        Console.WriteLine("--- Seguro Auto Cliente X ---");

        IApólice apolice = new ApoliceBasica();
        apolice = new CoberturaRoubo(apolice);
        apolice = new CoberturaIncendio(apolice);

        Console.WriteLine(apolice.Descricao());

        var facade = new SubscricaoFacade();
        facade.SubscricaoCompleta("Cliente X", "123.456.789-00", apolice);

        Console.WriteLine("\n--- Documento de Apólice ---");
        IApresentadorDocumento doc = new ProxyDocumento("apolice_123.pdf", "cliente");
        doc.Mostrar();

        doc = new ProxyDocumento("apolice_123.pdf", "corretor");
        doc.Mostrar();
    }
}
