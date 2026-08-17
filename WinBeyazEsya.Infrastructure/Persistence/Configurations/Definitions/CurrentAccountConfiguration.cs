using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Definitions;

public class CurrentAccountConfiguration : IEntityTypeConfiguration<CurrentAccount>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<CurrentAccount> builder)
    {
        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
        builder.Property(x => x.SpeCode).HasMaxLength(11);
        builder.Property(x => x.Addr1).HasMaxLength(250);
        builder.Property(x => x.Addr2).HasMaxLength(250);
        builder.Property(x => x.TelNrs1).HasMaxLength(60);
        builder.Property(x => x.TelNrs2).HasMaxLength(60);
        builder.Property(x => x.TaxNr).HasMaxLength(16);
        builder.Property(x => x.TaxOffice).HasMaxLength(50);
        builder.Property(x => x.InCharge).HasMaxLength(50);
        builder.Property(x => x.EmailAddr).HasMaxLength(250);
        builder.Property(x => x.WebAddr).HasMaxLength(150);
        builder.Property(x => x.CellPhone).HasMaxLength(60);
        builder.Property(x => x.ShortCode).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.MailboxAlias).HasMaxLength(255);

        builder.HasOne(x => x.Country).WithMany().HasForeignKey(x => x.CountryId);
        builder.HasOne(x => x.City).WithMany().HasForeignKey(x => x.CityId);
        builder.HasOne(x => x.Town).WithMany().HasForeignKey(x => x.TownId);
    }
}
