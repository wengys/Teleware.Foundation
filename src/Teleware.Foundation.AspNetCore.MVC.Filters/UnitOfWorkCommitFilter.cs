using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Teleware.Foundation.Data;

namespace Teleware.Foundation.AspNetCore.MVC.Filters
{
    /// <summary>
    /// 工作单元（Unit of Work）拦截器
    /// </summary>
    /// <remarks>
    /// 每个请求执行完成后，由此拦截器负责提交工作单元
    /// </remarks>
    public class UnitOfWorkCommitFilter : Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter
    {
        private readonly IUnitOfWorkCoordinator _uow;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="uow">工作单元协调器，如果有多个工作单元则通过协调器保证一同提交</param>
        public UnitOfWorkCommitFilter(IUnitOfWorkCoordinator uow)
        {
            _uow = uow;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();
            await _uow.CommitAsync();
            //try
            //{
            //await _uow.CommitAsync();
            //}
            //catch (DbEntityValidationException ve)
            //{
            //    var msg = ve.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage;
            //    throw new DbEntityValidationException(msg, ve.EntityValidationErrors, ve);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }
    }
}
