using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemNotaris.Domain.Akta;
using SistemNotaris.Domain.Client;
using SistemNotaris.Domain.Shared;

namespace SistemNotaris.Infrastructure.Configurations;

internal sealed class AktaConfiguration : IEntityTypeConfiguration<Akta>
{
    public void Configure(EntityTypeBuilder<Akta> builder)
    {
        builder.ToTable("Akta");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .IsRequired();

        builder.Property(a => a.ClientId)
            .IsRequired()
            .HasMaxLength(16);

        builder.Property(a => a.NamaAkta)
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(
                nama => nama.value,
                value => new Nama(value)
            );
        builder.Property(a => a.JenisAkta)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(a => a.TanggalSelesai)
            .IsRequired(false);
        builder.HasOne<Clients>()
            .WithMany()
            .HasForeignKey(a => a.ClientId);
    }
}
