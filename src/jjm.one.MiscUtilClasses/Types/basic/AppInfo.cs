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

        #endregion
    }
}

