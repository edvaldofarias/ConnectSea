using ConnectSea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConnectSea.Infrastructure.Data.Context;

public class ConnectSeaContext(DbContextOptions<ConnectSeaContext> options) : DbContext(options) 
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConnectSeaContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Escala> Escala => Set<Escala>();

    public DbSet<Manifesto> Manifestos => Set<Manifesto>();

    public DbSet<ManifestoEscala> ManifestoEscalas => Set<ManifestoEscala>();
    
}