using System;
using jjm.one.MiscUtilClasses.Extensions;

namespace jjm.one.MiscUtilClasses.Tests.Extensions;

/// <summary>
///     This class contains the unit tests for the <see cref="StringExtensions" /> class.
/// </summary>
public class StringExtensionsTests
{
    #region tests

    #region OrDefault

    [Theory]
    [InlineData(null, "fallback", "fallback")]
    [InlineData("", "fallback", "fallback")]
    [InlineData("   ", "fallback", "fallback")]
    [InlineData("\t", "fallback", "fallback")]
    [InlineData("hello", "fallback", "hello")]
    [InlineData("  hi ", "fallback", "  hi ")]
    public void OrDefault_ReturnsExpected(string? value, string defaultValue, string expected)
    {
        Assert.Equal(expected, value.OrDefault(defaultValue));
    }

    [Fact]
    public void OrDefault_NullDefault_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => "hello".OrDefault(null!));
    }

    #endregion

    #region Truncate

    [Theory]
    [InlineData("hello", 10, "hello")] // shorter than max
    [InlineData("hello", 5, "hello")] // exact length
    [InlineData("hello", 3, "hel")] // truncated
    [InlineData("hello", 0, "")] // zero → empty
    [InlineData("", 5, "")] // empty stays empty
    public void Truncate_ReturnsExpected(string value, int maxLength, string expected)
    {
        Assert.Equal(expected, value.Truncate(maxLength));
    }

    [Fact]
    public void Truncate_NullString_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ((string)null!).Truncate(5));
    }

    [Fact]
    public void Truncate_NegativeMaxLength_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => "hello".Truncate(-1));
    }

    #endregion

    #region Repeat

    [Theory]
    [InlineData("ab", 3, "ababab")]
    [InlineData("x", 1, "x")]
    [InlineData("x", 0, "")] // zero repetitions → empty
    [InlineData("", 5, "")] // empty string → always empty
    [InlineData("hi", 2, "hihi")]
    public void Repeat_ReturnsExpected(string value, int count, string expected)
    {
        Assert.Equal(expected, value.Repeat(count));
    }

    [Fact]
    public void Repeat_NullString_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ((string)null!).Repeat(3));
    }

    [Fact]
    public void Repeat_NegativeCount_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => "x".Repeat(-1));
    }

    #endregion

    #region ContainsIgnoreCase

    [Theory]
    [InlineData("Hello World", "hello", true)]
    [InlineData("Hello World", "WORLD", true)]
    [InlineData("Hello World", "lo Wo", true)]
    [InlineData("Hello World", "xyz", false)]
    [InlineData("Hello World", "", true)] // empty substring is always found
    [InlineData("", "", true)]
    public void ContainsIgnoreCase_ReturnsExpected(string value, string substring, bool expected)
    {
        Assert.Equal(expected, value.ContainsIgnoreCase(substring));
    }

    [Fact]
    public void ContainsIgnoreCase_NullValue_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ((string)null!).ContainsIgnoreCase("x"));
    }

    [Fact]
    public void ContainsIgnoreCase_NullSubstring_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => "hello".ContainsIgnoreCase(null!));
    }

    #endregion

    #region EqualsAnyIgnoreCase

    [Theory]
    [InlineData("hello", true, "HELLO")]
    [InlineData("hello", true, "world", "HELLO")]
    [InlineData("hello", true, "Hello")]
    [InlineData("hello", false, "world")]
    [InlineData("hello", false, "he", "ello")]
    public void EqualsAnyIgnoreCase_ReturnsExpected(string value, bool expected, params string[] candidates)
    {
        Assert.Equal(expected, value.EqualsAnyIgnoreCase(candidates));
    }

    [Fact]
    public void EqualsAnyIgnoreCase_NoCandidates_ReturnsFalse()
    {
        Assert.False("hello".EqualsAnyIgnoreCase());
    }

    [Fact]
    public void EqualsAnyIgnoreCase_NullValue_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ((string)null!).EqualsAnyIgnoreCase("x"));
    }

    [Fact]
    public void EqualsAnyIgnoreCase_NullCandidates_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => "hello".EqualsAnyIgnoreCase(null!));
    }

    #endregion

    #region SplitAndTrim

    [Fact]
    public void SplitAndTrim_TypicalInput_SplitsAndTrims()
    {
        var result = "  hello , world , foo  ".SplitAndTrim(',');
        Assert.Equal(new[] { "hello", "world", "foo" }, result);
    }

    [Fact]
    public void SplitAndTrim_NoSeparator_ReturnsSingleElement()
    {
        var result = "hello".SplitAndTrim(',');
        Assert.Single(result);
        Assert.Equal("hello", result[0]);
    }

    [Fact]
    public void SplitAndTrim_EmptySegmentsAreRemoved()
    {
        var result = "a,,b".SplitAndTrim(',');
        Assert.Equal(new[] { "a", "b" }, result);
    }

    [Fact]
    public void SplitAndTrim_WhitespaceOnlySegmentsAreRemoved()
    {
        var result = "a,   ,b".SplitAndTrim(',');
        Assert.Equal(new[] { "a", "b" }, result);
    }

    [Fact]
    public void SplitAndTrim_EmptyInput_ReturnsEmptyArray()
    {
        var result = "".SplitAndTrim(',');
        Assert.Empty(result);
    }

    [Fact]
    public void SplitAndTrim_NullValue_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ((string)null!).SplitAndTrim(','));
    }

    #endregion

    #endregion
}