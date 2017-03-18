using Microsoft.Extensions.Configuration;
using System.IO;

namespace Teleware.Foundation.Configuration
{
    public interface IBootupConfigurationProvider
    {
        IConfigurationRoot GetBootupConfiguration();
    }

    public static class BootupConfigurationProviderExtensions
    {
        public static IConfiguration GetAutofacConfiguration(this IBootupConfigurationProvider provider)
        {
            return provider.GetBootupConfiguration().GetSection("Autofac");
        }

        public static string GetNLogConfigFilePath(this IBootupConfigurationProvider provider)
        {
            var configurationSection = provider.GetBootupConfiguration().GetSection("Configuration");
            var configurationRootPath = configurationSection.GetSection("ConfigurationRootPath").Value;
            var configurationFileName = configurationSection.GetSection("NLog").Value;
            if (configurationFileName == null)
            {
                return null;
            }
            else
            {
                return Path.Combine(configurationRootPath, configurationFileName);
            }
        }
    }
}