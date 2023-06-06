using jjm.one.MiscUtilClasses.Types.basic;

namespace jjm.one.MiscUtilClasses.Tests.Types.basic
{
	public class AppInfoTests
	{
		[Fact]
		public void ToStringTest1()
		{
			var appInfo = new AppInfo();

			Assert.Equal("unknown [Version: unknown - unknown @ unknown | Env: unknown]", appInfo.ToString());
		}

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
    }
}

