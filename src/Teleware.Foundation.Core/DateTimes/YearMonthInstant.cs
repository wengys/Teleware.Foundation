using System;
using System.Linq;
using Teleware.Foundation.Assertion;

namespace Teleware.Foundation.DateTimes
{
    /// <summary>
    /// 年-月时间点
    /// </summary>
    public class YearMonthInstant : YearInstant
    {
        /// <summary>
        /// 月
        /// </summary>
        public int Month => InstantType - InstantType.Jan + 1;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        public YearMonthInstant(int year, int month) : base(year)
        {
            month.ShouldBe(IsValidMonth, () => new ArgumentOutOfRangeException(nameof(month), "月份应在 1~12 之间，当前值: " + month));
            InstantType = (InstantType)month;
            InstantTypeGroup = InstantTypeGroup.Monthy;
        }

        private static bool IsValidMonth(int m)
        {
            return m >= 1 && m <= 12;
        }

        /// <summary>
        /// 尝试从int型片段转换为实例
        /// </summary>
        /// <param name="segments"></param>
        /// <param name="instant"></param>
        /// <returns></returns>
        internal static bool TryParseSegments(int[] segments, out YearMonthInstant instant)
        {
            var year = segments[0];
            var month = segments[1] - (int)InstantType.Jan + 1;

            if (IsValidMonth(month))
            {
                instant = new YearMonthInstant(year, month);
                return true;
            }
            instant = null;
            return false;
        }

        /// <summary>
        /// 枚举 [ 当前时间点, <paramref name="endInstant"/> ] 的所有时间点
        /// </summary>
        /// <param name="endInstant"></param>
        /// <returns></returns>
        public override Instant[] RangeTo(Instant endInstant)
        {
            EnsureSameTypeGroup(endInstant);

            var from = (YearMonthInstant)this;
            var to = (YearMonthInstant)endInstant;
            bool reverse = false;

            var rangeStartDelta = 0;
            var rangeEndDelta = (to.Year - from.Year) * 12 + (to.Month - from.Month);
            if (rangeStartDelta > rangeEndDelta)
            {
                var tmp = rangeStartDelta;
                rangeStartDelta = rangeEndDelta;
                rangeEndDelta = tmp;
                reverse = true;
            }
            var rangeDeltas = Enumerable.Range(rangeStartDelta, rangeEndDelta - rangeStartDelta + 1);
            var result = rangeDeltas.Select(rd =>
            {
                var year = from.Year;
                var month = from.Month;
                month = month + rd;
                while (month > 12)
                {
                    year = year + 1;
                    month = month - 12;
                }
                while (month <= 0)
                {
                    year = year - 1;
                    month = month + 12;
                }
                return new YearMonthInstant(year, month);
            });
            return reverse ? result.Reverse().ToArray() : result.ToArray();
        }
    }
}