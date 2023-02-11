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

        public Task<bool> Add(T entity) {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(T entity) {
            throw new NotImplementedException();
        }

        public Task<T> Get(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll() {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity) {
            throw new NotImplementedException();
        }
    }
}
