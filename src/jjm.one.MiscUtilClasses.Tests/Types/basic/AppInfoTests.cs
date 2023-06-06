using jjm.one.MiscUtilClasses.Types.basic;

namespace jjm.one.MiscUtilClasses.Tests.Types.basic
{
	/// <summary>
	/// This class contains the unit tests for the <see cref="AppInfo"/> class.
	/// </summary>
	public class AppInfoTests
	{
		#region Test "ctor"

        /// <summary>
        /// 1. test of the default ctos.
        /// </summary>
		[Fact]
		public void CtorTest1()
		{
			var appInfo = new AppInfo();

            Assert.Equal("unknown", appInfo.AppName);
            Assert.Equal("unknown", appInfo.AppVersion);
            Assert.Equal("unknown", appInfo.AppBuildDate);
            Assert.Equal("unknown", appInfo.AppBuildTime);
            Assert.Equal("unknown", appInfo.AppRuntimeEnvironment);
        }

        /// <summary>
        /// 2. test of the default ctor.
        /// </summary>
        [Fact]
        public void CtorTest2()
        {
            var appInfo = new AppInfo
            {
                AppName = "A",
                AppVersion = "B",
                AppBuildDate = "C",
                AppBuildTime = "D",
                AppRuntimeEnvironment = "E"
            };

            Assert.Equal("A", appInfo.AppName);
            Assert.Equal("B", appInfo.AppVersion);
            Assert.Equal("C", appInfo.AppBuildDate);
            Assert.Equal("D", appInfo.AppBuildTime);
            Assert.Equal("E", appInfo.AppRuntimeEnvironment);
        }

        /// <summary>
        /// 1. test of the additional ctor.
        /// </summary>
        [Fact]
        public void CtorTest3()
        {
            var appInfo = new AppInfo(
                appName: "A",
                appVersion: "B",
                appBuildDate: "C",
                appBuildTime: "D",
                appRuntimeEnvironment: "E"
            );

            Assert.Equal("A", appInfo.AppName);
            Assert.Equal("B", appInfo.AppVersion);
            Assert.Equal("C", appInfo.AppBuildDate);
            Assert.Equal("D", appInfo.AppBuildTime);
            Assert.Equal("E", appInfo.AppRuntimeEnvironment);
        }

        #endregion

        #region Test "ToString() method"

        /// <summary>
        /// 1. test of the "ToString()" method.
        /// </summary>
        [Fact]
		public void ToStringTest1()
		{
			var appInfo = new AppInfo();

			Assert.Equal("unknown [Version: unknown - unknown @ unknown | Env: unknown]", appInfo.ToString());
		}

		/// <summary>
		/// 2. test of the "ToString()" method.
		/// </summary>
        [Fact]
        public void ToStringTest2()
        {
			var appInfo = new AppInfo
			{
				AppName = "A",
				AppVersion = "B",
				AppBuildDate = "C",
				AppBuildTime = "D",
				AppRuntimeEnvironment = "E"
			};

            Assert.Equal("A [Version: B - C @ D | Env: E]", appInfo.ToString());
        }

        #endregion
    }
}
