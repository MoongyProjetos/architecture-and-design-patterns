using Seguradora.Modelo.Repositorios;
using Seguradora.UI;

Console.WriteLine("Hello, World!");

const string separador = "#####################################################################################";

var cliente = new Cliente
{
    Id = Guid.NewGuid(),
    Nome = "Zé das Couves",
    NumeroFiscal = "12345679"
};
Console.WriteLine(separador);

var apolice = new Apolice
{
    Id = Guid.NewGuid(),
    DataEfetivacao = DateTime.Today,
    CondicoesEspeciais = "condicoes especiais",
    Cliente = cliente
};
Console.WriteLine(separador);

IRepository<Apolice, Guid> repository = new ApoliceRepository();

//Fake DependencyInjector
var gerenciadorApolice = new GerenciadorApolice(repository, apolice);


gerenciadorApolice.CriarNovoSeguro();
Console.WriteLine(separador);

Exemplos.ExemploUsoSingleton();
Console.WriteLine(separador);



Exemplos.ExemploUsoFactoryMethod();
Console.WriteLine(separador);


Exemplos.ExemploUsoAbstractFactory();
Console.WriteLine(separador);



Exemplos.ExemploUsoBuilder();
Console.WriteLine(separador);


var clienteExemplo = new ClienteExemplo
{
    Id = Guid.NewGuid(),
    Nome = "João da Silva",
    Endereco = "Rua Exemplo, 123"
};

Console.WriteLine(clienteExemplo);
Console.WriteLine(separador);


Exemplos.ExemploUsoPrototype();
Console.WriteLine(separador);


Exemplos.ExemploUsoObjectPoolLiberandoPool();
Console.WriteLine(separador);


Exemplos.ExemploUsoObjectPoolSemLiberarPool();
Console.WriteLine(separador);


Exemplos.ExemploUsoAdapter();
Console.WriteLine(separador);


Exemplos.ExemploUsoBridge();
Console.WriteLine(separador);


Exemplos.ExemploUsoComposite();
Console.WriteLine(separador);

Exemplos.ExemploUsoPrivateDataClass();
Console.WriteLine(separador);