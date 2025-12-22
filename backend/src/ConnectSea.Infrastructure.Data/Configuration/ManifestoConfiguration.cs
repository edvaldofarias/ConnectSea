using ConnectSea.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectSea.Infrastructure.Data.Configuration;

public class ManifestoConfiguration : IEntityTypeConfiguration<Manifesto>
{
    public void Configure(EntityTypeBuilder<Manifesto> builder)
    {
        builder.ToTable("Manifestos");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Numero)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(m => m.Tipo)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(m => m.Navio)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.PortoOrigem)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.PortoDestino)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.DateCreated)
            .IsRequired();
        
        builder.Property(m => m.DateModified)
            .IsRequired(false);
    }
}