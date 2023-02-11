using PostDemoApi.Models;

namespace PostDemoApi.Contracts {
    public interface IPackageRepository : IGenericRepository<Package>{
        Task<List<Package>?> GetPackagesKilosLess(int kilos);
    }
}
