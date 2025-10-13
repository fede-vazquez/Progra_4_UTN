﻿using Auth.Config;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Auth.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> GetOneAsync(Expression<Func<T, bool>>? filter = null);
        Task CreateOneAsync(T entity);
        Task UpdateOneAsync(T entity);
        Task DeleteOneAsync(T entity);
        Task SaveAsync();
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet { get; set; } = null!;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        async public Task CreateOneAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }

        async public Task DeleteOneAsync(T entity)
        {
            dbSet.Remove(entity);
            await SaveAsync();
        }

        async public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null) {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        async public Task<T> GetOneAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        async public Task UpdateOneAsync(T entity)
        {
            dbSet.Update(entity);
            await SaveAsync();
        }

        async public Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
