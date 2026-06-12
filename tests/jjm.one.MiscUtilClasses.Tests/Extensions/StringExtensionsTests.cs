using jjm.one.MiscUtilClasses.Extensions;

namespace jjm.one.MiscUtilClasses.Tests.Extensions;

/// <summary>
///     This class contains the unit tests for the <see cref="StringExtensions" /> class.
/// </summary>
public class StringExtensionsTests
{
    #region tests

    #region OrDefault

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.OrDefault" /> returns the fallback value
    ///     for null, empty, and whitespace-only inputs, and returns the original string otherwise.
    /// </summary>
    /// <param name="value">The input string under test (may be null).</param>
    /// <param name="defaultValue">The fallback value to use when <paramref name="value" /> is blank.</param>
    /// <param name="expected">The expected return value.</param>
    [Theory]
    [InlineData(null, "fallback", "fallback")]
    [InlineData("", "fallback", "fallback")]
    [InlineData("   ", "fallback", "fallback")]
    [InlineData("\t", "fallback", "fallback")]
    [InlineData("hello", "fallback", "hello")]
    [InlineData("  hi ", "fallback", "  hi ")]
    public void OrDefault_ReturnsExpected(string? value, string defaultValue, string expected) =>
        Assert.Equal(expected, value.OrDefault(defaultValue));

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.OrDefault" /> throws
    ///     <see cref="ArgumentNullException" /> when the supplied default value is <c>null</c>.
    /// </summary>
    [Fact]
    public void OrDefault_NullDefault_ThrowsArgumentNullException() =>
        Assert.Throws<ArgumentNullException>(() => "hello".OrDefault(null!));

    #endregion

    #region Truncate

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.Truncate" /> returns the original string
    ///     when it is shorter than or equal to the limit, and returns the trimmed prefix otherwise.
    /// </summary>
    /// <param name="value">The input string under test.</param>
    /// <param name="maxLength">The maximum allowed length.</param>
    /// <param name="expected">The expected return value.</param>
    [Theory]
    [InlineData("hello", 10, "hello")] // shorter than max
    [InlineData("hello", 5, "hello")] // exact length
    [InlineData("hello", 3, "hel")] // truncated
    [InlineData("hello", 0, "")] // zero → empty
    [InlineData("", 5, "")] // empty stays empty
    public void Truncate_ReturnsExpected(string value, int maxLength, string expected) =>
        Assert.Equal(expected, value.Truncate(maxLength));

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.Truncate" /> throws
    ///     <see cref="ArgumentNullException" /> when the source string is <c>null</c>.
    /// </summary>
    [Fact]
    public void Truncate_NullString_ThrowsArgumentNullException() =>
        Assert.Throws<ArgumentNullException>(() => ((string)null!).Truncate(5));

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.Truncate" /> throws
    ///     <see cref="ArgumentOutOfRangeException" /> when <c>maxLength</c> is negative.
    /// </summary>
    [Fact]
    public void Truncate_NegativeMaxLength_ThrowsArgumentOutOfRangeException() =>
        Assert.Throws<ArgumentOutOfRangeException>(() => "hello".Truncate(-1));

    #endregion

    #region Repeat

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.Repeat" /> correctly concatenates the
    ///     string the requested number of times, including the edge cases of zero repetitions
    ///     and an empty source string.
    /// </summary>
    /// <param name="value">The string to repeat.</param>
    /// <param name="count">The number of repetitions.</param>
    /// <param name="expected">The expected concatenated result.</param>
    [Theory]
    [InlineData("ab", 3, "ababab")]
    [InlineData("x", 1, "x")]
    [InlineData("x", 0, "")] // zero repetitions → empty
    [InlineData("", 5, "")] // empty string → always empty
    [InlineData("hi", 2, "hihi")]
    public void Repeat_ReturnsExpected(string value, int count, string expected) =>
        Assert.Equal(expected, value.Repeat(count));

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.Repeat" /> throws
    ///     <see cref="ArgumentNullException" /> when the source string is <c>null</c>.
    /// </summary>
    [Fact]
    public void Repeat_NullString_ThrowsArgumentNullException() =>
        Assert.Throws<ArgumentNullException>(() => ((string)null!).Repeat(3));

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.Repeat" /> throws
    ///     <see cref="ArgumentOutOfRangeException" /> when <c>count</c> is negative.
    /// </summary>
    [Fact]
    public void Repeat_NegativeCount_ThrowsArgumentOutOfRangeException() =>
        Assert.Throws<ArgumentOutOfRangeException>(() => "x".Repeat(-1));

    #endregion

    #region ContainsIgnoreCase

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.ContainsIgnoreCase" /> correctly detects
    ///     substrings regardless of case, and returns <c>false</c> for absent substrings.
    /// </summary>
    /// <param name="value">The string to search in.</param>
    /// <param name="substring">The substring to look for.</param>
    /// <param name="expected">The expected result.</param>
    [Theory]
    [InlineData("Hello World", "hello", true)]
    [InlineData("Hello World", "WORLD", true)]
    [InlineData("Hello World", "lo Wo", true)]
    [InlineData("Hello World", "xyz", false)]
    [InlineData("Hello World", "", true)] // empty substring is always found
    [InlineData("", "", true)]
    public void ContainsIgnoreCase_ReturnsExpected(string value, string substring, bool expected) =>
        Assert.Equal(expected, value.ContainsIgnoreCase(substring));

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.ContainsIgnoreCase" /> throws
    ///     <see cref="ArgumentNullException" /> when the source string is <c>null</c>.
    /// </summary>
    [Fact]
    public void ContainsIgnoreCase_NullValue_ThrowsArgumentNullException() =>
        Assert.Throws<ArgumentNullException>(() => ((string)null!).ContainsIgnoreCase("x"));

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.ContainsIgnoreCase" /> throws
    ///     <see cref="ArgumentNullException" /> when the substring argument is <c>null</c>.
    /// </summary>
    [Fact]
    public void ContainsIgnoreCase_NullSubstring_ThrowsArgumentNullException() =>
        Assert.Throws<ArgumentNullException>(() => "hello".ContainsIgnoreCase(null!));

    #endregion

    #region EqualsAnyIgnoreCase

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.EqualsAnyIgnoreCase" /> returns <c>true</c>
    ///     when the source string matches any candidate (case-insensitive), and <c>false</c>
    ///     when no candidate matches.
    /// </summary>
    /// <param name="value">The string to compare.</param>
    /// <param name="expected">The expected result.</param>
    /// <param name="candidates">The set of candidate strings to compare against.</param>
    [Theory]
    [InlineData("hello", true, "HELLO")]
    [InlineData("hello", true, "world", "HELLO")]
    [InlineData("hello", true, "Hello")]
    [InlineData("hello", false, "world")]
    [InlineData("hello", false, "he", "ello")]
    public void EqualsAnyIgnoreCase_ReturnsExpected(string value, bool expected,
        params string[] candidates) =>
        Assert.Equal(expected, value.EqualsAnyIgnoreCase(candidates));

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.EqualsAnyIgnoreCase" /> returns <c>false</c>
    ///     when no candidates are provided.
    /// </summary>
    [Fact]
    public void EqualsAnyIgnoreCase_NoCandidates_ReturnsFalse() =>
        Assert.False("hello".EqualsAnyIgnoreCase());

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.EqualsAnyIgnoreCase" /> throws
    ///     <see cref="ArgumentNullException" /> when the source string is <c>null</c>.
    /// </summary>
    [Fact]
    public void EqualsAnyIgnoreCase_NullValue_ThrowsArgumentNullException() =>
        Assert.Throws<ArgumentNullException>(() => ((string)null!).EqualsAnyIgnoreCase("x"));

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.EqualsAnyIgnoreCase" /> throws
    ///     <see cref="ArgumentNullException" /> when the candidates array is <c>null</c>.
    /// </summary>
    [Fact]
    public void EqualsAnyIgnoreCase_NullCandidates_ThrowsArgumentNullException() =>
        Assert.Throws<ArgumentNullException>(() => "hello".EqualsAnyIgnoreCase(null!));

    #endregion

    #region SplitAndTrim

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.SplitAndTrim" /> splits on the separator,
    ///     trims leading and trailing whitespace from each segment, and returns only non-empty segments.
    /// </summary>
    [Fact]
    public void SplitAndTrim_TypicalInput_SplitsAndTrims()
    {
        var result = "  hello , world , foo  ".SplitAndTrim(',');
        Assert.Equal(new[] { "hello", "world", "foo" }, result);
    }

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.SplitAndTrim" /> returns a single-element
    ///     array when the separator is not present in the input.
    /// </summary>
    [Fact]
    public void SplitAndTrim_NoSeparator_ReturnsSingleElement()
    {
        var result = "hello".SplitAndTrim(',');
        Assert.Single(result);
        Assert.Equal("hello", result[0]);
    }

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.SplitAndTrim" /> removes segments that
    ///     become empty after the split (i.e., consecutive separators).
    /// </summary>
    [Fact]
    public void SplitAndTrim_EmptySegmentsAreRemoved()
    {
        var result = "a,,b".SplitAndTrim(',');
        Assert.Equal(new[] { "a", "b" }, result);
    }

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.SplitAndTrim" /> removes segments that
    ///     consist entirely of whitespace after trimming.
    /// </summary>
    [Fact]
    public void SplitAndTrim_WhitespaceOnlySegmentsAreRemoved()
    {
        var result = "a,   ,b".SplitAndTrim(',');
        Assert.Equal(new[] { "a", "b" }, result);
    }

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.SplitAndTrim" /> returns an empty array
    ///     when the input string is empty.
    /// </summary>
    [Fact]
    public void SplitAndTrim_EmptyInput_ReturnsEmptyArray()
    {
        var result = "".SplitAndTrim(',');
        Assert.Empty(result);
    }

    /// <summary>
    ///     Verifies that <see cref="StringExtensions.SplitAndTrim" /> throws
    ///     <see cref="ArgumentNullException" /> when the source string is <c>null</c>.
    /// </summary>
    [Fact]
    public void SplitAndTrim_NullValue_ThrowsArgumentNullException() =>
        Assert.Throws<ArgumentNullException>(() => ((string)null!).SplitAndTrim(','));

    #endregion

    #endregion
}
