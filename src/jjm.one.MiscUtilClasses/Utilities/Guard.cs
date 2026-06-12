using System;
using System.Collections.Generic;

namespace jjm.one.MiscUtilClasses.Utilities;

/// <summary>
///     Provides static guard clauses for validating arguments at method entry points.
///     Each method returns the validated value so it can be used inline in assignments.
/// </summary>
public static class Guard
{
    #region reference type guards

    /// <summary>
    ///     Throws <see cref="ArgumentNullException" /> if <paramref name="value" /> is <c>null</c>.
    /// </summary>
    /// <typeparam name="T">Any reference type.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="paramName">The parameter name used in the exception message.</param>
    /// <returns><paramref name="value" /> when it is not null.</returns>
    public static T NotNull<T>(T? value, string paramName) where T : class
    {
        if (value is null)
            throw new ArgumentNullException(paramName);
        return value;
    }

    #endregion

    #region nullable value type guards

    /// <summary>
    ///     Throws <see cref="ArgumentNullException" /> if <paramref name="value" /> has no value.
    /// </summary>
    /// <typeparam name="T">Any value type.</typeparam>
    /// <param name="value">The nullable value to check.</param>
    /// <param name="paramName">The parameter name used in the exception message.</param>
    /// <returns>The unwrapped value when it is not null.</returns>
    public static T NotNullValue<T>(T? value, string paramName) where T : struct
    {
        if (!value.HasValue)
            throw new ArgumentNullException(paramName);
        return value.Value;
    }

    #endregion

    #region collection guards

    /// <summary>
    ///     Throws if <paramref name="collection" /> is <c>null</c> or contains no elements.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="collection">The collection to check.</param>
    /// <param name="paramName">The parameter name used in the exception message.</param>
    /// <returns><paramref name="collection" /> when it is not null or empty.</returns>
    public static IEnumerable<T> NotNullOrEmpty<T>(IEnumerable<T>? collection, string paramName)
    {
        if (collection is null)
            throw new ArgumentNullException(paramName);

        using (var enumerator = collection.GetEnumerator())
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException("Collection must not be empty.", paramName);
        }

        return collection;
    }

    #endregion

    #region string guards

    /// <summary>
    ///     Throws if <paramref name="value" /> is <c>null</c> or empty.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="paramName">The parameter name used in the exception message.</param>
    /// <returns><paramref name="value" /> when it is not null or empty.</returns>
    public static string NotNullOrEmpty(string? value, string paramName)
    {
        if (value is null)
            throw new ArgumentNullException(paramName);
        if (value.Length == 0)
            throw new ArgumentException("Value must not be empty.", paramName);
        return value;
    }

    /// <summary>
    ///     Throws if <paramref name="value" /> is <c>null</c>, empty, or whitespace-only.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="paramName">The parameter name used in the exception message.</param>
    /// <returns><paramref name="value" /> when it is not null, empty, or whitespace.</returns>
    public static string NotNullOrWhiteSpace(string? value, string paramName)
    {
        if (value is null)
            throw new ArgumentNullException(paramName);
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Value must not be empty or whitespace.", paramName);
        return value;
    }

    #endregion

    #region numeric guards

    /// <summary>
    ///     Throws <see cref="ArgumentOutOfRangeException" /> if <paramref name="value" /> is negative.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="paramName">The parameter name used in the exception message.</param>
    /// <returns><paramref name="value" /> when it is zero or positive.</returns>
    public static int NotNegative(int value, string paramName)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(paramName, value, "Value must not be negative.");
        return value;
    }

    /// <summary>
    ///     Throws <see cref="ArgumentOutOfRangeException" /> if <paramref name="value" /> is not strictly positive (i.e., &lt;
    ///     = 0).
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="paramName">The parameter name used in the exception message.</param>
    /// <returns><paramref name="value" /> when it is greater than zero.</returns>
    public static int Positive(int value, string paramName)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(paramName, value, "Value must be positive.");
        return value;
    }

    /// <summary>
    ///     Throws <see cref="ArgumentOutOfRangeException" /> if <paramref name="value" /> lies outside [
    ///     <paramref name="min" />, <paramref name="max" />].
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="min">The inclusive lower bound.</param>
    /// <param name="max">The inclusive upper bound.</param>
    /// <param name="paramName">The parameter name used in the exception message.</param>
    /// <returns><paramref name="value" /> when it is within the specified range.</returns>
    public static int InRange(int value, int min, int max, string paramName)
    {
        if (min > max)
            throw new ArgumentException($"min ({min}) must not be greater than max ({max}).", nameof(min));
        if (value < min || value > max)
            throw new ArgumentOutOfRangeException(paramName, value,
                $"Value must be between {min} and {max} (inclusive).");
        return value;
    }

    #endregion
}