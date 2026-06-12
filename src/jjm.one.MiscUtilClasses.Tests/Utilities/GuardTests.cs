using System;
using System.Collections.Generic;
using jjm.one.MiscUtilClasses.Utilities;

namespace jjm.one.MiscUtilClasses.Tests.Utilities
{
    /// <summary>
    /// This class contains the unit tests for the <see cref="jjm.one.MiscUtilClasses.Utilities.Guard"/> class.
    /// </summary>
    public class GuardTests
    {
        #region tests

        #region NotNull (reference types)

        [Fact]
        public void NotNull_WithNonNullValue_ReturnsValue()
        {
            var result = Guard.NotNull("hello", "value");
            Assert.Equal("hello", result);
        }

        [Fact]
        public void NotNull_WithNullValue_ThrowsArgumentNullException()
        {
            string? value = null;
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.NotNull(value, "myParam"));
            Assert.Equal("myParam", ex.ParamName);
        }

        [Fact]
        public void NotNull_WithNonNullObject_ReturnsObject()
        {
            var obj = new object();
            var result = Guard.NotNull(obj, "obj");
            Assert.Same(obj, result);
        }

        #endregion

        #region NotNullValue (nullable value types)

        [Fact]
        public void NotNullValue_WithValue_ReturnsUnwrapped()
        {
            int? value = 42;
            var result = Guard.NotNullValue(value, "value");
            Assert.Equal(42, result);
        }

        [Fact]
        public void NotNullValue_WithNull_ThrowsArgumentNullException()
        {
            int? value = null;
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.NotNullValue(value, "myParam"));
            Assert.Equal("myParam", ex.ParamName);
        }

        #endregion

        #region NotNullOrEmpty (string)

        [Fact]
        public void NotNullOrEmpty_WithValidString_ReturnsString()
        {
            var result = Guard.NotNullOrEmpty("hello", "s");
            Assert.Equal("hello", result);
        }

        [Fact]
        public void NotNullOrEmpty_WithNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.NotNullOrEmpty(null, "s"));
            Assert.Equal("s", ex.ParamName);
        }

        [Fact]
        public void NotNullOrEmpty_WithEmptyString_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Guard.NotNullOrEmpty("", "s"));
            Assert.Equal("s", ex.ParamName);
        }

        [Fact]
        public void NotNullOrEmpty_WithWhitespace_DoesNotThrow()
        {
            // whitespace is NOT empty — only NotNullOrWhiteSpace catches it
            var result = Guard.NotNullOrEmpty("   ", "s");
            Assert.Equal("   ", result);
        }

        #endregion

        #region NotNullOrWhiteSpace (string)

        [Fact]
        public void NotNullOrWhiteSpace_WithValidString_ReturnsString()
        {
            var result = Guard.NotNullOrWhiteSpace("hello", "s");
            Assert.Equal("hello", result);
        }

        [Fact]
        public void NotNullOrWhiteSpace_WithNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.NotNullOrWhiteSpace(null, "s"));
            Assert.Equal("s", ex.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("\t")]
        [InlineData("\n")]
        public void NotNullOrWhiteSpace_WithEmptyOrWhitespace_ThrowsArgumentException(string badValue)
        {
            var ex = Assert.Throws<ArgumentException>(() => Guard.NotNullOrWhiteSpace(badValue, "s"));
            Assert.Equal("s", ex.ParamName);
        }

        #endregion

        #region NotNegative

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(int.MaxValue)]
        public void NotNegative_WithZeroOrPositive_ReturnsValue(int value)
        {
            var result = Guard.NotNegative(value, "n");
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(int.MinValue)]
        public void NotNegative_WithNegative_ThrowsArgumentOutOfRangeException(int value)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.NotNegative(value, "n"));
            Assert.Equal("n", ex.ParamName);
        }

        #endregion

        #region Positive

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(int.MaxValue)]
        public void Positive_WithPositiveValue_ReturnsValue(int value)
        {
            var result = Guard.Positive(value, "n");
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        public void Positive_WithZeroOrNegative_ThrowsArgumentOutOfRangeException(int value)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Positive(value, "n"));
            Assert.Equal("n", ex.ParamName);
        }

        #endregion

        #region InRange

        [Theory]
        [InlineData(0, 0, 10)]
        [InlineData(5, 0, 10)]
        [InlineData(10, 0, 10)]
        [InlineData(-5, -10, 0)]
        public void InRange_WithValueInRange_ReturnsValue(int value, int min, int max)
        {
            var result = Guard.InRange(value, min, max, "n");
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(-1, 0, 10)]
        [InlineData(11, 0, 10)]
        [InlineData(100, 0, 10)]
        public void InRange_WithValueOutsideRange_ThrowsArgumentOutOfRangeException(int value, int min, int max)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.InRange(value, min, max, "n"));
            Assert.Equal("n", ex.ParamName);
        }

        [Fact]
        public void InRange_WithInvalidBounds_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Guard.InRange(5, 10, 0, "n"));
        }

        #endregion

        #region NotNullOrEmpty (collections)

        [Fact]
        public void NotNullOrEmpty_Collection_WithElements_ReturnsCollection()
        {
            IEnumerable<int> col = new[] { 1, 2, 3 };
            var result = Guard.NotNullOrEmpty(col, "col");
            Assert.Same(col, result);
        }

        [Fact]
        public void NotNullOrEmpty_Collection_WithNull_ThrowsArgumentNullException()
        {
            IEnumerable<int>? col = null;
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.NotNullOrEmpty(col, "col"));
            Assert.Equal("col", ex.ParamName);
        }

        [Fact]
        public void NotNullOrEmpty_Collection_WithEmpty_ThrowsArgumentException()
        {
            IEnumerable<int> col = new int[0];
            var ex = Assert.Throws<ArgumentException>(() => Guard.NotNullOrEmpty(col, "col"));
            Assert.Equal("col", ex.ParamName);
        }

        #endregion

        #endregion
    }
}
