using jjm.one.MiscUtilClasses.Utilities;

namespace jjm.one.MiscUtilClasses.Tests.Utilities;

/// <summary>
///     This class contains the unit tests for the
///     <see cref="jjm.one.MiscUtilClasses.Utilities.Guard" /> class.
/// </summary>
public class GuardTests
{
    #region tests

    #region NotNull (reference types)

    /// <summary>
    ///     Verifies that <c>Guard.NotNull</c> returns the original value when a non-null string
    ///     is supplied.
    /// </summary>
    [Fact]
    public void NotNull_WithNonNullValue_ReturnsValue()
    {
        var result = Guard.NotNull("hello", "value");
        Assert.Equal("hello", result);
    }

    /// <summary>
    ///     Verifies that <c>Guard.NotNull</c> throws <see cref="ArgumentNullException" /> with
    ///     the correct parameter name when a null string reference is supplied.
    /// </summary>
    [Fact]
    public void NotNull_WithNullValue_ThrowsArgumentNullException()
    {
        string? value = null;
        ArgumentNullException ex =
            Assert.Throws<ArgumentNullException>(() => Guard.NotNull(value, "myParam"));
        Assert.Equal("myParam", ex.ParamName);
    }

    /// <summary>
    ///     Verifies that <c>Guard.NotNull</c> returns the exact same object reference when a
    ///     non-null object is supplied.
    /// </summary>
    [Fact]
    public void NotNull_WithNonNullObject_ReturnsObject()
    {
        var obj = new object();
        var result = Guard.NotNull(obj, "obj");
        Assert.Same(obj, result);
    }

    #endregion

    #region NotNullValue (nullable value types)

    /// <summary>
    ///     Verifies that <c>Guard.NotNullValue</c> unwraps and returns the inner value when the
    ///     nullable has a value.
    /// </summary>
    [Fact]
    public void NotNullValue_WithValue_ReturnsUnwrapped()
    {
        int? value = 42;
        var result = Guard.NotNullValue(value, "value");
        Assert.Equal(42, result);
    }

    /// <summary>
    ///     Verifies that <c>Guard.NotNullValue</c> throws <see cref="ArgumentNullException" />
    ///     with the correct parameter name when the nullable has no value.
    /// </summary>
    [Fact]
    public void NotNullValue_WithNull_ThrowsArgumentNullException()
    {
        int? value = null;
        ArgumentNullException ex =
            Assert.Throws<ArgumentNullException>(() => Guard.NotNullValue(value, "myParam"));
        Assert.Equal("myParam", ex.ParamName);
    }

    #endregion

    #region NotNullOrEmpty (string)

    /// <summary>
    ///     Verifies that <c>Guard.NotNullOrEmpty</c> returns the original string when a
    ///     non-null, non-empty value is supplied.
    /// </summary>
    [Fact]
    public void NotNullOrEmpty_WithValidString_ReturnsString()
    {
        var result = Guard.NotNullOrEmpty("hello", "s");
        Assert.Equal("hello", result);
    }

    /// <summary>
    ///     Verifies that <c>Guard.NotNullOrEmpty</c> throws <see cref="ArgumentNullException" />
    ///     with the correct parameter name when <c>null</c> is supplied.
    /// </summary>
    [Fact]
    public void NotNullOrEmpty_WithNull_ThrowsArgumentNullException()
    {
        ArgumentNullException ex =
            Assert.Throws<ArgumentNullException>(() => Guard.NotNullOrEmpty(null, "s"));
        Assert.Equal("s", ex.ParamName);
    }

    /// <summary>
    ///     Verifies that <c>Guard.NotNullOrEmpty</c> throws <see cref="ArgumentException" />
    ///     with the correct parameter name when an empty string is supplied.
    /// </summary>
    [Fact]
    public void NotNullOrEmpty_WithEmptyString_ThrowsArgumentException()
    {
        ArgumentException ex =
            Assert.Throws<ArgumentException>(() => Guard.NotNullOrEmpty("", "s"));
        Assert.Equal("s", ex.ParamName);
    }

    /// <summary>
    ///     Verifies that <c>Guard.NotNullOrEmpty</c> does NOT throw for a whitespace-only
    ///     string — whitespace is not empty, only <c>Guard.NotNullOrWhiteSpace</c> rejects it.
    /// </summary>
    [Fact]
    public void NotNullOrEmpty_WithWhitespace_DoesNotThrow()
    {
        // whitespace is NOT empty — only NotNullOrWhiteSpace catches it
        var result = Guard.NotNullOrEmpty("   ", "s");
        Assert.Equal("   ", result);
    }

    #endregion

    #region NotNullOrWhiteSpace (string)

    /// <summary>
    ///     Verifies that <c>Guard.NotNullOrWhiteSpace</c> returns the original string when a
    ///     non-null, non-whitespace value is supplied.
    /// </summary>
    [Fact]
    public void NotNullOrWhiteSpace_WithValidString_ReturnsString()
    {
        var result = Guard.NotNullOrWhiteSpace("hello", "s");
        Assert.Equal("hello", result);
    }

    /// <summary>
    ///     Verifies that <c>Guard.NotNullOrWhiteSpace</c> throws
    ///     <see cref="ArgumentNullException" /> with the correct parameter name when <c>null</c>
    ///     is supplied.
    /// </summary>
    [Fact]
    public void NotNullOrWhiteSpace_WithNull_ThrowsArgumentNullException()
    {
        ArgumentNullException ex =
            Assert.Throws<ArgumentNullException>(() => Guard.NotNullOrWhiteSpace(null, "s"));
        Assert.Equal("s", ex.ParamName);
    }

    /// <summary>
    ///     Verifies that <c>Guard.NotNullOrWhiteSpace</c> throws <see cref="ArgumentException" />
    ///     with the correct parameter name for empty strings and all common whitespace characters.
    /// </summary>
    /// <param name="badValue">The degenerate string value under test.</param>
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\n")]
    public void NotNullOrWhiteSpace_WithEmptyOrWhitespace_ThrowsArgumentException(string badValue)
    {
        ArgumentException ex =
            Assert.Throws<ArgumentException>(() => Guard.NotNullOrWhiteSpace(badValue, "s"));
        Assert.Equal("s", ex.ParamName);
    }

    #endregion

    #region NotNegative

    /// <summary>
    ///     Verifies that <c>Guard.NotNegative</c> returns the supplied value unchanged for zero
    ///     and all positive integers.
    /// </summary>
    /// <param name="value">The non-negative integer under test.</param>
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(int.MaxValue)]
    public void NotNegative_WithZeroOrPositive_ReturnsValue(int value)
    {
        var result = Guard.NotNegative(value, "n");
        Assert.Equal(value, result);
    }

    /// <summary>
    ///     Verifies that <c>Guard.NotNegative</c> throws
    ///     <see cref="ArgumentOutOfRangeException" /> with the correct parameter name for any
    ///     negative integer.
    /// </summary>
    /// <param name="value">The negative integer under test.</param>
    [Theory]
    [InlineData(-1)]
    [InlineData(-100)]
    [InlineData(int.MinValue)]
    public void NotNegative_WithNegative_ThrowsArgumentOutOfRangeException(int value)
    {
        ArgumentOutOfRangeException ex =
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.NotNegative(value, "n"));
        Assert.Equal("n", ex.ParamName);
    }

    #endregion

    #region Positive

    /// <summary>
    ///     Verifies that <c>Guard.Positive</c> returns the supplied value unchanged for any
    ///     strictly positive integer.
    /// </summary>
    /// <param name="value">The positive integer under test.</param>
    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(int.MaxValue)]
    public void Positive_WithPositiveValue_ReturnsValue(int value)
    {
        var result = Guard.Positive(value, "n");
        Assert.Equal(value, result);
    }

    /// <summary>
    ///     Verifies that <c>Guard.Positive</c> throws <see cref="ArgumentOutOfRangeException" />
    ///     with the correct parameter name for zero and all negative integers.
    /// </summary>
    /// <param name="value">The zero or negative integer under test.</param>
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void Positive_WithZeroOrNegative_ThrowsArgumentOutOfRangeException(int value)
    {
        ArgumentOutOfRangeException ex =
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Positive(value, "n"));
        Assert.Equal("n", ex.ParamName);
    }

    #endregion

    #region InRange

    /// <summary>
    ///     Verifies that <c>Guard.InRange</c> returns the supplied value unchanged when it lies
    ///     within the inclusive [min, max] range.
    /// </summary>
    /// <param name="value">The value under test.</param>
    /// <param name="min">The inclusive lower bound.</param>
    /// <param name="max">The inclusive upper bound.</param>
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

    /// <summary>
    ///     Verifies that <c>Guard.InRange</c> throws <see cref="ArgumentOutOfRangeException" />
    ///     with the correct parameter name when the value lies outside the inclusive [min, max]
    ///     range.
    /// </summary>
    /// <param name="value">The value under test.</param>
    /// <param name="min">The inclusive lower bound.</param>
    /// <param name="max">The inclusive upper bound.</param>
    [Theory]
    [InlineData(-1, 0, 10)]
    [InlineData(11, 0, 10)]
    [InlineData(100, 0, 10)]
    public void InRange_WithValueOutsideRange_ThrowsArgumentOutOfRangeException(int value, int min,
        int max)
    {
        ArgumentOutOfRangeException ex =
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.InRange(value, min, max, "n"));
        Assert.Equal("n", ex.ParamName);
    }

    /// <summary>
    ///     Verifies that <c>Guard.InRange</c> throws <see cref="ArgumentException" /> when
    ///     <c>min</c> is greater than <c>max</c>, which constitutes an invalid range
    ///     specification.
    /// </summary>
    [Fact]
    public void InRange_WithInvalidBounds_ThrowsArgumentException() =>
        Assert.Throws<ArgumentException>(() => Guard.InRange(5, 10, 0, "n"));

    #endregion

    #region NotNullOrEmpty (collections)

    /// <summary>
    ///     Verifies that <c>Guard.NotNullOrEmpty</c> returns the original collection reference
    ///     when the collection is non-null and contains elements.
    /// </summary>
    [Fact]
    public void NotNullOrEmpty_Collection_WithElements_ReturnsCollection()
    {
        IEnumerable<int> col = new[] { 1, 2, 3 };
        IEnumerable<int> result = Guard.NotNullOrEmpty(col, "col");
        Assert.Same(col, result);
    }

    /// <summary>
    ///     Verifies that <c>Guard.NotNullOrEmpty</c> throws <see cref="ArgumentNullException" />
    ///     with the correct parameter name when a null collection is supplied.
    /// </summary>
    [Fact]
    public void NotNullOrEmpty_Collection_WithNull_ThrowsArgumentNullException()
    {
        IEnumerable<int>? col = null;
        ArgumentNullException ex =
            Assert.Throws<ArgumentNullException>(() => Guard.NotNullOrEmpty(col, "col"));
        Assert.Equal("col", ex.ParamName);
    }

    /// <summary>
    ///     Verifies that <c>Guard.NotNullOrEmpty</c> throws <see cref="ArgumentException" />
    ///     with the correct parameter name when an empty collection is supplied.
    /// </summary>
    [Fact]
    public void NotNullOrEmpty_Collection_WithEmpty_ThrowsArgumentException()
    {
        IEnumerable<int> col = new int[0];
        ArgumentException ex =
            Assert.Throws<ArgumentException>(() => Guard.NotNullOrEmpty(col, "col"));
        Assert.Equal("col", ex.ParamName);
    }

    #endregion

    #endregion
}
