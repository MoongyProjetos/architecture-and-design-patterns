// See https://aka.ms/new-console-template for more information
using Seguradora.Logica;
using Seguradora.Modelo;

Console.WriteLine("Hello, World!");

var cliente = new Cliente();
cliente.Id = Guid.NewGuid();
cliente.Nome = "Zé das Couves";
cliente.NumeroFiscal = "12345679";


var apolice = new Apolice();
apolice.Id = Guid.NewGuid();
apolice.DataEfetivacao = DateTime.Today;
apolice.CondicoesEspeciais = "condicoes especiais";
apolice.Cliente = cliente;


IRepository<Apolice, Guid> repository = new ApoliceRepository();

//Fake DependencyInjector
var gerenciadorApolice = new GerenciadorApolice(repository, apolice);


gerenciadorApolice.CriarNovoSeguro();


Exemplos.ExemploUsoSingleton();
Console.WriteLine("Press any key to exit...");



Exemplos.ExemploUsoFactoryMethod();