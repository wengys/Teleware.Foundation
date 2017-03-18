using Autofac;
using Teleware.Foundation.Diagnostics;

namespace Teleware.Foundation.Diagnostics.Loggers.NLog
{
    /// <summary>
    ///
    /// </summary>
    public class Module : Autofac.Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(NLogLoggerImpl<>)).As(typeof(ILogger<>)).SingleInstance();
            builder.Register((ctx) => new NLogLoggerFactory()).As(typeof(ILoggerFactory)).SingleInstance();
        }
    }
}