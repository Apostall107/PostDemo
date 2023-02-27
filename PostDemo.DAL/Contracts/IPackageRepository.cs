using PostDemo.DAL.Models.Entities;

namespace PostDemo.Contracts {
    public interface IPackageRepository : IGenericRepository<Package> {
        Task<List<Package>?> GetPackagesKilosLess(int kilos);
    }
}
