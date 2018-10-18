using AzureFunc.DependencyInjection;
using AzureFunc.DependencyInjection.Config;
using ExampleFunction;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

[assembly: WebJobsStartup(typeof(Startup))]
namespace ExampleFunction
{
    internal class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder) =>
            builder.AddDependencyInjection<ServiceProviderBuilder>();
    }

    internal class ServiceProviderBuilder : IServiceProviderBuilder
    {
        private readonly ILoggerFactory _loggerFactory;

        public ServiceProviderBuilder(ILoggerFactory loggerFactory) =>
            _loggerFactory = loggerFactory;

        public IServiceProvider Build()
        {
            var services = new ServiceCollection();

            services.AddHttpClient("OpenWeatherAPI", client =>
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org/");
            });
            // Important: We need to call CreateFunctionUserCategory, otherwise our log entries might be filtered out.
            services.AddSingleton<ILogger>(_ => _loggerFactory.CreateLogger(LogCategories.CreateFunctionUserCategory("Common")));

            return services.BuildServiceProvider();
        }
    }
}
//https://stackoverflow.com/questions/45912224/di-in-azure-functions
//https://medium.com/@yuka1984/azure-functions-dependency-injection-with-injection-config-87fe5762c895