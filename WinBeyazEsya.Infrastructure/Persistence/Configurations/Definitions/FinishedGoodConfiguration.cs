using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Definitions;

public class FinishedGoodConfiguration : IEntityTypeConfiguration<FinishedGood>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<FinishedGood> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.GroupType).IsRequired();

        builder.Property(x => x.SalesPrice).HasColumnType("decimal(18,6)");
        builder.Property(x => x.SalesVatRate).HasColumnType("decimal(18,6)");

        builder.HasOne(x => x.Unit)
            .WithMany()
            .HasForeignKey(x => x.UnitId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.SpecialCode)
            .WithMany()
            .HasForeignKey(x => x.SpecialCodeId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.ToTable("FinishedGoods");
    }
}
