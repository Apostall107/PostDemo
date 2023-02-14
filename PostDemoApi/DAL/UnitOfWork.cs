using Microsoft.EntityFrameworkCore;
using PostDemoApi.Contracts;
using PostDemoApi.DAL.Repositories;

namespace PostDemoApi.DAL {
    public class UnitOfWork : IUnitOfWork, IDisposable {

        private readonly DatabaseContext _context;
        public IPackageRepository Packages { get; }

        public IClientRepository Clients { get; }

        public UnitOfWork(DatabaseContext context, ILoggerFactory loggerFactory) {
            _context = context;
            var _logger = loggerFactory.CreateLogger("logs");

            Packages = new PackageRepository(context, _logger);

            Clients = new ClientRepository(context, _logger);


        }


        public async Task CompleteAsync() {
            await _context.SaveChangesAsync();
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}
