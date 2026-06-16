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

public class ThermaCoreTenantContext : DbContext
{
    public ThermaCoreTenantContext(DbContextOptions<ThermaCoreTenantContext> options) : base(options)
    {
    }

    public DbSet<KodSablon> KodSablonlari { get; set; }
    public DbSet<KullaniciArayuzSablonu> KullaniciArayuzSablonlari { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuration sÄ±nÄ±flarÄ±nÄ± (IEntityTypeConfiguration<T>) otomatik uygula
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Global Query Filter: ISoftDelete interface'ine sahip olanlara otomatik filtre ekler
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            entityType.SetTableName("TCORE_" + entityType.GetTableName());

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
            // IAuditableEntity kurallarÄ±
            if (entry.Entity is IAuditableEntity auditableEntity)
            {
                long currentUserId = 1; // TODO: Ä°leride IHttpContextAccessor veya aktif oturum nesnesinden alÄ±nacak

                if (entry.State == EntityState.Added)
                {
                    auditableEntity.CreatedDate = DateTime.Now;
                    auditableEntity.CreatedUserId = currentUserId;
                }
                else if (entry.State == EntityState.Modified)
                {
                    auditableEntity.ModifiedDate = DateTime.Now;
                    auditableEntity.ModifiedUserId = currentUserId;
                    
                    // Modified update sÄ±rasÄ±nda Created property'lerinin deÄŸiÅŸmesini engelliyoruz.
                    entry.Property(nameof(IAuditableEntity.CreatedDate)).IsModified = false;
                    entry.Property(nameof(IAuditableEntity.CreatedUserId)).IsModified = false;
                }
            }

            // ISoftDelete kurallarÄ± (Fiziksel silmeyi engelleme)
            if (entry.Entity is ISoftDelete softDeleteEntity && entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                softDeleteEntity.IsDeleted = true;
                softDeleteEntity.DeletedDate = DateTime.Now;
                softDeleteEntity.DeletedUserId = 1; // TODO: Ä°leride IHttpContextAccessor'dan alÄ±nacak
            }
        }
    }
}
