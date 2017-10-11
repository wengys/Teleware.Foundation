using System;
using System.Linq;
using Teleware.Foundation.Assertion;

namespace Teleware.Foundation.DateTimes
{
    /// <summary>
    /// 年-季度时间点
    /// </summary>
    public class YearQuarterInstant : YearInstant
    {
        /// <summary>
        /// 季度
        /// </summary>
        public int Quarter => InstantType - InstantType.Q1 + 1;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="year"></param>
        /// <param name="quarter"></param>
        public YearQuarterInstant(int year, int quarter) : base(year)
        {
            quarter.ShouldBe(IsValidQuarter, () => new ArgumentOutOfRangeException(nameof(quarter), "季度应在 1~4 之间，当前值: " + quarter));
            InstantType = quarter + InstantType.Q1 - 1;
            InstantTypeGroup = InstantTypeGroup.Quarterly;
        }

        private static bool IsValidQuarter(int q)
        {
            return q >= 1 && q <= 4;
        }

        /// <summary>
        /// 尝试从int型片段转换为实例
        /// </summary>
        /// <param name="segments"></param>
        /// <param name="instant"></param>
        /// <returns></returns>
        internal static bool TryParseSegments(int[] segments, out YearQuarterInstant instant)
        {
            var year = segments[0];
            var quarter = segments[1] - (int)InstantType.Q1 + 1;

            if (IsValidQuarter(quarter))
            {
                instant = new YearQuarterInstant(year, quarter);
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

            var from = (YearQuarterInstant)this;
            var to = (YearQuarterInstant)endInstant;
            bool reverse = false;

            var rangeStartDelta = 0;
            var rangeEndDelta = (to.Year - from.Year) * 4 + (to.Quarter - from.Quarter);
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
                var quarter = from.Quarter;
                quarter = quarter + rd;
                while (quarter > 4)
                {
                    year = year + 1;
                    quarter = quarter - 4;
                }
                while (quarter <= 0)
                {
                    year = year - 1;
                    quarter = quarter + 4;
                }
                return new YearQuarterInstant(year, quarter);
            });
            return reverse ? result.Reverse().ToArray() : result.ToArray();
        }
    }
}