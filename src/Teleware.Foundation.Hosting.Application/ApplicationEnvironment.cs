using System;
using Teleware.Foundation.Hosting;

namespace Teleware.Foundation.Host.Application
{
    /// <summary>
    /// 程序执行环境
    /// </summary>
    public class ApplicationEnvironment : IEnvironment
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="environmentName">环境名</param>
        /// <param name="contentRootPath">资源根路径</param>
        public ApplicationEnvironment(string environmentName = null, string contentRootPath = null)
        {
            EnvironmentName = environmentName
                ?? System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                ?? Teleware.Foundation.Host.EnvironmentName.Development;
            ContentRootPath = contentRootPath ?? System.AppContext.BaseDirectory;
        }

        /// <summary>
        /// 当前环境名
        /// </summary>
        public string EnvironmentName { get; }

        /// <summary>
        /// 资源根路径
        /// </summary>
        public string ContentRootPath { get; }
    }
}