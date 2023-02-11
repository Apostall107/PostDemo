using Microsoft.EntityFrameworkCore;
using PostDemoApi.Contracts;
using PostDemoApi.DAL.Repositories;

namespace PostDemoApi.DAL {
    public class UnitOfWork : IUnitOfWork, IDisposable {

        private readonly DatabaseContext _context;
        private readonly ILogger _logger;
        public IPackageRepository Packages { get; }

        public UnitOfWork(DatabaseContext context, ILogger logger) {
            _context = context;
            _logger = logger;

            Packages = new PackageRepository(context, logger);
        }


        public async Task CompleteAsync() {
            await _context.SaveChangesAsync();
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}
