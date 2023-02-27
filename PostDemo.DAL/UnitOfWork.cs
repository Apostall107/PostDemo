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
            var _logger = new LoggerConfiguration()
                                    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                                    .CreateLogger();

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
