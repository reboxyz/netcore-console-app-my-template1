// Notes!   https://mehdihadeli.com/console-dependency-injection/

using ConsoleAppTemplateExample;
using ConsoleAppTemplateExample.Interfaces;
using ConsoleAppTemplateExample.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Main: starting");
IHost host = null;
try
{

    HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

    builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddUserSecrets<Program>();

    // Dependency Injection Setup
    builder.Services.AddTransient<IExampleTransientService, ExampleTransientService>();
    builder.Services.AddTransient<IMySampleInterface, MySampleImplementation>();
    builder.Services.AddScoped<TestDI>();

    var configuration = builder.Configuration;

    //using IHost host = builder.Build();
    host = builder.Build();

    /* Note! This is the setup if DI is not needed
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddUserSecrets<Program>()
        ;

    IConfiguration configuration = builder.Build();
    */

    // Sample read Configuration
    Console.WriteLine(configuration.GetValue<int>("StarterCountValue"));
    Console.WriteLine(configuration.GetValue<string>("User:FirstName"));
    Console.WriteLine(configuration.GetValue<string>("User:LastName"));
    Console.WriteLine($"My Secret Value: {configuration.GetValue<string>("MySecretValue")} ");

    // Create a new scope for DI #1
    using (var scope = host.Services.CreateScope())
    {
        // Resolve TestDI
        var testDI = scope.ServiceProvider.GetService<TestDI>();

        // Execute DI method
        testDI?.Run();
    }

    // Create a new scope for DI #2
    using (var scope = host.Services.CreateScope())
    {
        // Resolve IMySampleInterface
        var mySampleInterface = scope.ServiceProvider.GetService<IMySampleInterface>();

        // Execute DI method
        await mySampleInterface.Execute();
    }

    //await host.RunAsync();
    await host.StopAsync();
}
finally
{
    Console.WriteLine("Main: stopping");
    //Console.ReadLine();

    if (host is IAsyncDisposable d) await d.DisposeAsync();
}

