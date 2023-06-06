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
        public string AppName = string.Empty;

        /// <summary>
        /// The version of the app.
        /// </summary>
        public string AppVersion = string.Empty;

        /// <summary>
        /// The build date of the app.
        /// </summary>
        public string AppBuildDate = string.Empty;

        /// <summary>
        /// The build time of the app.
        /// </summary>
        public string AppBuildTime = string.Empty;

        /// <summary>
        /// The runtime environment in which the app was started.
        /// </summary>
        public string AppRuntimeEnvironment = string.Empty;

        #endregion

        #region ctor

        /// <summary>
        /// Default constructor for the <see cref="AppInfo"/> class.
        /// </summary>
        public AppInfo()
		{
            ;
		}

        /// <summary>
        /// A constructor for the <see cref="AppInfo"/> class.
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="appVersion"></param>
        /// <param name="appBuildDate"></param>
        /// <param name="appBuildTime"></param>
        /// <param name="appRuntimeEnvironment"></param>
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
    }
}

