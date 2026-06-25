using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Infrastructure.Persistence.Configurations.Definitions;

public class UnitConfiguration : IEntityTypeConfiguration<Unit>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.ToTable("Units");

        builder.HasIndex(u => u.Code).IsUnique();

        // Seed Data
        builder.HasData(
            new Unit { Id = 1, Code = "AD", Name = "Adet", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 2, Code = "KG", Name = "Kilogram", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 3, Code = "GR", Name = "Gram", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 4, Code = "LT", Name = "Litre", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 5, Code = "MT", Name = "Metre", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 6, Code = "CM", Name = "Santimetre", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 7, Code = "MM", Name = "Milimetre", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 8, Code = "PK", Name = "Paket", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 9, Code = "KL", Name = "Koli", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 10, Code = "TON", Name = "Ton", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 11, Code = "TK", Name = "Takım", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 12, Code = "CU", Name = "Çuval", IsActive = true, CreatedUserId = 1 }
        );
    }
}
