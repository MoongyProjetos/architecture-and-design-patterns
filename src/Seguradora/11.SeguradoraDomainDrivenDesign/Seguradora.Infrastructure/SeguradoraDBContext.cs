namespace Seguradora.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Seguradora.Domain.Entities;

public class SeguradoraDBContext : DbContext
{
    public DbSet<Segurado> Segurados { get; set; }
    public DbSet<Apolice> Apolices { get; set; }
    public DbSet<Artefato> Artefatos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=c:\\temp\\Seguradora.db");
    }
}
