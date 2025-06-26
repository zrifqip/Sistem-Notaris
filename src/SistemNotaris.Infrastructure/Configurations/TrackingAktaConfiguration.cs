using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemNotaris.Domain.Akta;
using SistemNotaris.Domain.Karyawan;
using SistemNotaris.Domain.Shared;
using SistemNotaris.Domain.TrackingsAkta;
using SistemNotaris.Domain.UpdateAkta;

namespace SistemNotaris.Infrastructure.Configurations;

internal sealed class TrackingAktaConfiguration : IEntityTypeConfiguration<TrackingAkta>
{
    public void Configure(EntityTypeBuilder<TrackingAkta> builder)
    {
        builder.ToTable("TrackingAkta");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .IsRequired();

        builder.Property(t => t.IdAkta)
            .IsRequired();

        builder.Property(t => t.IdKaryawanSaatini)
            .IsRequired();

        builder.Property(t => t.Status)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(t => t.TugasSekarang)
            .IsRequired()
            .HasMaxLength(500)
            .HasConversion(
                deskripsi => deskripsi.value,
                value => new Deskripsi(value)
            );

        builder.Property(t => t.CreatedAt)
            .IsRequired();

        builder.Property(t => t.FinishedAt)
            .IsRequired(false);
        builder.HasOne<Akta>()
            .WithMany()
            .HasForeignKey(t => t.IdAkta);
        builder.HasOne<Karyawans>()
            .WithMany()
            .HasForeignKey(t => t.IdKaryawanSaatini);
    }
}
