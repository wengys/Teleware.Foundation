using System;
using Teleware.Foundation.DateTimes;
using Xunit;

namespace Teleware.Foundation.Core.Tests.DateTimes
{
    public class InstantTests
    {
        [Theory]
        [InlineData(201791000, typeof(YearInstant), InstantType.FullYear, InstantTypeGroup.Yearly, new int[] { 2017 })]
        [InlineData(201732000, typeof(YearHalfYearInstant), InstantType.LastHalfYear, InstantTypeGroup.HalfYearly, new int[] { 2017, 02 })]
        [InlineData(201723000, typeof(YearQuarterInstant), InstantType.Q3, InstantTypeGroup.Quarterly, new int[] { 2017, 03 })]
        [InlineData(201710000, typeof(YearMonthInstant), InstantType.Oct, InstantTypeGroup.Monthy, new int[] { 2017, 10, 000 })]
        [InlineData(201710001, typeof(YearMonthDayInstant), InstantType.Oct, InstantTypeGroup.Daily, new int[] { 2017, 10, 001 })]
        public void BuildInstantByIntAndReturnToIntTests(
            int value,
            Type type,
            InstantType instType,
            InstantTypeGroup instTypeGroup,
            int[] segments
            )
        {
            var inst = Instant.FromInt(value);
            Assert.Equal(type, inst.GetType());
            Assert.Equal(inst.InstantType, instType);
            Assert.Equal(inst.InstantTypeGroup, instTypeGroup);
            if (inst.GetType() == typeof(YearInstant))
            {
                var y = inst as YearInstant;
                Assert.Equal(segments[0], y.Year);
                Assert.Equal(value, y.ToInt());
            }
            else if (inst.GetType() == typeof(YearHalfYearInstant))
            {
                var yh = inst as YearHalfYearInstant;
                Assert.Equal(segments[0], yh.Year);
                Assert.Equal(segments[1], yh.HalfYear);
                Assert.Equal(value, yh.ToInt());
            }
            else if (inst.GetType() == typeof(YearQuarterInstant))
            {
                var yq = inst as YearQuarterInstant;
                Assert.Equal(segments[0], yq.Year);
                Assert.Equal(segments[1], yq.Quarter);
                Assert.Equal(value, yq.ToInt());
            }
            else if (inst.GetType() == typeof(YearMonthInstant))
            {
                var ym = inst as YearMonthInstant;
                Assert.Equal(segments[0], ym.Year);
                Assert.Equal(segments[1], ym.Month);
                Assert.Equal(value, ym.ToInt());
            }
            else if (inst.GetType() == typeof(YearMonthDayInstant))
            {
                var ymd = inst as YearMonthDayInstant;
                Assert.Equal(segments[0], ymd.Year);
                Assert.Equal(segments[1], ymd.Month);
                Assert.Equal(segments[2], ymd.Day);
                Assert.Equal(value, ymd.ToInt());
            }
            else
            {
                Assert.False(true);
            }
        }

        [Theory]
        [InlineData(201591000, 201591000, 201591000, 201591000, 1)]
        [InlineData(201591000, 201591000, 201591000, 201591000, 1)]
        [InlineData(201791000, 201591000, 201791000, 201591000, 3)]
        //
        [InlineData(201732000, 201732000, 201732000, 201732000, 1)]
        [InlineData(201531000, 201732000, 201531000, 201732000, 6)]
        [InlineData(201732000, 201531000, 201732000, 201531000, 6)]
        //
        [InlineData(201721000, 201721000, 201721000, 201721000, 1)]
        [InlineData(201521000, 201724000, 201521000, 201724000, 12)]
        [InlineData(201724000, 201521000, 201724000, 201521000, 12)]
        //
        [InlineData(201701000, 201701000, 201701000, 201701000, 1)]
        [InlineData(201501000, 201712000, 201501000, 201712000, 36)]
        [InlineData(201712000, 201501000, 201712000, 201501000, 36)]
        //
        [InlineData(201701001, 201701001, 201701001, 201701001, 1)]
        [InlineData(201501001, 201712031, 201501001, 201712031, 1096)]
        [InlineData(201712031, 201501001, 201712031, 201501001, 1096)]
        //
        public void InstantRangeTests(int fromInt, int toInt, int expectedStart, int expectedEnd, int expectedCount)
        {
            var from = Instant.FromInt(fromInt);
            var to = Instant.FromInt(toInt);

            var range = Instant.Range(from, to);
            Assert.Equal(expectedCount, range.Length);
            Assert.Equal(expectedStart, range[0].ToInt());
            Assert.Equal(expectedEnd, range[range.Length - 1].ToInt());
        }
    }
}