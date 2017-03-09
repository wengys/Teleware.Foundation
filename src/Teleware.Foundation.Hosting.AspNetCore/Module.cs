using Autofac;

namespace Teleware.Foundation.Hosting.AspNetCore
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