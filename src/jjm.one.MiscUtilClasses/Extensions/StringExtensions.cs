using System.Text;

namespace jjm.one.MiscUtilClasses.Extensions;

/// <summary>
///     Extension methods for <see cref="string" />.
/// </summary>
public static class StringExtensions
{
    #region null / empty helpers

    /// <summary>
    ///     Returns <paramref name="defaultValue" /> when <paramref name="value" /> is null, empty, or
    ///     whitespace-only; otherwise returns <paramref name="value" /> unchanged.
    /// </summary>
    /// <param name="value">The source string (may be null).</param>
    /// <param name="defaultValue">The fallback value.</param>
    /// <returns>The original value or the default.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="defaultValue" /> is null.</exception>
    public static string OrDefault(this string? value, string defaultValue)
    {
        if (defaultValue is null)
        {
            throw new ArgumentNullException(nameof(defaultValue));
        }

        return string.IsNullOrWhiteSpace(value) ? defaultValue : value!;
    }

    #endregion

    #region split helpers

    /// <summary>
    ///     Splits the string by <paramref name="separator" />, trims whitespace from each segment,
    ///     and removes empty entries.
    /// </summary>
    /// <param name="value">The source string.</param>
    /// <param name="separator">The character to split on.</param>
    /// <returns>An array of non-empty, trimmed segments.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value" /> is null.</exception>
    public static string[] SplitAndTrim(this string value, char separator)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        var parts = value.Split(separator);
        var result = new List<string>(parts.Length);
        foreach (var part in parts)
        {
            var trimmed = part.Trim();
            if (trimmed.Length > 0)
            {
                result.Add(trimmed);
            }
        }

        return result.ToArray();
    }

    #endregion

    #region truncation and repetition

    /// <summary>
    ///     Truncates the string to at most <paramref name="maxLength" /> characters.
    /// </summary>
    /// <param name="value">The source string.</param>
    /// <param name="maxLength">The maximum allowed length (inclusive).</param>
    /// <returns>
    ///     The original string when it is not longer than <paramref name="maxLength" />;
    ///     otherwise the first <paramref name="maxLength" /> characters.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value" /> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown when <paramref name="maxLength" /> is
    ///     negative.
    /// </exception>
    public static string Truncate(this string value, int maxLength)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (maxLength < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxLength), maxLength,
                "maxLength must be non-negative.");
        }

        return value.Length <= maxLength ? value : value.Substring(0, maxLength);
    }

    /// <summary>
    ///     Repeats the string <paramref name="count" /> times.
    /// </summary>
    /// <param name="value">The source string.</param>
    /// <param name="count">The number of repetitions.</param>
    /// <returns>
    ///     A new string that consists of <paramref name="value" /> repeated <paramref name="count" />
    ///     times.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value" /> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="count" /> is negative.</exception>
    public static string Repeat(this string value, int count)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), count,
                "count must be non-negative.");
        }

        if (count == 0 || value.Length == 0)
        {
            return string.Empty;
        }

        var sb = new StringBuilder(value.Length * count);
        for (var i = 0; i < count; i++)
        {
            sb.Append(value);
        }

        return sb.ToString();
    }

    #endregion

    #region search helpers

    /// <summary>
    ///     Returns <c>true</c> when <paramref name="value" /> contains <paramref name="substring" />
    ///     using a case-insensitive ordinal comparison.
    /// </summary>
    /// <param name="value">The string to search in.</param>
    /// <param name="substring">The substring to look for.</param>
    /// <returns><c>true</c> if found; otherwise <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when either argument is null.</exception>
    public static bool ContainsIgnoreCase(this string value, string substring)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (substring is null)
        {
            throw new ArgumentNullException(nameof(substring));
        }

        return value.IndexOf(substring, StringComparison.OrdinalIgnoreCase) >= 0;
    }

    /// <summary>
    ///     Returns <c>true</c> when <paramref name="value" /> equals any of the
    ///     <paramref name="candidates" />
    ///     using a case-insensitive ordinal comparison.
    /// </summary>
    /// <param name="value">The string to compare.</param>
    /// <param name="candidates">One or more strings to compare against.</param>
    /// <returns><c>true</c> if a match is found; otherwise <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="value" /> or <paramref name="candidates" /> is
    ///     null.
    /// </exception>
    public static bool EqualsAnyIgnoreCase(this string value, params string[] candidates)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (candidates is null)
        {
            throw new ArgumentNullException(nameof(candidates));
        }

        foreach (var candidate in candidates)
        {
            if (string.Equals(value, candidate, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    #endregion
}
