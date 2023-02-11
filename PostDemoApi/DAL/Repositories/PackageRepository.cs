using Microsoft.EntityFrameworkCore;
using PostDemoApi.Contracts;
using PostDemoApi.Models;

namespace PostDemoApi.DAL.Repositories {
    public class PackageRepository : GenericRepository<Package>, IPackageRepository {
        public PackageRepository(DatabaseContext context, DbSet<Package> dbSet, ILogger logger) : base(context, logger) {
        }

        public override async Task<IEnumerable<Package>> GetAll() {

            try {
                return await _context.Packages.Where(x => x.Id < 100).ToListAsync();
            } catch (Exception e) {
                Console.Write(e);
                throw;
            }

        }

        public async Task<List<Package>?> GetPackagesKilosLess(int kilos) {

            try {
                return await _context.Packages.Where(x => x.Kilos < kilos).ToListAsync();
            } catch (Exception e) {
                Console.Write(e);
                throw;
            }
        }
    }
}
