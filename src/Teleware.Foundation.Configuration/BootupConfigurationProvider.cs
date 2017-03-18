using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Teleware.Foundation.Hosting;

namespace Teleware.Foundation.Configuration
{
    public class BootupConfigurationProvider : IBootupConfigurationProvider
    {
        private readonly IConfigurationRoot _bootupConfiguration;

        public BootupConfigurationProvider(IEnvironment env)
        {
            var bootupConfigurationBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("bootup.json", false, false)
                .AddJsonFile($"bootup.{env.EnvironmentName}.json", true, false);
            _bootupConfiguration = bootupConfigurationBuilder.Build();
        }

        public IConfigurationRoot GetBootupConfiguration()
        {
            return _bootupConfiguration;
        }
    }
}