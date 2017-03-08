using System;

namespace Teleware.Foundation.Exceptions
{
    /// <summary>
    /// 业务异常
    /// </summary>
    public abstract class BusinessException : Exception
    {
        /// <inheritdoc/>
        protected BusinessException() : base()
        {
        }

        /// <inheritdoc/>
        protected BusinessException(string message) : base(message)
        {
        }

        /// <inheritdoc/>
        protected BusinessException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// 客户端业务异常
    /// </summary>
    /// <remarks>
    /// 异常信息客户端可见
    /// </remarks>
    public abstract class ClientNoticeableException : BusinessException
    {
        /// <inheritdoc/>
        protected ClientNoticeableException() : base()
        {
        }

        /// <inheritdoc/>
        protected ClientNoticeableException(string message) : base(message)
        {
        }

        /// <inheritdoc/>
        protected ClientNoticeableException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}