using INNOEcoSystem.Api.Extensions;
using INNOEcoSystem.Data.DbContexts;
using INNOEcoSystem.Models.Middlewares;
using INNOEcoSystem.Service.Commons.Helpers;
using INNOEcoSystem.Service.Mappers;
using INNOEcoSystem.Shared.Extensions;
using INNOEcoSystem.Shared.Models;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Database configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// swagger set up
builder.Services.AddSwaggerService();
// JWT service
builder.Services.AddJwtService(builder.Configuration);


// Logger
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// CORS
builder.Services.ConfigureCors();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admins", policy =>
    {
        policy.RequireRole("Admin", "SuperAdmin");
    });
});

// Configure api url name
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(
                                        new ConfigurationApiUrlName()));
});


builder.Services.AddMemoryCache();
builder.Services.AddCustomServices();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Getting full path of wwwroot
WebHostEnviromentHelper.WebRootPath = Path.GetFullPath("wwwroot");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseStaticFiles();
app.UseMiddleware<ExceptionHandlerMiddleWare>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
