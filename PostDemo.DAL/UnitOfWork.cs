using Microsoft.Extensions.Logging;
using PostDemo.Contracts;
using PostDemo.DAL.Repositories;
using Serilog.Core;
using Serilog;

namespace PostDemo.DAL {
    public class UnitOfWork : IUnitOfWork, IDisposable {

        private readonly DatabaseContext _context;
        public IPackageRepository Packages { get; }

        public IClientRepository Clients { get; }

        public UnitOfWork(DatabaseContext context) {
            _context = context;

            Packages = new PackageRepository(context);

            Clients = new ClientRepository(context);

        }


        public async Task CompleteAsync() {
            await _context.SaveChangesAsync();
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}
