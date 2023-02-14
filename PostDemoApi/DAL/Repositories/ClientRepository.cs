using PostDemoApi.Contracts;
using PostDemoApi.Models;

namespace PostDemoApi.DAL.Repositories
{
    internal class ClientRepository : GenericRepository<Client>, IClientRepository {
        public ClientRepository(DatabaseContext context, ILogger logger)
            : base(context, logger) {
        }
    
    }
}