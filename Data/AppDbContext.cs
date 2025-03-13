using ApiCrud.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ApiCrud.Data;

public class AppDbContext : DbContext
{
    public DbSet<Estudante> Estudantes { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
