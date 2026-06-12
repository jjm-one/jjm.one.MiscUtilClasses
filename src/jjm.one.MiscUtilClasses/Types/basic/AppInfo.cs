using System;

namespace jjm.one.MiscUtilClasses.Types.basic;

/// <summary>
///     This class is a wrapper for basic information about an application.
/// </summary>
public class AppInfo : IEquatable<AppInfo>
{
    #region private constants

    private const string UnknownValue = "unknown";

    #endregion

    #region private helpers

    /// <summary>
    ///     Returns <see cref="UnknownValue" /> when <paramref name="value" /> is <c>null</c>,
    ///     empty, or whitespace-only; otherwise returns <paramref name="value" /> unchanged.
    /// </summary>
    /// <param name="value">The raw input string (may be <c>null</c>).</param>
    /// <returns>A guaranteed non-null, non-whitespace string.</returns>
    private static string Sanitize(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? UnknownValue : value!;
    }

    #endregion

    #region private fields

    private string _appName = UnknownValue;
    private string _appVersion = UnknownValue;
    private string _appBuildDate = UnknownValue;
    private string _appBuildTime = UnknownValue;
    private string _appRuntimeEnvironment = UnknownValue;

    #endregion

    #region public members

    /// <summary>
    ///     The name of the app.
    ///     Null, empty, or whitespace-only values are silently coerced to <c>"unknown"</c>.
    /// </summary>
    public string AppName
    {
        get => _appName;
        set => _appName = Sanitize(value);
    }

    /// <summary>
    ///     The version of the app.
    ///     Null, empty, or whitespace-only values are silently coerced to <c>"unknown"</c>.
    /// </summary>
    public string AppVersion
    {
        get => _appVersion;
        set => _appVersion = Sanitize(value);
    }

    /// <summary>
    ///     The build date of the app.
    ///     Null, empty, or whitespace-only values are silently coerced to <c>"unknown"</c>.
    /// </summary>
    public string AppBuildDate
    {
        get => _appBuildDate;
        set => _appBuildDate = Sanitize(value);
    }

    /// <summary>
    ///     The build time of the app.
    ///     Null, empty, or whitespace-only values are silently coerced to <c>"unknown"</c>.
    /// </summary>
    public string AppBuildTime
    {
        get => _appBuildTime;
        set => _appBuildTime = Sanitize(value);
    }

    /// <summary>
    ///     The runtime environment in which the app was started.
    ///     Null, empty, or whitespace-only values are silently coerced to <c>"unknown"</c>.
    /// </summary>
    public string AppRuntimeEnvironment
    {
        get => _appRuntimeEnvironment;
        set => _appRuntimeEnvironment = Sanitize(value);
    }

    #endregion

    #region ctor

    /// <summary>
    ///     Default constructor for the <see cref="AppInfo" /> class.
    ///     All fields are initialized to <c>"unknown"</c>.
    /// </summary>
    public AppInfo()
    {
    }

    /// <summary>
    ///     Constructor for the <see cref="AppInfo" /> class.
    ///     Any null, empty, or whitespace-only argument falls back to <c>"unknown"</c>.
    /// </summary>
    /// <param name="appName">The name of the app.</param>
    /// <param name="appVersion">The version of the app.</param>
    /// <param name="appBuildDate">The build date of the app.</param>
    /// <param name="appBuildTime">The build time of the app.</param>
    /// <param name="appRuntimeEnvironment">The runtime environment in which the app was started.</param>
    public AppInfo(string? appName, string? appVersion, string? appBuildDate, string? appBuildTime,
        string? appRuntimeEnvironment)
    {
        _appName = Sanitize(appName);
        _appVersion = Sanitize(appVersion);
        _appBuildDate = Sanitize(appBuildDate);
        _appBuildTime = Sanitize(appBuildTime);
        _appRuntimeEnvironment = Sanitize(appRuntimeEnvironment);
    }

    #endregion

    #region public override

    /// <summary>
    ///     Converts the information of the <see cref="AppInfo" /> object into a human readable string.
    ///     Format: <c>{AppName} [Version: {AppVersion} - {AppBuildDate} @ {AppBuildTime} | Env: {AppRuntimeEnvironment}]</c>
    /// </summary>
    /// <returns>A <see cref="string" /> containing the information of the <see cref="AppInfo" /> object.</returns>
    public override string ToString()
    {
        return $"{AppName} [Version: {AppVersion} - {AppBuildDate} @ {AppBuildTime} | Env: {AppRuntimeEnvironment}]";
    }

    /// <summary>
    ///     Determines whether the specified object is equal to this <see cref="AppInfo" /> instance.
    ///     Delegates to <see cref="Equals(AppInfo?)" /> after a safe cast.
    /// </summary>
    /// <param name="obj">The object to compare with this instance.</param>
    /// <returns>
    ///     <c>true</c> if <paramref name="obj" /> is an <see cref="AppInfo" /> whose five fields
    ///     all match those of this instance; otherwise <c>false</c>.
    /// </returns>
    public override bool Equals(object? obj)
    {
        return Equals(obj as AppInfo);
    }

    /// <summary>
    ///     Determines whether the specified <see cref="AppInfo" /> is equal to this instance.
    ///     Two instances are considered equal when all five string fields are identical
    ///     (ordinal, case-sensitive comparison).
    /// </summary>
    /// <param name="other">The <see cref="AppInfo" /> to compare with, or <c>null</c>.</param>
    /// <returns>
    ///     <c>true</c> if <paramref name="other" /> is not <c>null</c> and all five fields match;
    ///     otherwise <c>false</c>.
    /// </returns>
    public bool Equals(AppInfo? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _appName == other._appName
               && _appVersion == other._appVersion
               && _appBuildDate == other._appBuildDate
               && _appBuildTime == other._appBuildTime
               && _appRuntimeEnvironment == other._appRuntimeEnvironment;
    }

    /// <summary>
    ///     Returns a hash code for this <see cref="AppInfo" /> instance derived from all five fields.
    ///     Instances that are equal according to <see cref="Equals(AppInfo?)" /> always produce the
    ///     same hash code.
    /// </summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = hash * 31 + _appName.GetHashCode();
            hash = hash * 31 + _appVersion.GetHashCode();
            hash = hash * 31 + _appBuildDate.GetHashCode();
            hash = hash * 31 + _appBuildTime.GetHashCode();
            hash = hash * 31 + _appRuntimeEnvironment.GetHashCode();
            return hash;
        }
    }

    /// <summary>
    ///     Determines whether two <see cref="AppInfo" /> instances are equal.
    ///     Supports <c>null</c> operands: two <c>null</c> references are considered equal.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    /// <returns><c>true</c> if both instances are equal; otherwise <c>false</c>.</returns>
    public static bool operator ==(AppInfo? left, AppInfo? right)
    {
        return left is null ? right is null : left.Equals(right);
    }

    /// <summary>
    ///     Determines whether two <see cref="AppInfo" /> instances are not equal.
    ///     Supports <c>null</c> operands.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    /// <returns><c>true</c> if the instances differ; otherwise <c>false</c>.</returns>
    public static bool operator !=(AppInfo? left, AppInfo? right)
    {
        return !(left == right);
    }

    #endregion
}