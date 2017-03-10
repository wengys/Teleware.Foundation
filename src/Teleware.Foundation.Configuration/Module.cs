using Autofac;
using Teleware.Foundation.Options;
using Teleware.Foundation.Configuration.Extensions;

namespace Teleware.Foundation.Configuration
{
    /// <summary>
    ///
    /// </summary>
    public class Module : Autofac.Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.AddOptions();
            builder.ConfigureOptions<DatabaseOptions>();
            builder.RegisterType<ConfigurationFactory>().As<IConfigurationFactory>().SingleInstance();
        }
    }
}