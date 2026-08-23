using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Purchasing;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Purchasing;

public class PurchaseReceiptLineConfiguration : IEntityTypeConfiguration<PurchaseReceiptLine>
{
    public void Configure(EntityTypeBuilder<PurchaseReceiptLine> builder)
    {
        builder.ToTable("PurchaseReceiptLines");

        builder.HasIndex(x => x.PurchaseReceiptId);
        builder.HasIndex(x => x.MaterialId);
        builder.HasIndex(x => x.PurchaseOrderLineId);

        // İlişkiler
        builder.HasOne(x => x.PurchaseOrderLine)
            .WithMany()
            .HasForeignKey(x => x.PurchaseOrderLineId)
            .OnDelete(DeleteBehavior.SetNull); // Sipariş silinirse satırı null yap (istenmeyebilir ama NoAction de olabilir)
    }
}
