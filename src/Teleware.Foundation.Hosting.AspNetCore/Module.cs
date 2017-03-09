using Autofac;

namespace Teleware.Foundation.Host.Application
{
    /// <summary>
    ///
    /// </summary>
    public class Module : Autofac.Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AspNetCoreEnvironment>().As<IEnvironment>().SingleInstance();
        }
    }
}