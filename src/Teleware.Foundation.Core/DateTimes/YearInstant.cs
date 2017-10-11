using System.Linq;

namespace Teleware.Foundation.DateTimes
{
    /// <summary>
    /// 年时间点
    /// </summary>
    public class YearInstant : Instant
    {
        /// <summary>
        /// 年度
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="year"></param>
        public YearInstant(int year) : base(InstantType.FullYear, InstantTypeGroup.Yearly)
        {
            Year = year;
        }

        /// <summary>
        /// 转为int数值
        /// </summary>

        public override int ToInt()
        {
            return ToIntBySegments(Year, (int)InstantType, 0);
        }

        /// <summary>
        /// 尝试从int型片段转换为实例
        /// </summary>
        /// <param name="segments"></param>
        /// <param name="instant"></param>
        /// <returns></returns>
        internal static bool TryParseSegments(int[] segments, out YearInstant instant)
        {
            var year = segments[0];
            var type = segments[1];
            if (type == (int)InstantType.FullYear)
            {
                instant = new YearInstant(year);
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

            var from = (YearInstant)this;
            var to = (YearInstant)endInstant;
            bool reverse = false;

            var rangeStartDelta = 0;
            var rangeEndDelta = (to.Year - from.Year);
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
                year = year + rd;
                return Instant.FromYear(year);
            });

            return reverse ? result.Reverse().ToArray() : result.ToArray();
        }
    }
}