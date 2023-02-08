using Microsoft.EntityFrameworkCore;
using PostDemoApi.Models;

namespace PostDemoApi.DAL {
    public class DatabaseContext : DbContext {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) {
        }

        public DbSet<Package> Packages { get; set; }
        public DbSet<Client> Clients { get; set; }


    }
} 

