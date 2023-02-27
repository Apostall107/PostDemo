﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PostDemo.Contracts;

namespace PostDemo.DAL.Repositories {
    public class GenericRepository<T> : IGenericRepository<T> where T : class {

        protected DatabaseContext _context;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(DatabaseContext context, ILogger logger) {
            _context = context;
            _logger = logger;
            this._dbSet = _context.Set<T>();
        }

        public virtual async Task<bool> Add(T entity) {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete(T entity) {
            _dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<T?> GetById(int id) {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAll() {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<bool> Update(T entity) {
            _dbSet.Update(entity);
            return true;
        }
    }
}
