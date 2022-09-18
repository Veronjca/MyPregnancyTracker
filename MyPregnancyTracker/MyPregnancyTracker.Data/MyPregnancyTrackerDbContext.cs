using Microsoft.EntityFrameworkCore;
using MyPregnancyTracker.Data.Models;

namespace MyPregnancyTracker.Data
{
    public class MyPregnancyTrackerDbContext : DbContext
    {
        public MyPregnancyTrackerDbContext(DbContextOptions<MyPregnancyTrackerDbContext> options)
            : base(options)
        {
        }

        public override int SaveChanges()
        {
            return this.SaveChanges(true);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return this.SaveChangesAsync(true, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Comment>()
                 .HasOne(c => c.User)
                 .WithMany(u => u.Comments)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                 .HasOne(c => c.Topic)
                 .WithMany(u => u.Comments)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                 .HasMany(c => c.Reactions)
                 .WithOne(u => u.Comment)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Reaction>()
                 .HasOne(r => r.User)
                 .WithMany(u => u.Reactions)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Topic>()
                 .HasOne(t => t.User)
                 .WithMany(t => t.Topics)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Topic>()
                 .HasOne(t => t.User)
                 .WithMany(u => u.Topics)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Article>()
                .HasKey(a => a.Id);

            builder.Entity<GestationalWeek>()
                .HasKey(gw => gw.Id);
        }
        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is User &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (User)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}