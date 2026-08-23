using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Inventory;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Inventory;

public class StockTransactionConfiguration : IEntityTypeConfiguration<StockTransaction>
{
    public void Configure(EntityTypeBuilder<StockTransaction> builder)
    {
        builder.ToTable("StockTransactions");

        builder.HasIndex(x => x.MaterialId);
        builder.HasIndex(x => x.WarehouseId);
        builder.HasIndex(x => x.DocumentType);
        builder.HasIndex(x => x.DocumentId);
        builder.HasIndex(x => x.TransactionDate);
    }
}
