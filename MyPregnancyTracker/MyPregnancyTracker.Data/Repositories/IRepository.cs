﻿namespace MyPregnancyTracker.Data.Repositories
{
    public interface IRepository<TEntity> : IDisposable 
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}
