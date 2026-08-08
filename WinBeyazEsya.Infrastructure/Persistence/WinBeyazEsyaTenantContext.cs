using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.System;

namespace WinBeyazEsya.Infrastructure.Persistence;

public class WinBeyazEsyaTenantContext : DbContext
{
    private readonly WinBeyazEsya.Application.Interfaces.System.ICurrentTenantService _currentTenantService;

    public WinBeyazEsyaTenantContext(
        DbContextOptions<WinBeyazEsyaTenantContext> options,
        WinBeyazEsya.Application.Interfaces.System.ICurrentTenantService currentTenantService = null) : base(options)
    {
        _currentTenantService = currentTenantService;
    }

    public DbSet<WinBeyazEsya.Domain.Entities.Definitions.Unit> Units { get; set; }
    public DbSet<WinBeyazEsya.Domain.Entities.Definitions.UnitConversion> UnitConversions { get; set; }
    public DbSet<WinBeyazEsya.Domain.Entities.Definitions.MetalSheetGroup> MetalSheetGroups { get; set; }
    public DbSet<WinBeyazEsya.Domain.Entities.Definitions.ElectricalElectronicGroup> ElectricalElectronicGroups { get; set; }
    public DbSet<WinBeyazEsya.Domain.Entities.Definitions.GasAndIgnitionGroup> GasAndIgnitionGroups { get; set; }
    public DbSet<WinBeyazEsya.Domain.Entities.Definitions.PlasticAndVisualPartsGroup> PlasticAndVisualPartsGroups { get; set; }

    public DbSet<WinBeyazEsya.Domain.Entities.Management.ExchangeRate> ExchangeRates { get; set; }
    public DbSet<WinBeyazEsya.Domain.Entities.Management.TaxRate> TaxRates { get; set; }
    public DbSet<WinBeyazEsya.Domain.Entities.Management.SystemParameter> SystemParameters { get; set; }
    public DbSet<WinBeyazEsya.Domain.Entities.Management.MaliyetParametre> MaliyetParametreleri { get; set; }

    public DbSet<WinBeyazEsya.Domain.Entities.Common.ItemBarcode> ItemBarcodes { get; set; }
    public DbSet<WinBeyazEsya.Domain.Entities.Common.AppDocument> AppDocuments { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_currentTenantService != null && !string.IsNullOrEmpty(_currentTenantService.ConnectionString))
        {
            optionsBuilder.UseSqlServer(_currentTenantService.ConnectionString);
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Sadece Tenant'a ait konfigürasyonları yükle
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly(),
            t => t.GetInterfaces().Any(i => i == typeof(WinBeyazEsya.Infrastructure.Persistence.Configurations.ITenantEntityConfiguration))
        );

        // Ghost tablolari engellemek icin (Tenant db'de Master tabloları olmaz)
        modelBuilder.Ignore<WinBeyazEsya.Domain.Entities.Management.User>();
        modelBuilder.Ignore<WinBeyazEsya.Domain.Entities.Security.Role>();
        modelBuilder.Ignore<WinBeyazEsya.Domain.Entities.Management.Terminal>();
        modelBuilder.Ignore<WinBeyazEsya.Domain.Entities.Management.TenantDatabase>();
        modelBuilder.Ignore<WinBeyazEsya.Domain.Entities.Security.RolePermission>();
        modelBuilder.Ignore<WinBeyazEsya.Domain.Entities.System.UserSession>();
        modelBuilder.Ignore<WinBeyazEsya.Domain.Entities.Management.Branch>();
        modelBuilder.Ignore<WinBeyazEsya.Domain.Entities.Management.UserBranch>();
        modelBuilder.Ignore<WinBeyazEsya.Domain.Entities.Management.UserTenant>();
        modelBuilder.Ignore<WinBeyazEsya.Domain.Entities.Management.CodeTemplate>();
        modelBuilder.Ignore<UserInterfaceTemplate>();
        modelBuilder.Ignore<WinBeyazEsya.Domain.Entities.Management.CodeLog>();

        // Global Query Filter: FullAuditableEntity'den türeyenlere otomatik IsDeleted = false filtresi ekler
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
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
            
            var method = typeof(WinBeyazEsyaTenantContext).GetMethod(nameof(SetGlobalQueryFilters), BindingFlags.NonPublic | BindingFlags.Instance);
            method?.MakeGenericMethod(entityType.ClrType).Invoke(this, new object[] { modelBuilder });
        }
    }

    private void SetGlobalQueryFilters<TEntity>(ModelBuilder modelBuilder) where TEntity : class
    {
        bool hasSoftDelete = typeof(FullAuditableEntity).IsAssignableFrom(typeof(TEntity));
        bool hasBranch = typeof(IMustHaveBranch).IsAssignableFrom(typeof(TEntity));

        if (hasSoftDelete && hasBranch)
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(e => EF.Property<bool>(e, "IsDeleted") == false && EF.Property<long>(e, "BranchId") == (_currentTenantService != null ? _currentTenantService.BranchId : 0));
        }
        else if (hasSoftDelete)
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(e => EF.Property<bool>(e, "IsDeleted") == false);
        }
        else if (hasBranch)
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(e => EF.Property<long>(e, "BranchId") == (_currentTenantService != null ? _currentTenantService.BranchId : 0));
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
            
            if (entry.Entity is IMustHaveBranch mustHaveBranch)
            {
                if (entry.State == EntityState.Added && mustHaveBranch.BranchId == 0)
                {
                    mustHaveBranch.BranchId = _currentTenantService?.BranchId ?? 0;
                }
            }

            // FullAuditableEntity kuralları (Fiziksel silmeyi engelleme)
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

