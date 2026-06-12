using System;

namespace jjm.one.MiscUtilClasses.Types.basic
{
    /// <summary>
    /// This class is a wrapper for basic information about an application.
    /// </summary>
    public class AppInfo : IEquatable<AppInfo>
    {
        #region private constants

        private const string UnknownValue = "unknown";

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
        /// The name of the app.
        /// Null, empty, or whitespace-only values are silently coerced to <c>"unknown"</c>.
        /// </summary>
        public string AppName
        {
            get => _appName;
            set => _appName = Sanitize(value);
        }

        /// <summary>
        /// The version of the app.
        /// Null, empty, or whitespace-only values are silently coerced to <c>"unknown"</c>.
        /// </summary>
        public string AppVersion
        {
            get => _appVersion;
            set => _appVersion = Sanitize(value);
        }

        /// <summary>
        /// The build date of the app.
        /// Null, empty, or whitespace-only values are silently coerced to <c>"unknown"</c>.
        /// </summary>
        public string AppBuildDate
        {
            get => _appBuildDate;
            set => _appBuildDate = Sanitize(value);
        }

        /// <summary>
        /// The build time of the app.
        /// Null, empty, or whitespace-only values are silently coerced to <c>"unknown"</c>.
        /// </summary>
        public string AppBuildTime
        {
            get => _appBuildTime;
            set => _appBuildTime = Sanitize(value);
        }

        /// <summary>
        /// The runtime environment in which the app was started.
        /// Null, empty, or whitespace-only values are silently coerced to <c>"unknown"</c>.
        /// </summary>
        public string AppRuntimeEnvironment
        {
            get => _appRuntimeEnvironment;
            set => _appRuntimeEnvironment = Sanitize(value);
        }

        #endregion

        #region ctor

        /// <summary>
        /// Default constructor for the <see cref="AppInfo"/> class.
        /// All fields are initialized to <c>"unknown"</c>.
        /// </summary>
        public AppInfo() { }

        /// <summary>
        /// Constructor for the <see cref="AppInfo"/> class.
        /// Any null, empty, or whitespace-only argument falls back to <c>"unknown"</c>.
        /// </summary>
        /// <param name="appName">The name of the app.</param>
        /// <param name="appVersion">The version of the app.</param>
        /// <param name="appBuildDate">The build date of the app.</param>
        /// <param name="appBuildTime">The build time of the app.</param>
        /// <param name="appRuntimeEnvironment">The runtime environment in which the app was started.</param>
        public AppInfo(string? appName, string? appVersion, string? appBuildDate, string? appBuildTime, string? appRuntimeEnvironment)
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
        /// Converts the information of the <see cref="AppInfo"/> object into a human readable string.
        /// Format: <c>{AppName} [Version: {AppVersion} - {AppBuildDate} @ {AppBuildTime} | Env: {AppRuntimeEnvironment}]</c>
        /// </summary>
        /// <returns>A <see cref="string"/> containing the information of the <see cref="AppInfo"/> object.</returns>
        public override string ToString() =>
            $"{AppName} [Version: {AppVersion} - {AppBuildDate} @ {AppBuildTime} | Env: {AppRuntimeEnvironment}]";

        /// <inheritdoc/>
        public override bool Equals(object? obj) => Equals(obj as AppInfo);

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + _appName.GetHashCode();
                hash = hash * 31 + _appVersion.GetHashCode();
                hash = hash * 31 + _appBuildDate.GetHashCode();
                hash = hash * 31 + _appBuildTime.GetHashCode();
                hash = hash * 31 + _appRuntimeEnvironment.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Determines whether two <see cref="AppInfo"/> instances are equal.
        /// </summary>
        public static bool operator ==(AppInfo? left, AppInfo? right) =>
            left is null ? right is null : left.Equals(right);

        /// <summary>
        /// Determines whether two <see cref="AppInfo"/> instances are not equal.
        /// </summary>
        public static bool operator !=(AppInfo? left, AppInfo? right) => !(left == right);

        #endregion

        #region private helpers

        private static string Sanitize(string? value) =>
            string.IsNullOrWhiteSpace(value) ? UnknownValue : value!;

        #endregion
    }
}
