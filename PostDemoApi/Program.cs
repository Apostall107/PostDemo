using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PostDemo.Contracts;
using PostDemo.DAL;
using PostDemo.DAL.Models.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Mapper Configuration
var mapperCfg = new MapperConfiguration(cfg => {
    cfg.AddProfile<ClientProfile>();
    cfg.AddProfile<PackageProfile>();
});
IMapper mapper = mapperCfg.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
