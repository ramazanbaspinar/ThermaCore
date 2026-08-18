using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Production;

public class RawMaterialConfiguration : IEntityTypeConfiguration<RawMaterial>
{
    public void Configure(EntityTypeBuilder<RawMaterial> builder)
    {
        builder.ToTable("RawMaterials");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);

        // Discriminator is handled by TPH pattern in EF Core implicitly if we add derived types later,
        // or we can map MaterialGroup explicitly as a column (which we do here)
        builder.Property(x => x.MaterialGroup).IsRequired();

        builder.HasIndex(x => x.Code).IsUnique();
    }
}
