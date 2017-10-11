using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teleware.Foundation.Assertion;

namespace Teleware.Foundation.DateTimes
{
    /// <summary>
    /// 时间点
    /// </summary>
    public abstract class Instant
    {
        /// <summary>
        /// 类型
        /// </summary>
        public InstantType InstantType { get; protected set; }

        /// <summary>
        /// 类型所在组
        /// </summary>
        public InstantTypeGroup InstantTypeGroup { get; protected set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="typeGroup">类型所在组</param>
        protected Instant(InstantType type, InstantTypeGroup typeGroup)
        {
            InstantType = type;
            InstantTypeGroup = typeGroup;
        }

        /// <summary>
        /// 转为int
        /// </summary>
        /// <returns></returns>
        public abstract int ToInt();

        /// <summary>
        /// 枚举 [ 当前时间点, <paramref name="endInstant"/> ] 的所有时间点
        /// </summary>
        /// <param name="endInstant"></param>
        /// <returns></returns>
        public abstract Instant[] RangeTo(Instant endInstant);

        /// <summary>
        /// 转为int
        /// </summary>
        /// <param name="instant"></param>
        public static explicit operator int(Instant instant)
        {
            return instant.ToInt();
        }

        /// <summary>
        /// 是否属于同一类型组
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsSameTypeGroup(Instant other)
        {
            return this.InstantTypeGroup == other.InstantTypeGroup;
        }

        /// <summary>
        /// 检查是否两个<see cref="Instant"/>实例类型组相同
        /// </summary>
        /// <param name="right"></param>
        /// <exception cref="ArgumentException">类型组不同</exception>
        public void EnsureSameTypeGroup(Instant right)
        {
            if (!this.IsSameTypeGroup(right))
            {
                throw new ArgumentException($"不一致的时间点类型组");
            }
        }

        /// <summary>
        /// 枚举 [ <paramref name="from"/>, <paramref name="to"/> ] 的所有时间点
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Instant[] Range(Instant from, Instant to)
        {
            return from.RangeTo(to);
        }

        /// <summary>
        /// 转为字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToInt().ToString();
        }

        /// <summary>
        /// 将3个数字分片组装为单个int数字（三个分片最多表示年月日）
        /// </summary>
        /// <param name="seg1"></param>
        /// <param name="seg2"></param>
        /// <param name="seg3"></param>
        /// <returns></returns>
        protected static int ToIntBySegments(int seg1, int seg2, int seg3)
        {
            return seg1 * 100000 + seg2 * 1000 + seg3;
        }

        /// <summary>
        /// 将int数字分解为三个分片
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected static int[] SplitToIntSegments(int value)
        {
            var seg1 = value / 100000;
            var seg2 = value / 1000 - seg1 * 100;
            var seg3 = value % 1000;
            return new[] { seg1, seg2, seg3 };
        }

        #region From*

        /// <summary>
        /// 将int值转换为时间点
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Instant FromInt(int value)
        {
            var segments = SplitToIntSegments(value);
            if (YearMonthDayInstant.TryParseSegments(segments, out var dInst))
            {
                return dInst;
            }
            else if (YearMonthInstant.TryParseSegments(segments, out var ymInst))
            {
                return ymInst;
            }
            else if (YearQuarterInstant.TryParseSegments(segments, out var yqInst))
            {
                return yqInst;
            }
            else if (YearHalfYearInstant.TryParseSegments(segments, out var yhInst))
            {
                return yhInst;
            }
            else if (YearInstant.TryParseSegments(segments, out var yInst))
            {
                return yInst;
            }
            else
            {
                throw new ArgumentException(nameof(value), $"无法将值 {value} 转换为时间点");
            }
        }

        /// <summary>
        /// 根据年-月-日创建新实例
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static Instant FromDay(int year, int month, int day)
        {
            return new YearMonthDayInstant(year, month, day);
        }

        /// <summary>
        /// 根据年-月创建新实例
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static Instant FromMonth(int year, int month)
        {
            return new YearMonthInstant(year, month);
        }

        /// <summary>
        /// 根据年-季度创建新实例
        /// </summary>
        /// <param name="year"></param>
        /// <param name="quarter"></param>
        /// <returns></returns>
        public static Instant FromQuarter(int year, int quarter)
        {
            return new YearQuarterInstant(year, quarter);
        }

        /// <summary>
        /// 根据年-半年创建新实例
        /// </summary>
        /// <param name="year"></param>
        /// <param name="halfYear"></param>
        /// <returns></returns>
        public static Instant FromHalfYear(int year, int halfYear)
        {
            return new YearHalfYearInstant(year, halfYear);
        }

        /// <summary>
        /// 根据年创建新实例
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Instant FromYear(int year)
        {
            return new YearInstant(year);
        }

        #endregion From*
    }
}