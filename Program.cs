using ApplicationCore;
using ApplicationCore.Interfaces;
using Infrastructure.Logging;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using BlazorShared;
using SagaMotors_API;
using Infrastructure.Data;
using MinimalApi.Endpoint.Extensions;
using MinimalApi.Endpoint.Configurations.Extensions;
using Infrastructure.Data.Config;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpoints();
//builder.Configuration.AddConfigurationFile("appsettings.test.json");
builder.Logging.AddConsole();

Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<AppIdentityDbContext>()
//    .AddDefaultTokenProviders();

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
builder.Services.Configure<Shop_Settings>(builder.Configuration);
var Shop_Settings = builder.Configuration.Get<Shop_Settings>() ?? new Shop_Settings();
builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

var configSection = builder.Configuration.GetRequiredSection(BaseUrlConfiguration.CONFIG_NAME);
builder.Services.Configure<BaseUrlConfiguration>(configSection);
var baseUrlConfig = configSection.Get<BaseUrlConfiguration>();

builder.Services.AddMemoryCache();


// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Configuration.AddEnvironmentVariables();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Logger.LogInformation("PublicApi App created...");

app.Logger.LogInformation("Seeding Database...");


using(var scope = app.Services.CreateScope())
{
    var scopeProvider = scope.ServiceProvider;
    try
    {
        var shopContext = scopeProvider.GetRequiredService<Shop_Context>();
        await Shop_ContextSeed.SeedAsync(shopContext, app.Logger);

        //var identityContext = scopeProvider.GetRequiredService<AppIdentityDbContext>();
        //await AppIdentityDbContextSeed.SeedAsync(identityContext);
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error ocurred seeding the DB.");
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapEndpoints();

app.Logger.LogInformation("LAUNCHING PublicApi");

app.Run();

public partial class Program { }