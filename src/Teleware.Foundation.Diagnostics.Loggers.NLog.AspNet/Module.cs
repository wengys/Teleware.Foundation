using Autofac;
using Teleware.Foundation.Configuration;
using Teleware.Foundation.Diagnostics;

namespace Teleware.Foundation.Diagnostics.Loggers.NLog.AspNet
{
    /// <summary>
    ///
    /// </summary>
    public class Module : Autofac.Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((ctx) => new NLogLoggerManager(ctx.Resolve<IBootupConfigurationProvider>())).As<INLogLoggerManager>().SingleInstance();
        }
    }
}