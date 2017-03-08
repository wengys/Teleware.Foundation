using System;
using NLogSelf = NLog;

namespace Teleware.Foundation.Diagnostics.Loggers
{
    /// <summary>
    /// 基于NLog的默认日志实现
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    public class NLogLoggerImpl<TClass> : ILogger<TClass>
    {
        private static NLogSelf.ILogger _innerLogger;

        static NLogLoggerImpl()
        {
            var catalog = typeof(TClass).FullName;
            _innerLogger = NLogSelf.LogManager.GetLogger(catalog);
        }

        public void Debug(int eventId, string message)
        {
            _innerLogger.Debug(message);
        }

        public void Debug(int eventId, Exception exception, string message)
        {
            _innerLogger.Debug(exception, message);
        }

        public void Error(int eventId, string message)
        {
            _innerLogger.Error(message);
        }

        public void Error(int eventId, Exception exception, string message)
        {
            _innerLogger.Error(exception, message);
        }

        public void Fatal(int eventId, string message)
        {
            _innerLogger.Fatal(message);
        }

        public void Fatal(int eventId, Exception exception, string message)
        {
            _innerLogger.Fatal(exception, message);
        }

        public void Info(int eventId, string message)
        {
            _innerLogger.Info(message);
        }

        public void Info(int eventId, Exception exception, string message)
        {
            _innerLogger.Info(exception, message);
        }

        public void Trace(int eventId, string message)
        {
            _innerLogger.Trace(message);
        }

        public void Trace(int eventId, Exception exception, string message)
        {
            _innerLogger.Trace(exception, message);
        }

        public void Warn(int eventId, string message)
        {
            _innerLogger.Warn(message);
        }

        public void Warn(int eventId, Exception exception, string message)
        {
            _innerLogger.Warn(exception, message);
        }
    }
}