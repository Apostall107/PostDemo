using Microsoft.EntityFrameworkCore;
using PostDemoApi.Contracts;
using PostDemoApi.DAL.Repositories;
using PostDemoApi.DAL;

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


public static class ClientEndpoints
{
	public static void MapClientEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Client", async (DatabaseContext db) =>
        {
            return await db.Clients.ToListAsync();
        })
        .WithName("GetAllClients");

        routes.MapGet("/api/Client/{id}", async (int Id, DatabaseContext db) =>
        {
            return await db.Clients.FindAsync(Id)
                is Client model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetClientById");

        routes.MapPut("/api/Client/{id}", async (int Id, Client client, DatabaseContext db) =>
        {
            var foundModel = await db.Clients.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            
            db.Update(client);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })   
        .WithName("UpdateClient");

        routes.MapPost("/api/Client/", async (Client client, DatabaseContext db) =>
        {
            db.Clients.Add(client);
            await db.SaveChangesAsync();
            return Results.Created($"/Clients/{client.Id}", client);
        })
        .WithName("CreateClient");


        routes.MapDelete("/api/Client/{id}", async (int Id, DatabaseContext db) =>
        {
            if (await db.Clients.FindAsync(Id) is Client client)
            {
                db.Clients.Remove(client);
                await db.SaveChangesAsync();
                return Results.Ok(client);
            }

            return Results.NotFound();
        })
        .WithName("DeleteClient");
    }
}}
