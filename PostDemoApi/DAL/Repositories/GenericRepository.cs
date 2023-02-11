using Microsoft.EntityFrameworkCore;
using PostDemoApi.Contracts;

namespace PostDemoApi.DAL.Repositories {
    public class GenericRepository<T> : IGenericRepository<T> where T : class {

        protected DatabaseContext _context;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(DatabaseContext context, DbSet<T> dbSet, ILogger logger) {
            _context = context;
            _logger = logger;
            this._dbSet = _context.Set<T>();
        }

        public async Task<bool> Add(T entity) {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(T entity) {
            _dbSet.Remove(entity);
            return true;
        }

        public async Task<T?> GetById(int id) {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll() {
            return  await _dbSet.ToListAsync();
        }

        public async Task<bool> Update(T entity) {
            _dbSet.Update(entity);
            return true;
        }
    }
}
