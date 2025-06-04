// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Pessoa joao = new Pessoa();
joao.Nome = "Joao da Silva";
joao.NumeroTelefone = "12345678";
joao.EmailAddress = "joao@email.com";


Endereco enderecoDoJoao = new Endereco();
enderecoDoJoao.Cidade = "Lisboa";
enderecoDoJoao.Pais = "Portugal";
enderecoDoJoao.CodigoPostal = "2800000";
enderecoDoJoao.Estado = "Lisboa";

joao.endereco = enderecoDoJoao;


joao.ComprarPasseEstacionamento();