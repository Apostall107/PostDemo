using PostDemo.DAL.Models.Entities;
using PostDemo.Contracts;
using Microsoft.Extensions.Logging;

namespace PostDemo.DAL.Repositories {
    internal class ClientRepository : GenericRepository<Client>, IClientRepository {
        public ClientRepository(DatabaseContext context, ILogger logger)
            : base(context, logger) {
        }

    }
}