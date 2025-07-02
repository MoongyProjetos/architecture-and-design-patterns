namespace Seguradora.UI;

using decorator = Seguradora.Logica.PadroesEstruturais.Decorator;
using composite = Seguradora.Logica.PadroesEstruturais.Composite;

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
        coberturaCompleta.AdicionarCobertura(new Seguradora.Logica.PadroesEstruturais.Composite.CoberturaIncendio());
        coberturaCompleta.AdicionarCobertura(new Seguradora.Logica.PadroesEstruturais.Composite.CoberturaRoubo());
        coberturaCompleta.AdicionarCobertura(new Seguradora.Logica.PadroesEstruturais.Composite.CoberturaDanosTerceiros());

        Console.WriteLine("Exemplo de uso do Composite:");
        Console.WriteLine($"Valor total da cobertura completa: {coberturaCompleta.CalcularValor()}");


        // Exemplo de uso do Composite para gerenciar coberturas de seguro de um cliente específico
        Console.WriteLine("Exemplo de uso do Composite para o seguro do José:");
        var seguroDoJose = new Seguradora.Logica.PadroesEstruturais.Composite.CompositeCobertura();
        seguroDoJose.AdicionarCobertura(new Seguradora.Logica.PadroesEstruturais.Composite.CoberturaIncendio());
        seguroDoJose.AdicionarCobertura(new Seguradora.Logica.PadroesEstruturais.Composite.CoberturaRoubo());

        Console.WriteLine("Exemplo de uso do Composite:");
        Console.WriteLine($"Valor total da cobertura do José: {seguroDoJose.CalcularValor()}");
    }

    public static void ExemploUsoPrivateDataClass()
    {
        Console.WriteLine("Exemplo de uso do Private Data Class:");

        // Criando uma apólice de seguro
        var apoliceSeguro = new Logica.PadroesEstruturais.PrivateClassData.ApoliceSeguro("João da Silva", 1500.00m, "123.456.789-00");

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
        Seguradora.Logica.PadroesEstruturais.Decorator.IApolice apolice = new Seguradora.Logica.PadroesEstruturais.Decorator.ApoliceBasica();
        Console.WriteLine($"Descrição: {apolice.Descricao()}");
        Console.WriteLine($"Prêmio: {apolice.CalcularPremio()}");

        // Adicionando cobertura de roubo
        apolice = new Seguradora.Logica.PadroesEstruturais.Decorator.CoberturaRoubo(apolice);
        Console.WriteLine($"Descrição com Cobertura de Roubo: {apolice.Descricao()}");
        Console.WriteLine($"Prêmio com Cobertura de Roubo: {apolice.CalcularPremio()}");

        // Adicionando cobertura de incêndio
        apolice = new Seguradora.Logica.PadroesEstruturais.Decorator.CoberturaIncendio(apolice);
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
        decorator.IApolice apolice = new decorator.ApoliceBasica();
        Console.WriteLine($"Descrição: {apolice.Descricao()}");
        Console.WriteLine($"Prêmio: {apolice.CalcularPremio()}");

        // Adicionando cobertura de roubo
        apolice = new decorator.CoberturaRoubo(apolice);
        Console.WriteLine($"Descrição com Cobertura de Roubo: {apolice.Descricao()}");
        Console.WriteLine($"Prêmio com Cobertura de Roubo: {apolice.CalcularPremio()}");

        // Adicionando cobertura de incêndio
        apolice = new decorator.CoberturaIncendio(apolice);
        Console.WriteLine($"Descrição com Cobertura de Incêndio: {apolice.Descricao()}");
        Console.WriteLine($"Prêmio com Cobertura de Incêndio: {apolice.CalcularPremio()}");
    }
}
