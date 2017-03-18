using NLog;
using System;

using NLogSelf = NLog;

namespace Teleware.Foundation.Diagnostics.Loggers.NLog
{
    /// <summary>
    /// 基于NLog的默认日志实现
    /// </summary>
    internal class NLogLoggerImpl : ILogger
    {
        private static NLogSelf.ILogger _innerLogger;

        public NLogLoggerImpl(string loggerName)
        {
            _innerLogger = NLogSelf.LogManager.GetLogger(loggerName);
        }

        public void Debug(int eventId, string message)
        {
            Log(LogLevel.Debug, eventId, null, message);
        }

        public void Debug(int eventId, Exception exception, string message)
        {
            Log(LogLevel.Debug, eventId, exception, message);
        }

        public void Error(int eventId, string message)
        {
            Log(LogLevel.Error, eventId, null, message);
        }

        public void Error(int eventId, Exception exception, string message)
        {
            Log(LogLevel.Error, eventId, exception, message);
        }

        public void Fatal(int eventId, string message)
        {
            Log(LogLevel.Fatal, eventId, null, message);
        }

        public void Fatal(int eventId, Exception exception, string message)
        {
            Log(LogLevel.Fatal, eventId, exception, message);
        }

        public void Info(int eventId, string message)
        {
            Log(LogLevel.Info, eventId, null, message);
        }

        public void Info(int eventId, Exception exception, string message)
        {
            Log(LogLevel.Info, eventId, exception, message);
        }

        public void Trace(int eventId, string message)
        {
            Log(LogLevel.Trace, eventId, null, message);
        }

        public void Trace(int eventId, Exception exception, string message)
        {
            Log(LogLevel.Trace, eventId, exception, message);
        }

        public void Warn(int eventId, string message)
        {
            Log(LogLevel.Warn, eventId, null, message);
        }

        public void Warn(int eventId, Exception exception, string message)
        {
            Log(LogLevel.Warn, eventId, exception, message);
        }

        private void Log(NLogSelf.LogLevel level, int eventId, Exception exception, string message)
        {
            if (_innerLogger.IsEnabled(level))
            {
                var eventInfo = NLogSelf.LogEventInfo.Create(level, _innerLogger.Name, message);
                eventInfo.Exception = exception;
                eventInfo.Properties["EventId"] = eventId;
                eventInfo.Properties["EventId.Id"] = eventId;
                _innerLogger.Log(eventInfo);
            }
        }
    }

    /// <summary>
    /// 基于NLog的默认日志实现
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    internal class NLogLoggerImpl<TClass> : ILogger<TClass>
    {
        private static NLogSelf.ILogger _innerLogger;

        static NLogLoggerImpl()
        {
            var catalog = typeof(TClass).FullName;
            _innerLogger = NLogSelf.LogManager.GetLogger(catalog);
        }

        public void Debug(int eventId, string message)
        {
            //_innerLogger.Debug(message);
            Log(LogLevel.Debug, eventId, null, message);
        }

        public void Debug(int eventId, Exception exception, string message)
        {
            Log(LogLevel.Debug, eventId, exception, message);
            //_innerLogger.Debug(exception, message);
        }

        public void Error(int eventId, string message)
        {
            Log(LogLevel.Error, eventId, null, message);
            //_innerLogger.Error(message);
        }

        public void Error(int eventId, Exception exception, string message)
        {
            Log(LogLevel.Error, eventId, exception, message);
            //_innerLogger.Error(exception, message);
        }

        public void Fatal(int eventId, string message)
        {
            Log(LogLevel.Fatal, eventId, null, message);
            //_innerLogger.Fatal(message);
        }

        public void Fatal(int eventId, Exception exception, string message)
        {
            Log(LogLevel.Fatal, eventId, exception, message);
            //_innerLogger.Fatal(exception, message);
        }

        public void Info(int eventId, string message)
        {
            Log(LogLevel.Info, eventId, null, message);
            //_innerLogger.Info(message);
        }

        public void Info(int eventId, Exception exception, string message)
        {
            Log(LogLevel.Info, eventId, exception, message);
            //_innerLogger.Info(exception, message);
        }

        public void Trace(int eventId, string message)
        {
            Log(LogLevel.Trace, eventId, null, message);
            //_innerLogger.Trace(message);
        }

        public void Trace(int eventId, Exception exception, string message)
        {
            Log(LogLevel.Trace, eventId, exception, message);
            //_innerLogger.Trace(exception, message);
        }

        public void Warn(int eventId, string message)
        {
            Log(LogLevel.Warn, eventId, null, message);
            //_innerLogger.Warn(message);
        }

        public void Warn(int eventId, Exception exception, string message)
        {
            Log(LogLevel.Warn, eventId, exception, message);
            //_innerLogger.Warn(exception, message);
        }

        private void Log(NLogSelf.LogLevel level, int eventId, Exception exception, string message)
        {
            if (_innerLogger.IsEnabled(level))
            {
                var eventInfo = NLogSelf.LogEventInfo.Create(level, _innerLogger.Name, message);
                eventInfo.Exception = exception;
                eventInfo.Properties["EventId"] = eventId;
                eventInfo.Properties["EventId.Id"] = eventId;
                _innerLogger.Log(eventInfo);
            }
        }
    }
}