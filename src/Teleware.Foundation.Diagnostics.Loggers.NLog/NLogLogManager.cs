using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleware.Foundation.Configuration;

using NLogSelf = NLog;

namespace Teleware.Foundation.Diagnostics.Loggers.NLog
{
    internal class NLogLogManager
    {
        private static bool _initialized = false;

        public NLogLogManager(IBootupConfigurationProvider bootupConfigurationProvider)
        {
            if (_initialized == false)
            {
                lock (typeof(NLogLogManager))
                {
                    if (_initialized != false)
                    {
                        return;
                    }
                    var configurationSection = bootupConfigurationProvider.GetBootupConfiguration().GetSection("Configuration");
                    var configurationRootPath = configurationSection.GetSection("ConfigurationRootPath").Value;
                    var configurationFileName = configurationSection.GetSection("NLog").Value;
                    if (configurationFileName != null)
                    {
                        var configurationFilePath = System.IO.Path.Combine(configurationRootPath, configurationFileName);
                        if (System.IO.File.Exists(configurationFilePath))
                        {
                            var config = new NLogSelf.Config.XmlLoggingConfiguration(configurationFilePath, false);
                            NLogSelf.LogManager.Configuration = config;
                        }
                    }
                    _initialized = true;
                }
            }
        }

        internal NLogSelf.ILogger GetLogger(string name)
        {
            return NLogSelf.LogManager.GetLogger(name);
        }
    }
}