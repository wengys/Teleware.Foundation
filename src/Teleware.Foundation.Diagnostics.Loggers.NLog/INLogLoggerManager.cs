using Teleware.Foundation.Configuration;

using NLogSelf = NLog;

namespace Teleware.Foundation.Diagnostics.Loggers.NLog
{
    /// <summary>
    /// 描述一个NLog工厂
    /// </summary>
    public interface INLogLoggerManager
    {
        /// <summary>
        /// 获取<see cref="NLogSelf.ILogger"/>实例
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        NLogSelf.ILogger GetLogger(string name);
    }
}