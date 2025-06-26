using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemNotaris.Domain.Client;
using SistemNotaris.Domain.Shared;

namespace SistemNotaris.Infrastructure.Configurations;

internal sealed class ClientsConfiguration :  IEntityTypeConfiguration<Clients>
{
    public void Configure(EntityTypeBuilder<Clients> builder)
    {
        builder.ToTable("Clients");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .IsRequired()
            .HasMaxLength(16);

        builder.Property(c => c.Nama)
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(
                nama => nama.value,
                value => new Nama(value)
            );
        builder.OwnsOne(c => c.Alamat);
        builder.Property(c => c.NoTelfon)
            .HasMaxLength(15)
            .HasConversion(
                noTelfon => noTelfon .value,
                value => new NoTelfon(value)
                );
    }
}