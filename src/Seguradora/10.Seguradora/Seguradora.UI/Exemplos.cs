using Command = Seguradora.Logica.PadroesComportamentais.Command;
using Decorator = Seguradora.Logica.PadroesEstruturais.Decorator;
using Composite = Seguradora.Logica.PadroesEstruturais.Composite;
using Flyweight = Seguradora.Logica.PadroesEstruturais.Flyweight;
using Observer = Seguradora.Logica.PadroesComportamentais.Observer;
using Strategy = Seguradora.Logica.PadroesComportamentais.Strategy;
using State = Seguradora.Logica.PadroesComportamentais.State;
using Visitor = Seguradora.Logica.PadroesComportamentais.Visitor;
using Interpreter = Seguradora.Logica.PadroesComportamentais.Interpreter;

namespace Seguradora.UI;

public static class Exemplos
{
    /// <summary>
    /// Exemplo de uso do Singleton SystemConfiguration.
    /// </summary>
    public static void ExemploUsoSingleton()
    {
        Console.WriteLine("Exemplo de uso do Singleton SystemConfiguration:");

        //Exemplo de uso do Singleton
        var config = SystemConfiguration.Instance;
        Console.WriteLine($"Id Instancia 1: {config.Id}");
        Console.WriteLine($"Taxa Seguro Vida: {config.SeguroVidaTaxa}");
        Console.WriteLine($"Taxa Seguro Auto: {config.SeguroAutoTaxa}");
        Console.WriteLine($"API Key Serviço Externo: {config.ApiKeyServicoExterno}");

        // Demonstrating that the singleton instance is the same
        var config2 = SystemConfiguration.Instance;
        Console.WriteLine($"Id Instancia (config2): {config2.Id}");
        Console.WriteLine($"Taxa Seguro Vida (config2): {config2.SeguroVidaTaxa}");
        Console.WriteLine($"Taxa Seguro Auto (config2): {config2.SeguroAutoTaxa}");
        Console.WriteLine($"API Key Serviço Externo (config2): {config2.ApiKeyServicoExterno}");

        // Demonstrating that the singleton instance is the same
        var config3 = SystemConfiguration.Instance;
        Console.WriteLine($"Id Instancia (config3): {config3.Id}");
        Console.WriteLine($"Taxa Seguro Vida (config3): {config3.SeguroVidaTaxa}");
        Console.WriteLine($"Taxa Seguro Auto (config3): {config3.SeguroAutoTaxa}");
        Console.WriteLine($"API Key Serviço Externo (config3): {config3.ApiKeyServicoExterno}");
    }


    /// <summary>
    /// Exemplo de uso do Factory Method para criar um seguro.
    /// Reparem na simplicidade que é derivar entre os tipos diferentes de seguro.
    /// </summary>
    public static void ExemploUsoFactoryMethod()
    {
        Console.WriteLine("Exemplo de uso do Factory Method:");

        SeguroCreator criador;

        criador = new SeguroVidaCreator();
        Console.WriteLine(criador.ProcessarApolice());

        criador = new SeguroAutomovelCreator();
        Console.WriteLine(criador.ProcessarApolice());

        criador = new SeguroResidencialCreator();
        Console.WriteLine(criador.ProcessarApolice());

        criador = new SeguroPetCreator();
        Console.WriteLine(criador.ProcessarApolice());
    }


    /// <summary>
    /// Exemplo de uso do Abstract Factory para criar seguros.
    /// Reparem na simplicidade que é derivar entre os tipos diferentes de seguro.
    /// </summary>
    public static void ExemploUsoAbstractFactory()
    {
        Console.WriteLine("Exemplo de uso do Abstract Factory com Seguro:");

        ISeguroFactory factory = new SeguroPessoaFisicaFactory();
        var servico = new ServicoSeguro(factory);
        servico.Processar();

        factory = new SeguroPessoaJuridicaFactory();
        servico = new ServicoSeguro(factory);
        servico.Processar();
    }


    /// <summary>
    ///  Exemplo de uso do Builder para criar uma apólice.
    /// O Builder permite construir objetos complexos passo a passo.
    /// </summary>
    public static void ExemploUsoBuilder()
    {
        Console.WriteLine("Exemplo de uso do Builder:");

        // Aqui você pode implementar o exemplo de uso do Builder
        // Exemplo: var apolice = new ApoliceBuilder().ComTipo("Auto").ComCobertura("Total").Build();
        // Console.WriteLine(apolice);

        var geradorApolice = new GeradorApolice();
        var apoliceSimples = GeradorApolice.CriarSimples(new ApoliceAutoBuilder());
        Console.WriteLine(apoliceSimples);

        var apoliceCompleta = GeradorApolice.CriarCompleta(new ApoliceAutoBuilder());
        Console.WriteLine(apoliceCompleta);
    }

    public static void ExemploUsoPrototype()
    {
        Console.WriteLine("Exemplo de uso do Prototype:");

        // Aqui você pode implementar o exemplo de uso do Prototype
        // Exemplo: var apolice = new Apolice().Clone();
        // Console.WriteLine(apolice);

        var apoliceOriginal = new Logica.PadroesCriacionais.Prototype.Apolice
        {
            Id = Guid.NewGuid(),
            Tipo = "Auto",
            Cobertura = "Total",
            ValorMensal = 150.00m
        };


        var apoliceClone = apoliceOriginal.Clone();

        var apoliceCloneSimples = apoliceOriginal.SimpleClone(); // Usando o método SimpleClone

        Console.WriteLine($"Apolice Original: {apoliceOriginal.Tipo}, {apoliceOriginal.Cobertura}, {apoliceOriginal.ValorMensal}, {apoliceOriginal.Id}");
        Console.WriteLine($"Apolice Clone: {apoliceClone.Tipo}, {apoliceClone.Cobertura}, {apoliceClone.ValorMensal}, {apoliceClone.Id}");
        Console.WriteLine($"Apolice Clone Simples: {apoliceCloneSimples.Tipo}, {apoliceCloneSimples.Cobertura}, {apoliceCloneSimples.ValorMensal}, {apoliceCloneSimples.Id}");
    }

    /// <summary>
    ///  Exemplo de uso do Object Pool para gerenciar instâncias de Cotador.
    /// O Object Pool é útil para reutilizar objetos caros de serem criados, como conexões
    /// </summary>
    public static void ExemploUsoObjectPoolLiberandoPool()
    {
        var pool = new CotadorPool(2);

        try
        {
            var cotador1 = pool.ObterCotador();
            Cotador.RealizarCotacao("123.456.789-00");
            pool.DevolverCotador(cotador1); //Devolvendo para o pool sempre funciona
            Console.WriteLine(Cotador.Id);

            var cotador2 = pool.ObterCotador();
            Cotador.RealizarCotacao("111.222.333-44");
            pool.DevolverCotador(cotador2);
            Console.WriteLine(Cotador.Id);

            var cotador3 = pool.ObterCotador();
            Cotador.RealizarCotacao("111.222.333-44");
            pool.DevolverCotador(cotador3);
            Console.WriteLine(Cotador.Id);

            var cotador4 = pool.ObterCotador();
            Cotador.RealizarCotacao("111.222.333-44");
            pool.DevolverCotador(cotador4);
            Console.WriteLine(Cotador.Id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void ExemploUsoObjectPoolSemLiberarPool()
    {
        var pool2 = new CotadorPool(2);
        try
        {
            var cotador21 = pool2.ObterCotador();
            Cotador.RealizarCotacao("123.456.789-00");
            // pool.DevolverCotador(cotador1); //Deixei de devolver, vou ter erro no terceiro
            Console.WriteLine(Cotador.Id);

            var cotador22 = pool2.ObterCotador();
            Cotador.RealizarCotacao("111.222.333-44");
            // pool.DevolverCotador(cotador2); //Deixei de devolver, vou ter erro no terceiro
            Console.WriteLine(Cotador.Id);

            var cotador23 = pool2.ObterCotador();
            Cotador.RealizarCotacao("111.222.333-44");
            Console.WriteLine(Cotador.Id);
        }
        catch (Exception ex)
        {
            //Aqui vai dar o erro, porque não temos mais "espaço" disponível no Pool
            Console.WriteLine(ex.Message);
        }
    }

    public static void ExemploUsoAdapter()
    {
        Console.WriteLine("Exemplo de uso do Adapter:");

        // Usando o serviço legado através do adaptador
        var policyService = new LegacyPolicyAdapter(new LegacyPolicyService());
        var policyDetails = policyService.GetPolicy("ABC123");

        Console.WriteLine($"Número da Apólice: {policyDetails.PolicyNumber}");
        Console.WriteLine($"Nome do Titular: {policyDetails.PolicyHolderName}");
        Console.WriteLine($"Data de Início: {policyDetails.StartDate}");
        Console.WriteLine($"Data de Término: {policyDetails.EndDate}");
    }

    public static void ExemploUsoBridge()
    {
        Console.WriteLine("Exemplo de uso do Bridge:");

        // Usando o relatório de apólice de automóvel com exportação em PDF
        IReportExporter pdfExporter = new PdfExporter();
        RelatorioApolice relatorioAutomovel = new RelatorioApoliceAutomovel(pdfExporter);
        relatorioAutomovel.Gerar();

        // Usando o relatório de apólice de vida com exportação em Word
        IReportExporter wordExporter = new WordExporter();
        RelatorioApolice relatorioVida = new RelatorioApoliceVida(wordExporter);
        relatorioVida.Gerar();

        // Usando o relatório de apólice de automóvel com exportação em CSV
        IReportExporter csvExporter = new CsvExporter();
        RelatorioApolice relatorioAutomovelCsv = new RelatorioApoliceAutomovel(csvExporter);
        relatorioAutomovelCsv.Gerar();
    }

    public static void ExemploUsoComposite()
    {
        // Exemplo de uso do Composite para gerenciar coberturas de seguro
        var coberturaCompleta = new CompositeCobertura();
        coberturaCompleta.AdicionarCobertura(new Composite.CoberturaIncendio());
        coberturaCompleta.AdicionarCobertura(new Composite.CoberturaRoubo());
        coberturaCompleta.AdicionarCobertura(new CoberturaDanosTerceiros());

        Console.WriteLine("Exemplo de uso do Composite:");
        Console.WriteLine($"Valor total da cobertura completa: {coberturaCompleta.CalcularValor()}");


        // Exemplo de uso do Composite para gerenciar coberturas de seguro de um cliente específico
        Console.WriteLine("Exemplo de uso do Composite para o seguro do José:");
        var seguroDoJose = new CompositeCobertura();
        seguroDoJose.AdicionarCobertura(new Composite.CoberturaIncendio());
        seguroDoJose.AdicionarCobertura(new Composite.CoberturaRoubo());

        Console.WriteLine("Exemplo de uso do Composite:");
        Console.WriteLine($"Valor total da cobertura do José: {seguroDoJose.CalcularValor()}");
    }

    public static void ExemploUsoPrivateDataClass()
    {
        Console.WriteLine("Exemplo de uso do Private Data Class:");

        // Criando uma apólice de seguro
        var apoliceSeguro = new ApoliceSeguro("João da Silva", 1500.00m, "123.456.789-00");

        // Obtendo informações da apólice
        Console.WriteLine($"Segurado: {apoliceSeguro.ObterSegurado()}");
        Console.WriteLine($"Prêmio: {apoliceSeguro.ObterPremio()}");
        Console.WriteLine($"CPF Mascarado: {apoliceSeguro.ObterCPFMascarado()}");
    }

    /// <summary>
    /// Exemplo de uso do Decorator para adicionar coberturas a uma apólice.
    /// O Decorator permite adicionar funcionalidades a objetos de forma dinâmica.
    /// </summary>
    public static void ExemploUsoDecorator()
    {
        Console.WriteLine("Exemplo de uso do Decorator:");

        // Criando uma apólice básica
        Decorator.IApolice apolice = new ApoliceBasica();
        Console.WriteLine($"Descrição: {apolice.Descricao()}");
        Console.WriteLine($"Prêmio: {apolice.CalcularPremio()}");

        // Adicionando cobertura de roubo
        apolice = new Decorator.CoberturaRoubo(apolice);
        Console.WriteLine($"Descrição com Cobertura de Roubo: {apolice.Descricao()}");
        Console.WriteLine($"Prêmio com Cobertura de Roubo: {apolice.CalcularPremio()}");

        // Adicionando cobertura de incêndio
        apolice = new Decorator.CoberturaIncendio(apolice);
        Console.WriteLine($"Descrição com Cobertura de Incêndio: {apolice.Descricao()}");
        Console.WriteLine($"Prêmio com Cobertura de Incêndio: {apolice.CalcularPremio()}");
    }


    /// <summary>
    /// Código de exemplo para uso do Decorator com alias.
    /// Cópia do método ExemploUsoDecorator, mas com alias para o namespace.
    /// </summary>
    public static void ExemploUsoDecoratorComAlias()
    {
        Console.WriteLine("Exemplo de uso do Decorator:");

        // Criando uma apólice básica
        Decorator.IApolice apolice = new ApoliceBasica();
        Console.WriteLine($"Descrição: {apolice.Descricao()}");
        Console.WriteLine($"Prêmio: {apolice.CalcularPremio()}");

        // Adicionando cobertura de roubo
        apolice = new Decorator.CoberturaRoubo(apolice);
        Console.WriteLine($"Descrição com Cobertura de Roubo: {apolice.Descricao()}");
        Console.WriteLine($"Prêmio com Cobertura de Roubo: {apolice.CalcularPremio()}");

        // Adicionando cobertura de incêndio
        apolice = new Decorator.CoberturaIncendio(apolice);
        Console.WriteLine($"Descrição com Cobertura de Incêndio: {apolice.Descricao()}");
        Console.WriteLine($"Prêmio com Cobertura de Incêndio: {apolice.CalcularPremio()}");
    }


    /// <summary>
    /// Exemplo de uso do Facade para subscrição de seguro.
    /// O Facade simplifica a interação com subsistemas complexos, como validação de dados
    /// </summary>
    public static void ExemploUsoFacade()
    {
        Console.WriteLine("Exemplo de uso do Facade:");

        // Usando a fachada para subscrição de seguro
        var subscricao = new SubscricaoFacade();
        subscricao.SubscricaoCompleta("123.456.789-00");
    }

    /// <summary>
    /// Exemplo de uso do Flyweight para gerenciar tabelas de risco.
    /// O Flyweight é útil para economizar memória ao compartilhar objetos imutáveis.
    /// </summary>
    public static void ExemploUsoFlyweight()
    {
        Console.WriteLine("Exemplo de uso do Flyweight:");

        // Criando a fábrica de tabelas de risco
        var tabelaRiscoFactory = new TabelaRiscoFactory();

        // Obtendo tabelas de risco
        var tabelaAlta = tabelaRiscoFactory.GetTabela("Alta");
        var tabelaMedia = tabelaRiscoFactory.GetTabela("Média");
        var tabelaBaixa = tabelaRiscoFactory.GetTabela("Baixa");

        // Criando apólices com as tabelas de risco
        var apolice1 = new Flyweight.Apolice("Cliente 1", tabelaAlta);
        var apolice2 = new Flyweight.Apolice("Cliente 2", tabelaMedia);
        var apolice3 = new Flyweight.Apolice("Cliente 3", tabelaBaixa);

        // Imprimindo as apólices
        apolice1.Imprimir();
        apolice2.Imprimir();
        apolice3.Imprimir();
    }

    /// <summary>
    /// Exemplo de uso do Proxy para apresentar documentos.
    /// O Proxy controla o acesso a um objeto, permitindo que apenas usuários autorizados possam acessá
    /// </summary>
    public static void ExemploUsoProxy()
    {
        Console.WriteLine("Exemplo de uso do Proxy:");

        // Usando o proxy para apresentar um documento
        IApresentadorDocumento apresentador = new ProxyDocumento("documento.pdf", "corretor");
        apresentador.Mostrar();

        // Tentando acessar com um usuário sem permissão
        apresentador = new ProxyDocumento("documento.pdf", "cliente");
        apresentador.Mostrar();
    }


    /// <summary>
    /// Exemplo de uso do Observer para notificar clientes sobre atualizações de apólice.
    /// O Observer permite que objetos sejam notificados sobre mudanças em outro objeto.
    /// </summary>
    public static void ExemploUsoObserver()
    {
        Console.WriteLine("Exemplo de uso do Observer:");

        // Criando uma apólice
        var apolice = new Observer.Apolice("APOLICE-123");

        // Criando clientes observadores
        var cliente1 = new Observer.ClienteObserver("João");
        var cliente2 = new Observer.ClienteObserver("Maria");

        // Adicionando clientes à apólice
        apolice.AdicionarCliente(cliente1);
        apolice.AdicionarCliente(cliente2);

        // Atualizando a apólice e notificando os clientes
        apolice.AtualizarApolice("Cobertura de incêndio adicionada.");
    }



    /// <summary>
    /// Exemplo de uso do Strategy para calcular prêmios de seguros.
    /// O Strategy permite definir uma família de algoritmos, encapsulá-los e torná-los intercambiáveis.
    /// O algoritmo pode variar independentemente dos clientes que o utilizam.
    /// </summary>
    public static void ExemploUsoStrategy()
    {
        Console.WriteLine("Exemplo de uso do Strategy:");

        var seguroVeiculo = new Strategy.Seguro(new Strategy.CalculoSeguroVeiculo());
        var premioVeiculo = seguroVeiculo.Calcular(50000, 24);
        Console.WriteLine("Prêmio Seguro Veículo: R$" + premioVeiculo);

        var seguroVida = new Strategy.Seguro(new Strategy.CalculoSeguroVida());
        var premioVida = seguroVida.Calcular(50000, 24);
        Console.WriteLine("Prêmio Seguro Vida: R$" + premioVida);

        var seguroResidencial = new Strategy.Seguro(new Strategy.CalculoSeguroResidencial());
        var premioResidencial = seguroResidencial.Calcular(50000, 24);
        Console.WriteLine("Prêmio Seguro Residencial: R$" + premioResidencial);

        var seguroEletronicos = new Strategy.Seguro(new Strategy.CalculoSeguroEletronicos());
        var premioEletronicos = seguroEletronicos.Calcular(50000, 24);
        Console.WriteLine("Prêmio Seguro Eletrônicos: R$" + premioEletronicos);
    }

    /// <summary>
    /// Exemplo de uso do Command para emitir e cancelar apólices.
    /// O Command encapsula uma solicitação como um objeto, permitindo parametrizar clientes com filas,
    /// </summary>
    public static void ExemploUsoCommand()
    {
        Console.WriteLine("Exemplo de uso do Command:");

        var gestor = new Command.GestorApolices();
        var emitirCmd = new Command.EmitirApoliceCommand(gestor, "POL78910");
        var cancelarCmd = new Command.CancelarApoliceCommand(gestor, "POL78910");

        var central = new Command.CentralComandos();
        central.ExecutarComando(emitirCmd);
        central.ExecutarComando(cancelarCmd);
    }


    /// <summary>
    /// Exemplo de uso do Chain of Responsibility para aprovar sinistros.
    /// O Chain of Responsibility permite que uma solicitação seja passada por uma cadeia de objetos,
    /// onde cada objeto pode processar a solicitação ou passá-la adiante.
    public static void ExemploUsoChainOfResponsibility()
    {
        Console.WriteLine("Exemplo de uso do Chain of Responsibility:");

        // Montando a cadeia de responsabilidade
        var atendente = new Atendente();
        var gerente = new Gerente();
        var diretor = new Diretor();

        atendente.DefinirProximo(gerente);
        gerente.DefinirProximo(diretor);

        // Casos de teste
        var sinistro1 = new Sinistro("Retrovisor quebrado", 1200);
        var sinistro2 = new Sinistro("Batida leve", 10000);
        var sinistro3 = new Sinistro("Perda total", 50000);
        var sinistro4 = new Sinistro("Incêndio total da frota", 500000);

        // Processando os sinistros
        atendente.Aprovar(sinistro1);
        atendente.Aprovar(sinistro2);
        atendente.Aprovar(sinistro3);
        atendente.Aprovar(sinistro4);
    }


    /// <summary>
    /// Exemplo de uso do State para gerenciar o estado de uma apólice.
    /// O State permite que um objeto altere seu comportamento quando seu estado interno muda.
    /// O objeto parecerá mudar sua classe.
    /// Neste exemplo, a apólice pode estar em diferentes estados, como Em Análise,
    /// Emitida, Cancelada e Expirada.
    /// Cada estado implementa uma interface comum e define seu próprio comportamento.
    /// </summary>
    public static void ExemploUsoState()
    {
        Console.WriteLine("Exemplo de uso do State:");

        var apolice = new State.Apolice();

        // Apólice ainda sem estado
        apolice.Processar();

        // Estado: Em análise
        apolice.DefinirEstado(new EmAnalise());
        apolice.Processar();

        // Estado: Emitida
        apolice.DefinirEstado(new Emitida());
        apolice.Processar();

        // Estado: Cancelada
        apolice.DefinirEstado(new Cancelada());
        apolice.Processar();

        // Estado: Expirada
        apolice.DefinirEstado(new Expirada());
        apolice.Processar();
    }


    /// <summary>
    /// Exemplo de uso do Visitor para gerar relatórios de seguros.
    /// O Visitor permite que você adicione novas operações a objetos sem modificar suas classes.
    /// Neste exemplo, temos diferentes tipos de seguros (SeguroAuto e SeguroVida)
    /// e dois tipos de relatórios (RelatorioSimples e RelatorioComplexo).
    /// Cada relatório implementa a interface IVisitor e define como visitar cada tipo de seguro.
    /// </summary>
    public static void ExemploUsoVisitor()
    {
        Console.WriteLine("Exemplo de uso do Visitor:");

        // Instanciando seguros
        var seguroAuto = new Visitor.SeguroAuto { Modelo = "SUV" };
        var seguroVida = new Visitor.SeguroVida { Beneficiario = "Maria" };

        // Criando o visitante
        Visitor.IVisitor relatorio = new Visitor.RelatorioSimples();
        Visitor.IVisitor relatorioComplexo = new Visitor.RelatorioComplexo();

        // Visitando os seguros
        seguroAuto.Aceitar(relatorio);
        seguroVida.Aceitar(relatorio);


        seguroVida.Aceitar(relatorioComplexo);
    }

    public static void ExemploUsoInterpreter()
    {
        Console.WriteLine("Exemplo de uso do Interpreter:");

        // Criar a expressão: idade > 25 AND tem seguro anterior
        var regra = new E(new IdadeMaiorQue25(), new PossuiSeguroAnterior(), new RegraAleatoria());

        // Teste 1
        var cliente1 = new Contexto { Idade = 30, TemSeguroAnterior = true };
        Console.WriteLine("Cliente 1 aprovado? " + regra.Interpretar(cliente1)); // true

        // Teste 2
        var cliente2 = new Contexto { Idade = 22, TemSeguroAnterior = true };
        Console.WriteLine("Cliente 2 aprovado? " + regra.Interpretar(cliente2)); // false

        // Teste 3
        var cliente3 = new Contexto { Idade = 28, TemSeguroAnterior = false };
        Console.WriteLine("Cliente 3 aprovado? " + regra.Interpretar(cliente3)); // false
    }
}
