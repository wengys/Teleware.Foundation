using System;
using System.Collections.Generic;
using System.Text;

namespace Teleware.Foundation.Host
{
    /// <summary>
    /// <see cref="IEnvironment"/>相关扩展
    /// </summary>
    public static class EnvironmentExtensions
    {
        /// <summary>
        /// 检查当前是否位于 "Development" 环境
        /// </summary>
        /// <param name="hostingEnvironment"><see cref="IEnvironment"/>实例</param>
        /// <returns>True/False</returns>
        public static bool IsDevelopment(this IEnvironment hostingEnvironment)
        {
            if (hostingEnvironment == null)
            {
                throw new ArgumentNullException(nameof(hostingEnvironment));
            }

            return hostingEnvironment.IsEnvironment(EnvironmentName.Development);
        }

        /// <summary>
        /// 检查当前是否位于 "Staging" 环境
        /// </summary>
        /// <param name="hostingEnvironment"><see cref="IEnvironment"/>实例</param>
        /// <returns>True/False</returns>
        public static bool IsStaging(this IEnvironment hostingEnvironment)
        {
            if (hostingEnvironment == null)
            {
                throw new ArgumentNullException(nameof(hostingEnvironment));
            }

            return hostingEnvironment.IsEnvironment(EnvironmentName.Staging);
        }

        /// <summary>
        /// 检查当前是否位于 "Production" 环境
        /// </summary>
        /// <param name="hostingEnvironment"><see cref="IEnvironment"/>实例</param>
        /// <returns>True/False</returns>
        public static bool IsProduction(this IEnvironment hostingEnvironment)
        {
            if (hostingEnvironment == null)
            {
                throw new ArgumentNullException(nameof(hostingEnvironment));
            }

            return hostingEnvironment.IsEnvironment(EnvironmentName.Production);
        }

        /// <summary>
        /// 检查当前是否位于特定环境之中
        /// </summary>
        /// <param name="hostingEnvironment"><see cref="IEnvironment"/>实例</param>
        /// <returns>True/False</returns>
        /// <summary>
        /// Compares the current hosting environment name against the specified value.
        /// </summary>
        /// <param name="hostingEnvironment">An instance of <see cref="IHostingEnvironment"/>.</param>
        /// <param name="environmentName">Environment name to validate against.</param>
        /// <returns>True if the specified name is the same as the current environment, otherwise false.</returns>
        public static bool IsEnvironment(
            this IEnvironment hostingEnvironment,
            string environmentName)
        {
            if (hostingEnvironment == null)
            {
                throw new ArgumentNullException(nameof(hostingEnvironment));
            }

            return string.Equals(
                hostingEnvironment.EnvironmentName,
                environmentName,
                StringComparison.OrdinalIgnoreCase);
        }
    }
}