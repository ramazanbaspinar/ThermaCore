using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinBeyazEsya.Domain.Entities.System;

namespace WinBeyazEsya.Infrastructure.Persistence.Configurations.System;

public class UserSessionConfiguration : IEntityTypeConfiguration<UserSession>, IMasterEntityConfiguration
{
    public void Configure(EntityTypeBuilder<UserSession> builder)
    {
        builder.ToTable("UserSessions");
    }
}

