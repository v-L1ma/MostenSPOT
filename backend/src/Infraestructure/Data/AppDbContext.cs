using backend.Domain.Entities;
using backend.Domain.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

//tem q adicionar a classe usuario depois
public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var lugares = new List<Lugar>();
        int id = 1;

        for (char letra = 'A'; letra <= 'I'; letra++)
        {
            for (int numero = 0; numero <= 9; numero++)
            {
                lugares.Add(new Lugar
                {
                    Id = id++,
                    Posicao = $"{letra}{numero}",
                    Status = StatusCadeira.Disponivel
                });
            }
        }

        modelBuilder.Entity<Lugar>().HasData(lugares.ToArray());
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Lugar> Lugares { get; set; }
}