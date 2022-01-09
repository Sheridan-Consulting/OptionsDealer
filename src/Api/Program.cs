
using System.Configuration;
using System.IO;
using Ally;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Shared.Interfaces;
using Shared.Models.Configuration;
using Shared.Services;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;

namespace api
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                //.ConfigureFunctionsWorkerDefaults(worker => worker.UseNewtonsoftJson())
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureAppConfiguration(c =>
                {
                    c.SetBasePath(Directory.GetCurrentDirectory());
                   
                    c.AddJsonFile("appsettings.json", optional: true);
                    c.AddJsonFile("local.settings.json", optional: true);
                })
                .ConfigureServices((hostContext,s) =>
                {
                    s.AddSingleton<IBrokerageService, AllyBrokerageService>();
                    s.AddSingleton<IOptionTrader, OptionTrader>();
                    s.AddOptions();
                    s.Configure<AppSettingsConfiguration>(hostContext.Configuration.GetSection("AppSettingsConfiguration"));

                })
                .ConfigureOpenApi()
                
                .Build();

            host.Run();
        }
    }
}