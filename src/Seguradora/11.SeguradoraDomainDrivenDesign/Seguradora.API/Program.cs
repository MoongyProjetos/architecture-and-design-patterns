using Seguradora.Infrastructure;
using Seguradora.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


//app.MapPost("/api/segurados", (Segurado segurado) =>
//{
//    var contexto = new SeguradoraDBContext();

//    segurado = new Segurado
//    {
//        Nome = "Exemplo",
//        DataNascimento = DateTime.Now.AddYears(-30),
//        Documento = "123456789"
//    };

//    contexto.Segurados.Add(segurado);
//    contexto.SaveChanges();
//    return Results.Created($"/api/segurados/{segurado.Id}", segurado);
//}).WithName("CreateSegurado");



app.MapPost("/api/segurados", (Segurado segurado) =>
{
    var contexto = new SeguradoraDBContext();
    contexto.Segurados.Add(segurado);
    contexto.SaveChanges();
    return Results.Created($"/api/segurados/{segurado.Id}", segurado);
}).WithName("CreateSegurado");

app.MapPut("/api/segurados", (Segurado segurado, Guid id) =>
{
    var contexto = new SeguradoraDBContext();
    var seguradoOld = contexto.Segurados.Find(id);

    if(seguradoOld != null)    
    {
        seguradoOld.Nome = segurado.Nome;
        seguradoOld.Documento = segurado.Documento;
        seguradoOld.DataNascimento = segurado.DataNascimento;

        contexto.SaveChanges();
    }

    return Results.Created($"/api/segurados/{segurado.Id}", segurado);
}).WithName("UpdateSegurado");

app.MapGet("/api/segurados", () =>
{
    var contexto = new SeguradoraDBContext();

    var segurados = contexto.Segurados.ToList();
    return segurados;
})
.WithName("GetSegurados");


///Método simplificado, utilizando o padrão generic repository
app.MapGet("/api/apolices", () =>
{
    var contexto = new SeguradoraDBContext();
    var repository = new Repository<Apolice>(contexto);
    return repository.ListarAsync();
})
.WithName("GetApolices");



app.Run();
