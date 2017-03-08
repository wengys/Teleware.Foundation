using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text.RegularExpressions;
using Teleware.Data;
using Teleware.Data.Impl;
using Teleware.Foundation.Options;
using Teleware.Foundation.Assertion;
using Oracle.ManagedDataAccess.EntityFramework;
using System.Data.Entity;

namespace Teleware.Data.Impl
{
    /// <summary>
    /// 基于Oracle数据库的EF上下文工厂
    /// </summary>
    public class OracleEFContextFactory : IEFContextFactory
    {
        private readonly DatabaseOptions _configure;
        private readonly Lazy<IEnumerable<IDbObjConfiguration>> _dbConfigurations;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configureOptions"></param>
        /// <param name="dbConfigurations"></param>
        public OracleEFContextFactory(IOptions<DatabaseOptions> configureOptions, Lazy<IEnumerable<IDbObjConfiguration>> dbConfigurations)
        {
            _configure = configureOptions.Value;
            _dbConfigurations = dbConfigurations;
        }

        /// <inheritdoc/>
        public DbContext CreateContext(string connectionName)
        {
            var connString = _configure.GetConnectionString(connectionName);
            connString.ProviderName.ShouldBe(pn => pn == "Oracle.ManagedDataAccess.Client", $"不支持的ProviderName: {connString.ProviderName}");
            string schema = GetOracleSchema(connString.ConnectionString);
            return new OracleEFContext(connString.ConnectionString, schema, _dbConfigurations);
        }

        private static string GetOracleSchema(string connectionString)
        {
            const string userIdRegex = "User Id=(?<schema>[^;]*);";
            var item = Regex.Match(connectionString, userIdRegex, RegexOptions.IgnoreCase);
            var schema = item.Groups["schema"].Value;
            return schema;
        }

        
        
        
    }
}