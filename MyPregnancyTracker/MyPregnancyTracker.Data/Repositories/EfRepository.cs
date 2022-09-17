using Microsoft.EntityFrameworkCore;

namespace MyPregnancyTracker.Data.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public EfRepository(MyPregnancyTrackerDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<TEntity>();
        }

        protected MyPregnancyTrackerDbContext Context { get; set; }

        protected DbSet<TEntity> DbSet { get; set; }

        public virtual Task AddAsync(TEntity entity) => this.DbSet.AddAsync(entity).AsTask();

        public virtual void Delete(TEntity entity) => this.DbSet.Remove(entity);

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual IQueryable<TEntity> GetAll() => this.DbSet;

        public Task<int> SaveChangesAsync() => this.Context.SaveChangesAsync();

        public virtual void Update(TEntity entity)
        {
            var entry = this.Context.Entry(entity);

            if(entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }
    }
}
