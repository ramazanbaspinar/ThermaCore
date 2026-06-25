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
            new Unit { Id = 10, Code = "TON", Name = "Ton", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 4, Code = "LT", Name = "Litre", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 5, Code = "MT", Name = "Metre", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 6, Code = "CM", Name = "Santimetre", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 7, Code = "MM", Name = "Milimetre", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 13, Code = "KM", Name = "Kilometre", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 14, Code = "M2", Name = "Metrekare", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 15, Code = "CM2", Name = "Santimetrekare", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 16, Code = "M3", Name = "Metreküp", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 17, Code = "MIC", Name = "Mikron", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 18, Code = "GR/M2", Name = "Gram/Metrekare", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 19, Code = "KG/M2", Name = "Kilogram/Metrekare", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 8, Code = "PK", Name = "Paket", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 9, Code = "KL", Name = "Koli", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 20, Code = "KUT", Name = "Kutu", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 11, Code = "TK", Name = "Takım", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 21, Code = "TBK", Name = "Tabaka", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 12, Code = "CU", Name = "Çuval", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 22, Code = "BDN", Name = "Bidon", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 23, Code = "TNK", Name = "Teneke", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 24, Code = "KOV", Name = "Kova", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 25, Code = "DZ", Name = "Düzine", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 26, Code = "DST", Name = "Deste", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 27, Code = "OHM", Name = "Ohm", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 28, Code = "KW", Name = "Kilowatt", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 29, Code = "W", Name = "Watt", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 30, Code = "SN", Name = "Saniye", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 31, Code = "DK", Name = "Dakika", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 32, Code = "SA", Name = "Saat", IsActive = true, CreatedUserId = 1 },
            new Unit { Id = 33, Code = "GUN", Name = "Gün", IsActive = true, CreatedUserId = 1 }
        );
    }
}
