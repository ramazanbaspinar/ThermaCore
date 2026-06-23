using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.System;

namespace ThermaCore.Infrastructure.Persistence;

public class ThermaCoreTenantContext : DbContext
{
    public ThermaCoreTenantContext(DbContextOptions<ThermaCoreTenantContext> options) : base(options)
    {
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Sadece Tenant'a ait konfigürasyonları yükle
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly(),
            t => t.GetInterfaces().Any(i => i == typeof(ThermaCore.Infrastructure.Persistence.Configurations.ITenantEntityConfiguration))
        );

        // Ghost tablolari engellemek icin (Tenant db'de Master tabloları olmaz)
        modelBuilder.Ignore<ThermaCore.Domain.Entities.Management.User>();
        modelBuilder.Ignore<ThermaCore.Domain.Entities.Management.UserRole>();
        modelBuilder.Ignore<ThermaCore.Domain.Entities.Security.Role>();
        modelBuilder.Ignore<ThermaCore.Domain.Entities.Management.Terminal>();
        modelBuilder.Ignore<ThermaCore.Domain.Entities.Management.TenantDatabase>();
        modelBuilder.Ignore<ThermaCore.Domain.Entities.Management.ModulePermission>();
        modelBuilder.Ignore<ThermaCore.Domain.Entities.Management.UserPermission>();
        modelBuilder.Ignore<ThermaCore.Domain.Entities.Security.RolePermission>();
        modelBuilder.Ignore<ThermaCore.Domain.Entities.System.UserSession>();
        modelBuilder.Ignore<ThermaCore.Domain.Entities.Management.Branch>();
        modelBuilder.Ignore<ThermaCore.Domain.Entities.Management.UserBranch>();
        modelBuilder.Ignore<ThermaCore.Domain.Entities.Management.UserTenant>();
        modelBuilder.Ignore<ThermaCore.Domain.Entities.Management.CodeTemplate>();
        modelBuilder.Ignore<UserInterfaceTemplate>();
        modelBuilder.Ignore<ThermaCore.Domain.Entities.Management.CodeLog>();

        // Global Query Filter: FullAuditableEntity'den türeyenlere otomatik IsDeleted = false filtresi ekler
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {

            if (typeof(FullAuditableEntity).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = global::System.Linq.Expressions.Expression.Parameter(entityType.ClrType, "e");
                var property = global::System.Linq.Expressions.Expression.Property(parameter, nameof(FullAuditableEntity.IsDeleted));
                var falseConstant = global::System.Linq.Expressions.Expression.Constant(false);
                var body = global::System.Linq.Expressions.Expression.Equal(property, falseConstant);
                var lambda = global::System.Linq.Expressions.Expression.Lambda(body, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }

            // Index Optimizasyonları (Performans artışı için)
            if (typeof(AuditableEntity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType).HasIndex(nameof(AuditableEntity.CreatedDate));
            }
            if (typeof(FullAuditableEntity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType).HasIndex(nameof(FullAuditableEntity.IsDeleted));
            }

            var isActiveProp = entityType.ClrType.GetProperty("IsActive");
            if (isActiveProp != null)
            {
                modelBuilder.Entity(entityType.ClrType).HasIndex("IsActive");
            }

            var codeProp = entityType.ClrType.GetProperty("Code");
            if (codeProp != null)
            {
                modelBuilder.Entity(entityType.ClrType).HasIndex("Code");
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
            // AuditableEntity kuralları
            if (entry.Entity is AuditableEntity auditableEntity)
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
                    
                    entry.Property(nameof(AuditableEntity.CreatedDate)).IsModified = false;
                    entry.Property(nameof(AuditableEntity.CreatedUserId)).IsModified = false;
                }
            }

            // FullAuditableEntity kuralları (Fiziksel silmeyi engelleme)
            if (entry.Entity is FullAuditableEntity softDeleteEntity && entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                softDeleteEntity.IsDeleted = true;
                softDeleteEntity.DeletedDate = DateTime.Now;
                softDeleteEntity.DeletedUserId = 1; 
            }
        }
    }
}
