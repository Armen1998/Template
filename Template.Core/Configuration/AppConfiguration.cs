using Microsoft.Extensions.Configuration;

namespace Template.Core.Configuration
{
    public class AppConfiguration
    {
        public static IConfigurationRoot Get(string path, string environmentName = null)
        {
            return BuildConfiguration(path, environmentName);
        }

        private static IConfigurationRoot BuildConfiguration(string path, string environmentName = null)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(path)
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if (!string.IsNullOrWhiteSpace(environmentName))
            {
                builder = builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            }

            builder = builder.AddEnvironmentVariables();
            
            return builder.Build();
        }
    }
}
