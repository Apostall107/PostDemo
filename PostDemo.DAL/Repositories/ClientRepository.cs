using PostDemo.DAL.Models.Entities;
using PostDemoApi.Contracts;

namespace PostDemoApi.DAL.Repositories {
    internal class ClientRepository : GenericRepository<Client>, IClientRepository {
        public ClientRepository(DatabaseContext context, ILogger logger)
            : base(context, logger) {
        }

    }
}