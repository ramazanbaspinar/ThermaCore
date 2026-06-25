using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Definitions;

public class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategory>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<ItemCategory> builder)
    {
        builder.ToTable("ItemCategories");

        builder.HasIndex(ic => ic.Code).IsUnique();

        builder.HasOne(ic => ic.Parent)
               .WithMany()
               .HasForeignKey(ic => ic.ParentId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
