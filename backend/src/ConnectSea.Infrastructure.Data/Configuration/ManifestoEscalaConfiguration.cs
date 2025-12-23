using ConnectSea.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectSea.Infrastructure.Data.Configuration;

public sealed class ManifestoEscalaConfiguration : IEntityTypeConfiguration<ManifestoEscala>
{
    public void Configure(EntityTypeBuilder<ManifestoEscala> builder)
    {
        builder.ToTable("ManifestoEscalas");

        builder.HasKey(me => new { me.ManifestoId, me.EscalaId });

        builder.HasOne(me => me.Manifesto)
            .WithMany(m => m.ManifestoEscalas)
            .HasForeignKey(me => me.ManifestoId);

        builder.HasOne(me => me.Escala)
            .WithMany()
            .HasForeignKey(me => me.EscalaId);
    }
}