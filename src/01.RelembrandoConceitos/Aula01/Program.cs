using Aula01;

Console.WriteLine("Hello, World!");

if(2 == 2)
{
    Console.WriteLine("2 is equal to 2");
}
else
{
    Console.WriteLine("2 is not equal to 2");
}


for (int w = 0; w < 10; w++)
{
    Console.WriteLine(w);
}

var i = 0;
while (i < 10)
{
    i++;
}

var j = 0;
do
{
    j++;
}while(j < 10);

var lista = new List<Pessoa>();
foreach (var item in lista)
{
    System.Console.WriteLine(item.CalcularIdade());
}


PessoaSingular p = new PessoaSingular();
p.Nome = "Maria";
p .DataNascimento = new DateTime(1984,05,29);
Console.WriteLine(p.Idade);


var p2 = new PessoaColetiva
{
     Nome = "Empresa",
     DataCriacao = new DateTime(1984,09,20)   
};
Console.WriteLine(p2.Idade);



PessoaSingular p3 = new PessoaSingular("Marta", Aula01.Dominio.Sexo.Feminino);
p3.DataNascimento = new DateTime(1984,05,29);
Console.WriteLine(p3.Idade);

