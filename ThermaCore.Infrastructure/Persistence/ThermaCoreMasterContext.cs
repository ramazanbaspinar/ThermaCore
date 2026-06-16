using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThermaCore.Domain.Entities.Base.Interfaces;
using ThermaCore.Domain.Entities.Yonetim;
using ThermaCore.Domain.Entities.System;

namespace ThermaCore.Infrastructure.Persistence;

public class ThermaCoreMasterContext : DbContext
{
    public ThermaCoreMasterContext(DbContextOptions<ThermaCoreMasterContext> options) : base(options)
    {
    }

    public DbSet<KullaniciRolu> KullaniciRolleri { get; set; }
    public DbSet<Kullanici> Kullanicilar { get; set; }
    public DbSet<ModulIslemYetkisi> ModulIslemYetkileri { get; set; }
    public DbSet<KullaniciBazliModulIslemYetkisi> KullaniciBazliModulIslemYetkileri { get; set; }
    public DbSet<Terminal> Terminaller { get; set; }
    public DbSet<KullaniciOturum> KullaniciOturumlari { get; set; }
    public DbSet<SistemVeritabani> SistemVeritabanlari { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Global Query Filter: ISoftDelete interface'ine sahip olanlara otomatik filtre ekler
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = global::System.Linq.Expressions.Expression.Parameter(entityType.ClrType, "e");
                var property = global::System.Linq.Expressions.Expression.Property(parameter, nameof(ISoftDelete.IsDeleted));
                var falseConstant = global::System.Linq.Expressions.Expression.Constant(false);
                var body = global::System.Linq.Expressions.Expression.Equal(property, falseConstant);
                var lambda = global::System.Linq.Expressions.Expression.Lambda(body, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }
    }

    public override int SaveChanges()
    {
        ApplyAuditAndSoftDeleteRules();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditAndSoftDeleteRules();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyAuditAndSoftDeleteRules()
    {
        var entries = ChangeTracker.Entries();

        foreach (var entry in entries)
        {
            if (entry.Entity is IAuditableEntity auditableEntity)
            {
                long currentUserId = 1; 

                if (entry.State == EntityState.Added)
                {
                    auditableEntity.CreatedDate = DateTime.Now;
                    auditableEntity.CreatedUserId = currentUserId;
                }
                else if (entry.State == EntityState.Modified)
                {
                    auditableEntity.ModifiedDate = DateTime.Now;
                    auditableEntity.ModifiedUserId = currentUserId;
                    
                    entry.Property(nameof(IAuditableEntity.CreatedDate)).IsModified = false;
                    entry.Property(nameof(IAuditableEntity.CreatedUserId)).IsModified = false;
                }
            }

            if (entry.Entity is ISoftDelete softDeleteEntity && entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                softDeleteEntity.IsDeleted = true;
                softDeleteEntity.DeletedDate = DateTime.Now;
                softDeleteEntity.DeletedUserId = 1;
            }
        }
    }
}
