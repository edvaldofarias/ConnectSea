using ConnectSea.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectSea.Infrastructure.Data.Configuration;

public class EscalaConfiguration : IEntityTypeConfiguration<Escala>
{
    public void Configure(EntityTypeBuilder<Escala> builder)
    {
        builder.ToTable("Escalas");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Navio)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Porto)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(e => e.Eta)
            .IsRequired();

        builder.Property(e => e.Etb)
            .IsRequired(false);

        builder.Property(e => e.Etd)
            .IsRequired(false);

        builder.Property(e => e.DateCreated)
            .IsRequired();
        
        builder.Property(e => e.DateModified)
            .IsRequired(false);
    }
}