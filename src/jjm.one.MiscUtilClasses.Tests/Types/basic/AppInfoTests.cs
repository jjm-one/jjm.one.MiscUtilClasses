using jjm.one.MiscUtilClasses.Types.basic;

namespace jjm.one.MiscUtilClasses.Tests.Types.basic
{
	/// <summary>
	/// This class contains the unit tests for the <see cref="AppInfo"/> class.
	/// </summary>
	public class AppInfoTests
	{
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
