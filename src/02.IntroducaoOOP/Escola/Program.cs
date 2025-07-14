using Escola.Entidades;

Console.WriteLine("Hello, World!");


var joao = new Pessoa
{
    Nome = "Joao da Silva",
    NumeroTelefone = "12345678",
    EmailAddress = "joao@email.com",
    Endereco = new Endereco
    {
        Cidade = "Lisboa",
        Pais = "Portugal",
        CodigoPostal = "2800000",
        Estado = "Lisboa"
    }
};

joao.ComprarPasseEstacionamento();