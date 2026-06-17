using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Entities.System;

namespace ThermaCore.Infrastructure.Persistence;

public class ThermaCoreMasterContext : DbContext
{
    public ThermaCoreMasterContext(DbContextOptions<ThermaCoreMasterContext> options) : base(options)
    {
    }

    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ModulePermission> ModulePermissions { get; set; }
    public DbSet<UserPermission> UserPermissions { get; set; }
    public DbSet<Terminal> Terminals { get; set; }
    public DbSet<UserSession> UserSessions { get; set; }
    public DbSet<TenantDatabase> TenantDatabases { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

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
