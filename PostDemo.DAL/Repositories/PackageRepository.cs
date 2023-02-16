using PostDemo.DAL.Models.Entities;
using PostDemoApi.Contracts;

namespace PostDemoApi.DAL.Repositories {
    public class PackageRepository : GenericRepository<Package>, IPackageRepository {
        public PackageRepository(DatabaseContext context, ILogger logger) : base(context, logger) {
        }

        public override async Task<IEnumerable<Package>> GetAll() {

            try {
                return await _context.Packages.Where(x => x.Id < 100).ToListAsync();
            } catch (Exception e) {
                Console.Write(e);
                throw;
            }

        }
        public override async Task<Package?> GetById(int id) {

            try {
                return await _context.Packages.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
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
