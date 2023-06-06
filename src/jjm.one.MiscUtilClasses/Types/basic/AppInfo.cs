using System;

namespace jjm.one.MiscUtilClasses.Types.basic
{
    /// <summary>
    /// This class is a wrapper for basic information about an application.
    /// </summary>
    public class AppInfo
	{
        #region public members

        /// <summary>
        /// The name of the app.
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// The version of the app.
        /// </summary>
        public string AppVersion { get; set; }
        /// <summary>
        /// The build date of the app.
        /// </summary>
        public string AppBuildDate { get; set; }

        /// <summary>
        /// The build time of the app.
        /// </summary>
        public string AppBuildTime { get; set; }

        /// <summary>
        /// The runtime environment in which the app was started.
        /// </summary>
        public string AppRuntimeEnvironment { get; set; }

        #endregion

        #region ctor

        /// <summary>
        /// Default constructor for the <see cref="AppInfo"/> class.
        /// </summary>
        public AppInfo()
		{
            AppName = @"unknown";
            AppVersion = @"unknown";
            AppBuildDate = @"unknown";
            AppBuildTime = @"unknown";
            AppRuntimeEnvironment = @"unknown";
        }

        /// <summary>
        /// A constructor for the <see cref="AppInfo"/> class.
        /// </summary>
        /// <param name="appName">The name of the app.</param>
        /// <param name="appVersion">The version of the app.</param>
        /// <param name="appBuildDate">The build date of the app.</param>
        /// <param name="appBuildTime">The build time of the app.</param>
        /// <param name="appRuntimeEnvironment">The runtime environment in which the app was started.</param>
        public AppInfo(string? appName, string? appVersion, string? appBuildDate, string? appBuildTime, string? appRuntimeEnvironment)
        {
            // set app name
            AppName = (appName is null || string.IsNullOrEmpty(appName)) ?
                @"unknown" :
                appName;

            // set app version
            AppVersion = (appVersion is null || string.IsNullOrEmpty(appVersion)) ?
                @"unknown" :
                appVersion;

            // set app build date
            AppBuildDate = (appBuildDate is null || string.IsNullOrEmpty(appBuildDate)) ?
                @"unknown" :
                appBuildDate;

            // set app build time 
            AppBuildTime = (appBuildTime is null || string.IsNullOrEmpty(appBuildTime)) ?
                @"unknown" :
                appBuildTime;

            // set app name
            AppRuntimeEnvironment = (appRuntimeEnvironment is null || string.IsNullOrEmpty(appRuntimeEnvironment)) ?
                @"unknown" :
                appRuntimeEnvironment;
        }

        #endregion

        #region public override

        /// <summary>
        /// Converts the information of the <see cref="AppInfo"/> object into a human readable string.
        /// The following pattern gets used:
        /// {AppName} [Version: {AppVersion} - {AppBuildDate} @ {AppBuildTime} | Env: {AppRuntimeEnvironment}]
        /// </summary>
        /// <returns>A <see cref="string"/> containing the infromation of the <see cref="AppInfo"/> object.</returns>
        public override string ToString()
        {
            return $"{AppName} [Version: {AppVersion} - {AppBuildDate} @ {AppBuildTime} | Env: {AppRuntimeEnvironment}]";
        }

        #endregion
    }
}

