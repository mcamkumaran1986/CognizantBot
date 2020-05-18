using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Cognizant.BotStore.Shared
{
    public static class BuildJsonConfiguration
    {
        public static ConfigurationBuilder AddConfigurationBuilder(IConfiguration configuration)
        {
            IConfiguration Configuration;
            var builder = new ConfigurationBuilder();
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var appsettingFilePath = (environment == "Development") ? Path.Combine(AppContext.BaseDirectory, string.Format("..{0}..{0}..{0}", Path.DirectorySeparatorChar), $"appsettings.json") : $"appsettings.json";
            if (environment == "Development")
            {
                builder.AddJsonFile(appsettingFilePath, optional: true);
            }
            else
            {
                builder.AddJsonFile($"appsettings.json", optional: false);
            }
            Configuration = builder.Build();

            return builder;
        }
    }
}
