using System;
using System.Collections.Generic;
using System.Linq;
using Teleware.Foundation.Assertion;

namespace Teleware.Foundation.DateTimes
{
    /// <summary>
    /// 精确到天的时间点
    /// </summary>
    public class YearMonthDayInstant : YearMonthInstant
    {
        /// <summary>
        /// 日期
        /// </summary>
        public int Day { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        public YearMonthDayInstant(int year, int month, int day) : base(year, month)
        {
            var daysInMonth = DateTime.DaysInMonth(year, month);
            day.ShouldBe(
                d => IsValidDay(daysInMonth, day),
                () => new ArgumentOutOfRangeException(nameof(day), $"日期应在 1~{daysInMonth} 之间，当前值: {day}"));

            Day = day;

            InstantTypeGroup = InstantTypeGroup.Daily;
        }

        /// <summary>
        /// 转为int数值
        /// </summary>
        public override int ToInt()
        {
            return base.ToInt() + Day;
        }

        private bool IsValidDay(int daysInMonth, int day)
        {
            return day >= 1 && day <= daysInMonth;
        }

        /// <summary>
        /// 尝试从int型片段转换为实例
        /// </summary>
        /// <param name="segments"></param>
        /// <param name="instant"></param>
        /// <returns></returns>
        internal static bool TryParseSegments(int[] segments, out YearMonthDayInstant instant)
        {
            if (segments[2] == 0)
            {
                instant = null;
                return false;
            }
            try
            {
                instant = new YearMonthDayInstant(segments[0], segments[1] - (int)InstantType.Jan + 1, segments[2]);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                instant = null;
                return false;
            }
        }

        /// <summary>
        /// 枚举 [ 当前时间点, <paramref name="endInstant"/> ] 的所有时间点
        /// </summary>
        /// <param name="endInstant"></param>
        /// <returns></returns>
        public override Instant[] RangeTo(Instant endInstant)
        {
            EnsureSameTypeGroup(endInstant);

            var from = (YearMonthDayInstant)this;
            var to = (YearMonthDayInstant)endInstant;
            bool reverse = false;

            var dFrom = new DateTime(from.Year, from.Month, from.Day);
            var dTo = new DateTime(to.Year, to.Month, to.Day);

            if (dFrom > dTo)
            {
                var tmp = dFrom;
                dFrom = dTo;
                dTo = tmp;
                reverse = true;
            }

            List<Instant> results = new List<Instant>();
            while (dFrom <= dTo)
            {
                results.Add(new YearMonthDayInstant(dFrom.Year, dFrom.Month, dFrom.Day));
                dFrom = dFrom.AddDays(1);
            }

            if (reverse)
            {
                results.Reverse();
            }

            return results.ToArray();
        }
    }
}