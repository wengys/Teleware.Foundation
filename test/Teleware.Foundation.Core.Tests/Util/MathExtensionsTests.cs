using Teleware.Foundation.Util;
using Xunit;

namespace Teleware.Foundation.Core.Tests.Util
{
    public class MathExtensionsTests
    {
        [Fact]
        public void ToFixedDecimalTest()
        {
            var source = 1.999999M;
            var digits = 3;
            var expected = 1.999M;

            var actual = source.ToFixed(digits);
            Xunit.Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToFixedTruncateAllDigitsDecimalTest()
        {
            var source = 1.999999M;
            var digits = 0;
            var expected = 1M;

            var actual = source.ToFixed(digits);
            Xunit.Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToFixedDoubleTest()
        {
            var source = 1.999999;
            var digits = 3;
            var expected = 1.999;

            var actual = source.ToFixed(digits);
            Xunit.Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToFixedTruncateAllDigitDoubleTest()
        {
            var source = 1.999999;
            var digits = 0;
            var expected = 1;

            var actual = source.ToFixed(digits);
            Xunit.Assert.Equal(expected, actual);
        }
    }
}