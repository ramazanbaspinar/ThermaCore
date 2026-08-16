using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.Definitions;

public class CurrentAccountConfiguration : IEntityTypeConfiguration<CurrentAccount>, ITenantEntityConfiguration
{
    public void Configure(EntityTypeBuilder<CurrentAccount> builder)
    {
        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(150);
        builder.Property(x => x.SpeCode).HasMaxLength(11);
        builder.Property(x => x.CyphCode).HasMaxLength(11);
        builder.Property(x => x.Addr1).HasMaxLength(51);
        builder.Property(x => x.Addr2).HasMaxLength(51);
        builder.Property(x => x.City).HasMaxLength(21);
        builder.Property(x => x.Country).HasMaxLength(21);
        builder.Property(x => x.PostCode).HasMaxLength(11);
        builder.Property(x => x.TelNrs1).HasMaxLength(16);
        builder.Property(x => x.TelNrs2).HasMaxLength(16);
        builder.Property(x => x.FaxNr).HasMaxLength(16);
        builder.Property(x => x.TaxNr).HasMaxLength(16);
        builder.Property(x => x.TaxOffice).HasMaxLength(50);
        builder.Property(x => x.InCharge).HasMaxLength(21);
        builder.Property(x => x.EmailAddr).HasMaxLength(31);
        builder.Property(x => x.WebAddr).HasMaxLength(41);
        builder.Property(x => x.VatNr).HasMaxLength(33);
        builder.Property(x => x.BankBranchs1).HasMaxLength(17);
        builder.Property(x => x.BankBranchs2).HasMaxLength(17);
        builder.Property(x => x.BankBranchs3).HasMaxLength(17);
        builder.Property(x => x.BankBranchs4).HasMaxLength(17);
        builder.Property(x => x.BankBranchs5).HasMaxLength(17);
        builder.Property(x => x.BankBranchs6).HasMaxLength(17);
        builder.Property(x => x.BankBranchs7).HasMaxLength(17);
        builder.Property(x => x.BankAccounts1).HasMaxLength(17);
        builder.Property(x => x.BankAccounts2).HasMaxLength(17);
        builder.Property(x => x.BankAccounts3).HasMaxLength(17);
        builder.Property(x => x.BankAccounts4).HasMaxLength(17);
        builder.Property(x => x.BankAccounts5).HasMaxLength(17);
        builder.Property(x => x.BankAccounts6).HasMaxLength(17);
        builder.Property(x => x.BankAccounts7).HasMaxLength(17);
        builder.Property(x => x.DeliveryMethod).HasMaxLength(13);
        builder.Property(x => x.DeliveryFirm).HasMaxLength(13);
        builder.Property(x => x.TaxOffCode).HasMaxLength(17);
        builder.Property(x => x.TownCode).HasMaxLength(13);
        builder.Property(x => x.TownName).HasMaxLength(51);
        builder.Property(x => x.DistrictCode).HasMaxLength(13);
        builder.Property(x => x.District).HasMaxLength(51);
        builder.Property(x => x.CityCode).HasMaxLength(13);
        builder.Property(x => x.CountryCode).HasMaxLength(13);
        builder.Property(x => x.CellPhone).HasMaxLength(18);
        builder.Property(x => x.ShortCode).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.MailboxAlias).HasMaxLength(255);
    }
}
