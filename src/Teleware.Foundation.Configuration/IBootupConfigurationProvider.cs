using Microsoft.Extensions.Configuration;

namespace Teleware.Foundation.Configuration
{
    public interface IBootupConfigurationProvider
    {
        IConfigurationRoot GetBootupConfiguration();
    }
}