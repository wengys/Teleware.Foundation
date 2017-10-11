using System;
using System.Linq;
using Teleware.Foundation.Assertion;

namespace Teleware.Foundation.DateTimes
{
    /// <summary>
    /// 年-半年时间点
    /// </summary>
    public class YearHalfYearInstant : YearInstant
    {
        /// <summary>
        /// 半年
        /// </summary>
        public int HalfYear => InstantType - InstantType.FirstHalfYear + 1;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="year"></param>
        /// <param name="halfYear"></param>
        public YearHalfYearInstant(int year, int halfYear) : base(year)
        {
            halfYear.ShouldBe(IsValidHalfYear, () => new ArgumentOutOfRangeException(nameof(halfYear), "半年应在 1~2 之间，当前值: " + halfYear));
            InstantType = halfYear + InstantType.FirstHalfYear - 1;
            InstantTypeGroup = InstantTypeGroup.HalfYearly;
        }

        private static bool IsValidHalfYear(int hy)
        {
            return hy >= 1 && hy <= 2;
        }

        /// <summary>
        /// 尝试从int型片段转换为实例
        /// </summary>
        /// <param name="segments"></param>
        /// <param name="instant"></param>
        /// <returns></returns>
        internal static bool TryParseSegments(int[] segments, out YearHalfYearInstant instant)
        {
            var year = segments[0];
            var halfYear = segments[1] - (int)InstantType.FirstHalfYear + 1;

            if (IsValidHalfYear(halfYear))
            {
                instant = new YearHalfYearInstant(year, halfYear);
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

            var from = (YearHalfYearInstant)this;
            var to = (YearHalfYearInstant)endInstant;
            bool reverse = false;

            var rangeStartDelta = 0;
            var rangeEndDelta = (to.Year - from.Year) * 2 + (to.HalfYear - from.HalfYear);
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
                var halfYear = from.HalfYear;
                halfYear = halfYear + rd;
                while (halfYear > 2)
                {
                    year = year + 1;
                    halfYear = halfYear - 2;
                }
                while (halfYear <= 0)
                {
                    year = year - 1;
                    halfYear = halfYear + 2;
                }
                return new YearHalfYearInstant(year, halfYear);
            });
            return reverse ? result.Reverse().ToArray() : result.ToArray();
        }
    }
}