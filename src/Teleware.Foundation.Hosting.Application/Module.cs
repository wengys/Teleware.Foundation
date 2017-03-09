using Autofac;

namespace Teleware.Foundation.Hosting.Application
{
    /// <summary>
    ///
    /// </summary>
    public class Module : Autofac.Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationEnvironment>().As<IEnvironment>().SingleInstance();
        }
    }
}