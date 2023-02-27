using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PostDemo.Contracts;
using Serilog.Core;

namespace PostDemo.DAL.Repositories {
    public class GenericRepository<T> : IGenericRepository<T> where T : class {

        protected DatabaseContext _context;
        internal DbSet<T> _dbSet;
        protected readonly Logger _logger;

        public GenericRepository(DatabaseContext context, Logger logger) {
            _context = context;
            _logger = logger;
            this._dbSet = _context.Set<T>();
        }

        public virtual async Task<bool> Add(T entity) {
            try {
                await _dbSet.AddAsync(entity);
                return true;
            } catch (Exception e) {
                _logger.Error(e.ToString());
                Console.Write(e);
                throw;
            }
        }

        public virtual async Task<bool> Delete(T entity) {
            try {
                _dbSet.Remove(entity);
                return true;
            } catch (Exception e) {
                _logger.Error(e.ToString());
                Console.Write(e);
                throw;
            }
        }

        public virtual async Task<T?> GetById(int id) {
            try {
                return await _dbSet.FindAsync(id);
            } catch (Exception e) {
                _logger.Error(e.ToString());
                Console.Write(e);
                throw;
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll() {
            try {
                return await _dbSet.AsNoTracking().ToListAsync();
            } catch (Exception e) {
                _logger.Error(e.ToString());
                Console.Write(e);
                throw;
            }
        }

        public virtual async Task<bool> Update(T entity) {
            try {
                _dbSet.Update(entity);
            } catch (Exception e) {
                _logger.Error(e.ToString());
                Console.Write(e);
                throw;
            }
            return true;
        }
    }
}
