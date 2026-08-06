using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Management;
using WinBeyazEsya.Domain.Entities.System;

namespace WinBeyazEsya.Infrastructure.Persistence;

public class WinBeyazEsyaMasterContext : DbContext
{
    private readonly WinBeyazEsya.Application.Interfaces.System.ICurrentTenantService _currentTenantService;

    public WinBeyazEsyaMasterContext(
        DbContextOptions<WinBeyazEsyaMasterContext> options,
        WinBeyazEsya.Application.Interfaces.System.ICurrentTenantService currentTenantService = null) : base(options)
    {
        _currentTenantService = currentTenantService;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Terminal> Terminals { get; set; }
    public DbSet<UserFavorite> UserFavorites { get; set; }
    public DbSet<UserSession> UserSessions { get; set; }
    public DbSet<SystemLicense> SystemLicenses { get; set; }
    public DbSet<EmailParameter> EmailParameters { get; set; }
    public DbSet<TenantDatabase> TenantDatabases { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<UserTenant> UserTenants { get; set; }
    public DbSet<UserBranch> UserBranches { get; set; }
    public DbSet<WinBeyazEsya.Domain.Entities.Security.Role> Roles { get; set; }
    public DbSet<WinBeyazEsya.Domain.Entities.Security.RolePermission> RolePermissions { get; set; }
    public DbSet<WinBeyazEsya.Domain.Entities.Security.UserPermission> UserPermissions { get; set; }
    public DbSet<CodeTemplate> CodeTemplates { get; set; }
    public DbSet<UserInterfaceTemplate> UserInterfaceTemplates { get; set; }
    public DbSet<CodeLog> CodeLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Sadece Master'a ait konfigürasyonları yükle
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly(),
            t => t.GetInterfaces().Any(i => i == typeof(WinBeyazEsya.Infrastructure.Persistence.Configurations.IMasterEntityConfiguration))
        );

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
                var indexBuilder = modelBuilder.Entity(entityType.ClrType).HasIndex("Code").IsUnique();
                if (typeof(FullAuditableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    indexBuilder.HasFilter("[IsDeleted] = 0");
                }
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
                long currentUserId = _currentTenantService != null && _currentTenantService.UserId > 0 ? _currentTenantService.UserId : 1; 

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
                long currentUserId = _currentTenantService != null && _currentTenantService.UserId > 0 ? _currentTenantService.UserId : 1; 

                entry.State = EntityState.Modified;
                softDeleteEntity.IsDeleted = true;
                softDeleteEntity.DeletedDate = DateTime.Now;
                softDeleteEntity.DeletedUserId = currentUserId;
            }
        }
    }
}

