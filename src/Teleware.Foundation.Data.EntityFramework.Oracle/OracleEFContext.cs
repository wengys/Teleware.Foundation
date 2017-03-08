﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleware.Foundation.Domain.Entity;
using Teleware.Foundation.Domain.Event;

namespace Teleware.Data.Impl
{
    /// <summary>
    /// 增加了初始化功能的<see cref="DbContext"/>
    /// </summary>
    [DbConfigurationType(typeof(OracleConfiguration))]
    public class OracleEFContext : DbContext
    {
        private readonly string _schema;
        private readonly Lazy<IEnumerable<IDbObjConfiguration>> _configurations;

        static OracleEFContext()
        {
            System.Data.Entity.Database.SetInitializer<OracleEFContext>(null);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="configurations"></param>
        public OracleEFContext(string connectionString, string schema, Lazy<IEnumerable<IDbObjConfiguration>> configurations)
            :base(connectionString)
        {
            
            _schema = schema;
            _configurations = configurations;
            //Debug.AutoFlush = true;
            //this.Database.Log = s => Debug.WriteLine(s);
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(_schema);

            foreach (var config in _configurations.Value)
            {
                modelBuilder.Configurations.Add((dynamic)config);
            }

            modelBuilder.Ignore<DomainEventPostBox>();
            //为decimal类型设置默认精度
            modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            modelBuilder.Conventions.Add(new DecimalPropertyConvention(12, 4));

            base.OnModelCreating(modelBuilder);
        }

        /// <inheritdoc/>
        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            var result = base.ValidateEntity(entityEntry, items);
            if (!result.IsValid)
            {
                var errs = result.ValidationErrors.ToArray();
                foreach (var err in errs)
                {
                    CoerceRemoveFromCollectionError(entityEntry, result, err);
                }
            }
            return result;
        }

        /// <summary>
        /// 修正由于从集合中删除元素而导致外键为空异常
        /// </summary>
        /// <param name="entityEntry"></param>
        /// <param name="result"></param>
        /// <param name="err"></param>
        private void CoerceRemoveFromCollectionError(DbEntityEntry entityEntry, DbEntityValidationResult result, DbValidationError err)
        {
            var errProp = err.PropertyName;
            if (entityEntry.State == EntityState.Modified && entityEntry.Property(errProp).CurrentValue == null)
            {
                bool isEntityRequiredForeignKeyEmpty = IsEntityRequiredForeignKeyEmpty(entityEntry, errProp);
                if (isEntityRequiredForeignKeyEmpty)
                {
                    entityEntry.State = EntityState.Deleted;
                    result.ValidationErrors.Remove(err);
                }
            }
        }

        private bool IsEntityRequiredForeignKeyEmpty(DbEntityEntry entityEntry, string errProp)
        {
            RelationshipManager relMgr =
                ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager
                    .GetRelationshipManager(entityEntry.Entity);
            IEnumerable<IRelatedEnd> relEnds = relMgr.GetAllRelatedEnds();
            IRelatedEnd relEnd = relEnds.Where(r =>
            {
                var elementType = (EntityTypeBase)r.RelationshipSet.ElementType;
                var metadataProperty = elementType.MetadataProperties.GetValue(
                    "ReferentialConstraints", false);
                var referentialConstraints =
                    (
                        System.Data.Entity.Core.Metadata.Edm.ReadOnlyMetadataCollection
                            <ReferentialConstraint>)metadataProperty.Value;
                if (referentialConstraints.Any(constraint =>
                {
                    return
                        constraint.ToProperties.Any(
                            t => t.Nullable == false && t.IsPrimitiveType && t.Name == errProp);
                }))
                {
                    return true;
                }
                return false;
            }).FirstOrDefault();
            bool isEntityRequiredForeignKeyEmpty = relEnd != null;
            return isEntityRequiredForeignKeyEmpty;
        }
    }

    internal class OracleConfiguration : DbConfiguration
    {
        public OracleConfiguration()
        {
            SetProviderServices("Oracle.ManagedDataAccess.Client", Oracle.ManagedDataAccess.EntityFramework.EFOracleProviderServices.Instance);
        }
    }
}