using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Purchasing;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Purchasing;

public class PurchaseOrderLineConfiguration : IEntityTypeConfiguration<PurchaseOrderLine>
{
    public void Configure(EntityTypeBuilder<PurchaseOrderLine> builder)
    {
        builder.ToTable("PurchaseOrderLines");

        // Performans İndeksleri (FK'lar)
        builder.HasIndex(x => x.PurchaseOrderId);
        builder.HasIndex(x => x.MaterialId);
        builder.HasIndex(x => x.UnitId);
    }
}
