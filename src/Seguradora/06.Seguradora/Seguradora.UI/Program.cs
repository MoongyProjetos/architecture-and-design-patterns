// See https://aka.ms/new-console-template for more information
using Seguradora.Logica;
using Seguradora.Modelo;

using Seguradora.Logica.Builder;



Console.WriteLine("Hello, World!");

const string separador = "#####################################################################################";

var cliente = new Cliente();
cliente.Id = Guid.NewGuid();
cliente.Nome = "Zé das Couves";
cliente.NumeroFiscal = "12345679";
System.Console.WriteLine(separador);

var apolice = new Apolice();
apolice.Id = Guid.NewGuid();
apolice.DataEfetivacao = DateTime.Today;
apolice.CondicoesEspeciais = "condicoes especiais";
apolice.Cliente = cliente;
System.Console.WriteLine(separador);

IRepository<Apolice, Guid> repository = new ApoliceRepository();

//Fake DependencyInjector
var gerenciadorApolice = new GerenciadorApolice(repository, apolice);


gerenciadorApolice.CriarNovoSeguro();
System.Console.WriteLine(separador);

Exemplos.ExemploUsoSingleton();
System.Console.WriteLine(separador);



Exemplos.ExemploUsoFactoryMethod();
System.Console.WriteLine(separador);


Exemplos.ExemploUsoAbstractFactory();
System.Console.WriteLine(separador);



Exemplos.ExemploUsoBuilder();
System.Console.WriteLine(separador);


var clienteExemplo = new ClienteExemplo
{
    Id = Guid.NewGuid(),
    Nome = "João da Silva",
    Endereco = "Rua Exemplo, 123"
};

System.Console.WriteLine(clienteExemplo);
System.Console.WriteLine(separador);


Exemplos.ExemploUsoPrototype();
System.Console.WriteLine(separador);


Exemplos.ExemploUsoObjectPoolLiberandoPool();
System.Console.WriteLine(separador);


Exemplos.ExemploUsoObjectPoolSemLiberarPool();
System.Console.WriteLine(separador);




