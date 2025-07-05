using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemNotaris.Domain.Karyawan;
using SistemNotaris.Domain.Shared;

namespace SistemNotaris.Infrastructure.Configurations;

internal sealed class KaryawanConfiguration : IEntityTypeConfiguration<Karyawans>
{
    public void Configure(EntityTypeBuilder<Karyawans> builder)
    {
        builder.ToTable("Karyawan");

        builder.HasKey(k => k.Id);

        builder.Property(k => k.Id)
            .IsRequired();

        builder.Property(k => k.Nama)
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(
                nama => nama.value,
                value => new Nama(value)
            );

        builder.Property(k => k.NoTelfon)
            .IsRequired()
            .HasMaxLength(15)
            .HasConversion(
                noTelfon => noTelfon.value,
                value => new NoTelfon(value)
            );

        builder.OwnsOne(k => k.LoginStatus, ls =>
        {
            ls.Property(x => x.IsOnline).IsRequired();
            ls.Property(x => x.LastOnline).IsRequired();
        });

        builder.OwnsOne(k => k.Record, r =>
        {   
            r.Property(x => x.JumlahPengerjaan).IsRequired();
        });
    }
}
