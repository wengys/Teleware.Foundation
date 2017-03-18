﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleware.Foundation.Diagnostics.Loggers.NLog
{
    public class NLogLoggerFactory : ILoggerFactory
    {
        private static ConcurrentDictionary<string, ILogger> _cache = new ConcurrentDictionary<string, ILogger>();
        private readonly NLogLogManager _innerLogManager;

        internal NLogLoggerFactory(NLogLogManager innerLogManager)
        {
            _innerLogManager = innerLogManager;
        }

        public ILogger CreateLogger(string loggerName)
        {
            return _cache.GetOrAdd(loggerName, (name) => new NLogLoggerImpl(name, _innerLogManager));
        }
    }
}