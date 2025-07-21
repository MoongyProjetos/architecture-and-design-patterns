// Sistema de Seguradora com Padrões Comportamentais Integrados
using System;
using System.Collections.Generic;

// ========================= NULL OBJECT =========================
public interface ICliente {
    string ObterNome();
}

public class ClienteReal : ICliente {
    private string _nome;
    public ClienteReal(string nome) => _nome = nome;
    public string ObterNome() => _nome;
}

public class ClienteNull : ICliente {
    public string ObterNome() => "Cliente não definido";
}

// ========================= ITERATOR =========================
public class Proposta {
    public string TipoSeguro { get; set; }
    public ICliente Cliente { get; set; }
}

public interface IIteradorProposta {
    bool TemProxima();
    Proposta Proxima();
}

public class ColecaoPropostas {
    private List<Proposta> _propostas = new();
    public void Adicionar(Proposta p) => _propostas.Add(p);
    public IIteradorProposta CriarIterador() => new IteradorPropostas(_propostas);
}

public class IteradorPropostas : IIteradorProposta {
    private List<Proposta> _propostas;
    private int _indice = 0;

    public IteradorPropostas(List<Proposta> propostas) => _propostas = propostas;
    public bool TemProxima() => _indice < _propostas.Count;
    public Proposta Proxima() => _propostas[_indice++];
}

// ========================= TEMPLATE METHOD =========================
public abstract class AvaliacaoRisco {
    public void Avaliar() {
        ColetarDados();
        CalcularRisco();
        EmitirRelatorio();
    }

    protected abstract void ColetarDados();
    protected abstract void CalcularRisco();
    protected virtual void EmitirRelatorio() {
        Console.WriteLine("Relatório padrão emitido.");
    }
}

public class AvaliacaoAuto : AvaliacaoRisco {
    protected override void ColetarDados() => Console.WriteLine("Coletando dados do veículo...");
    protected override void CalcularRisco() => Console.WriteLine("Risco calculado com base no perfil do motorista.");
}

// ========================= MEMENTO =========================
public class MementoProposta {
    public string TipoSeguro { get; }
    public MementoProposta(string tipo) => TipoSeguro = tipo;
}

public class EditorProposta {
    public string TipoSeguro { get; set; }
    public MementoProposta CriarMemento() => new(TipoSeguro);
    public void Restaurar(MementoProposta m) => TipoSeguro = m.TipoSeguro;
}

public class Historico {
    private Stack<MementoProposta> _historico = new();
    public void Salvar(MementoProposta m) => _historico.Push(m);
    public MementoProposta Desfazer() => _historico.Pop();
}

// ========================= MEDIATOR =========================
public interface IMediador {
    void EnviarMensagem(string msg, Departamento origem);
}

public abstract class Departamento {
    protected IMediador _mediador;
    public Departamento(IMediador m) => _mediador = m;
    public abstract void Receber(string msg);
}

public class Avaliacao : Departamento {
    public Avaliacao(IMediador m) : base(m) { }
    public void SolicitarAprovacao() => _mediador.EnviarMensagem("Aprovar proposta.", this);
    public override void Receber(string msg) => Console.WriteLine("Avaliacao recebeu: " + msg);
}

public class Emissao : Departamento {
    public Emissao(IMediador m) : base(m) { }
    public override void Receber(string msg) => Console.WriteLine("Emissao recebeu: " + msg);
}

public class MediadorCentral : IMediador {
    public Avaliacao Avaliacao { get; set; }
    public Emissao Emissao { get; set; }

    public void EnviarMensagem(string msg, Departamento origem) {
        if (origem == Avaliacao) Emissao.Receber(msg);
        else Avaliacao.Receber(msg);
    }
}

// ========================= EXECUÇÃO =========================
class Programa {
    static void Main() {
        // Null Object
        ICliente cliente1 = new ClienteReal("João");
        ICliente cliente2 = new ClienteNull();

        // Iterator
        var colecao = new ColecaoPropostas();
        colecao.Adicionar(new Proposta { TipoSeguro = "Auto", Cliente = cliente1 });
        colecao.Adicionar(new Proposta { TipoSeguro = "Vida", Cliente = cliente2 });

        var iterador = colecao.CriarIterador();
        while (iterador.TemProxima()) {
            var p = iterador.Proxima();
            Console.WriteLine($"Proposta: {p.TipoSeguro}, Cliente: {p.Cliente.ObterNome()}");
        }

        // Template Method
        AvaliacaoRisco avaliacao = new AvaliacaoAuto();
        avaliacao.Avaliar();

        // Memento
        var editor = new EditorProposta { TipoSeguro = "Auto" };
        var historico = new Historico();
        historico.Salvar(editor.CriarMemento());
        editor.TipoSeguro = "Residencial";
        Console.WriteLine("Proposta atual: " + editor.TipoSeguro);
        editor.Restaurar(historico.Desfazer());
        Console.WriteLine("Após desfazer: " + editor.TipoSeguro);

        // Mediator
        var mediador = new MediadorCentral();
        var depAvaliacao = new Avaliacao(mediador);
        var depEmissao = new Emissao(mediador);
        mediador.Avaliacao = depAvaliacao;
        mediador.Emissao = depEmissao;
        depAvaliacao.SolicitarAprovacao();
    }
}
