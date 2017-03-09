using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileSystemGlobbing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Teleware.Foundation.Hosting;

namespace Teleware.Foundation.Configuration
{
    public class ConfigurationFactory : IConfigurationFactory
    {
        private readonly BootupConfigurationProvider _bootupProvider;
        private readonly IEnvironment _env;
        private readonly ConfigFactoryOptions _configOptions;
        private readonly string _configRootFullPath;
        private IConfigurationRoot _configuration;

        public ConfigurationFactory(BootupConfigurationProvider bootupProvider, IEnvironment env)
        {
            _bootupProvider = bootupProvider;
            _env = env;
            _configOptions = new ConfigFactoryOptions();
            ConfigurationBinder.Bind(bootupProvider.GetBootupConfiguration().GetSection("Configuration"), _configOptions);
            _configRootFullPath = System.IO.Path.Combine(env.ContentRootPath, _configOptions.ConfigurationRootPath);
        }

        public IConfigurationRoot GetConfigurationRoot()
        {
            if (_configuration == null)
            {
                if (!Directory.Exists(_configRootFullPath))
                {
                    Directory.CreateDirectory(_configRootFullPath);
                }
                var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(_configRootFullPath);

                foreach (var jsonConfig in _configOptions.Json)
                {
                    var jsonFileMatcher = new Microsoft.Extensions.FileSystemGlobbing.Matcher();
                    var jsonFiles = jsonFileMatcher
                        .AddInclude(jsonConfig.Include)
                        .AddExclude(jsonConfig.Exclude)
                        .GetResultsInFullPath(_configRootFullPath);

                    foreach (var jsonFile in jsonFiles)
                    {
                        configurationBuilder.AddJsonFile(jsonFile, jsonConfig.Optional, jsonConfig.ReloadOnChange);
                    }
                }

                _configuration = configurationBuilder.Build();
            }

            return _configuration;
        }

        private class ConfigFactoryOptions
        {
            public string ConfigurationRootPath { get; set; }
            public JsonConfigFactoryOptions[] Json { get; set; }
        }

        private class JsonConfigFactoryOptions
        {
            public string Include { get; set; }
            public string Exclude { get; set; }
            public bool Optional { get; set; }
            public bool ReloadOnChange { get; set; }
        }
    }
}