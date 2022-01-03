using Ally;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Shared.Interfaces;
using Shared.Services;

namespace api
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(s =>
                {
                    s.AddSingleton<IBrokerageService, AllyBrokerageService>();
                    s.AddSingleton<IOptionTrader, OptionTrader>();
                })
                .Build();

            host.Run();
        }
    }
}