using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ByteStreamProcessorLib.Data;
using ByteStreamProcessorLib.Data.Repositories;
using ByteStreamProcessorLib.Data.Repositories.Interfaces;
using ByteStreamProcessorLib.Services;
using ByteStreamProcessorLib.Services.Interfaces;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<UserContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IUserService, UserService>();
    })
    .Build();

await host.RunAsync();
