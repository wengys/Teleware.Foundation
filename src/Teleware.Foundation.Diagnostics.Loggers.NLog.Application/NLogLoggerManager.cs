using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleware.Foundation.Configuration;

using NLogSelf = NLog;

namespace Teleware.Foundation.Diagnostics.Loggers.NLog.Application
{
    internal class NLogLoggerManager : INLogLoggerManager
    {
        private static bool _initialized = false;

        public NLogLoggerManager(IBootupConfigurationProvider bootupConfigurationProvider)
        {
            if (_initialized == false)
            {
                lock (typeof(NLogLoggerManager))
                {
                    if (_initialized != false)
                    {
                        return;
                    }
                    var configurationFilePath = bootupConfigurationProvider.GetNLogConfigFilePath();
                    if (configurationFilePath != null)
                    {
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

        public NLogSelf.ILogger GetLogger(string name)
        {
            return NLogSelf.LogManager.GetLogger(name);
        }
    }
}