using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemNotaris.Domain.Karyawan;
using SistemNotaris.Domain.Shared;
using SistemNotaris.Domain.TrackingsAkta;
using SistemNotaris.Domain.UpdateAkta;

namespace SistemNotaris.Infrastructure.Configurations;

internal sealed class TrackingUpdateConfiguration : IEntityTypeConfiguration<TrackingUpdate>
{
    public void Configure(EntityTypeBuilder<TrackingUpdate> builder)
    {
        builder.ToTable("TrackingUpdate");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .IsRequired();

        builder.Property(t => t.TrackingId)
            .IsRequired();

        builder.Property(t => t.IdKaryawan)
            .IsRequired();

        builder.Property(t => t.DeskripsiPengerjaan)
            .IsRequired()
            .HasMaxLength(500)
            .HasConversion(
                deskripsi => deskripsi.value,
                value => new Deskripsi(value)
            );

        builder.Property(t => t.CreatedAt)
            .IsRequired();
        builder.HasOne<TrackingAkta>()
            .WithMany()
            .HasForeignKey(t => t.TrackingId);
        builder.HasOne<Karyawans>()
            .WithMany()
            .HasForeignKey(t => t.IdKaryawan);
    }
}
