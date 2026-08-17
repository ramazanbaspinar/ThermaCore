using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Definitions;

public class GeneralExpenseConfiguration : IEntityTypeConfiguration<GeneralExpense>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<GeneralExpense> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.CurrencyCode).HasMaxLength(5);
        builder.Property(x => x.Cost).HasColumnType("decimal(18,4)");

        builder.HasIndex(x => x.Code).IsUnique();

        builder.ToTable("GeneralExpenses");
    }
}

