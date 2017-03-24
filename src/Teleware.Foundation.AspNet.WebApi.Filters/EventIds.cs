using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleware.Foundation.AspNet.WebApi.Filters
{
    /// <summary>
    /// 事件Id
    /// </summary>
    public static class EventIds
    {
        public const int ClientNoticeableExceptionEventId = 1000;
        public const int HttpClientNoticeableExceptionEventId = 1050;
        public const int UnknownExceptionEventId = 2000;
    }
}