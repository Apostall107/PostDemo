using Microsoft.Extensions.Logging;
using PostDemo.Contracts;
using PostDemo.DAL.Models.Entities;
using Serilog.Core;

namespace PostDemo.DAL.Repositories {
    internal class ClientRepository : GenericRepository<Client>, IClientRepository {
        public ClientRepository(DatabaseContext context, Logger logger)
            : base(context, logger) {
        }

    }
}