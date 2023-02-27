using Microsoft.Extensions.Logging;
using PostDemo.Contracts;
using PostDemo.DAL.Models.Entities;

namespace PostDemo.DAL.Repositories {
    internal class ClientRepository : GenericRepository<Client>, IClientRepository {
        public ClientRepository(DatabaseContext context, ILogger logger)
            : base(context, logger) {
        }

    }
}