using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using PostDemo.Api.Filters;
using PostDemo.Api.Middleware;
using PostDemo.BL;
using PostDemo.BL.Helpers;
using PostDemo.Contracts;
using PostDemo.DAL;
using PostDemo.DAL.Models.Profiles;
using Serilog;

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

Log.Logger = new LoggerConfiguration()
                        .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                        .CreateLogger();


builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<EmailService>();
builder.Services.AddSingleton<SMTPConfig>();



WebApplication app = null;
try {
    app = builder.Build();
} catch (Exception e) {
    Log.Fatal(e.ToString());
	throw;
}




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.ConfigureGlobalExceptionHandling(Log.Logger);

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<RequestHeadersLoggingMiddleware>();


app.Run();
