using jjm.one.MiscUtilClasses.Types.basic;

namespace jjm.one.MiscUtilClasses.Tests.Types.basic
{
    /// <summary>
    /// This class contains the unit tests for the <see cref="AppInfo"/> class.
    /// </summary>
    public class AppInfoTests
    {
        #region tests

        #region default constructor

        [Fact]
        public void DefaultCtor_SetsAllFieldsToUnknown()
        {
            var appInfo = new AppInfo();

            Assert.Equal("unknown", appInfo.AppName);
            Assert.Equal("unknown", appInfo.AppVersion);
            Assert.Equal("unknown", appInfo.AppBuildDate);
            Assert.Equal("unknown", appInfo.AppBuildTime);
            Assert.Equal("unknown", appInfo.AppRuntimeEnvironment);
        }

        #endregion

        #region parameterized constructor

        [Fact]
        public void ParameterizedCtor_WithValidValues_SetsFields()
        {
            var appInfo = new AppInfo("MyApp", "1.0.0", "2024-01-01", "12:00:00", "Production");

            Assert.Equal("MyApp", appInfo.AppName);
            Assert.Equal("1.0.0", appInfo.AppVersion);
            Assert.Equal("2024-01-01", appInfo.AppBuildDate);
            Assert.Equal("12:00:00", appInfo.AppBuildTime);
            Assert.Equal("Production", appInfo.AppRuntimeEnvironment);
        }

        [Fact]
        public void ParameterizedCtor_WithAllNulls_FallsBackToUnknown()
        {
            var appInfo = new AppInfo(null, null, null, null, null);

            Assert.Equal("unknown", appInfo.AppName);
            Assert.Equal("unknown", appInfo.AppVersion);
            Assert.Equal("unknown", appInfo.AppBuildDate);
            Assert.Equal("unknown", appInfo.AppBuildTime);
            Assert.Equal("unknown", appInfo.AppRuntimeEnvironment);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("\t")]
        [InlineData("\n")]
        public void ParameterizedCtor_WithEmptyOrWhitespace_FallsBackToUnknown(string badValue)
        {
            var appInfo = new AppInfo(badValue, badValue, badValue, badValue, badValue);

            Assert.Equal("unknown", appInfo.AppName);
            Assert.Equal("unknown", appInfo.AppVersion);
            Assert.Equal("unknown", appInfo.AppBuildDate);
            Assert.Equal("unknown", appInfo.AppBuildTime);
            Assert.Equal("unknown", appInfo.AppRuntimeEnvironment);
        }

        #endregion

        #region property setters

        [Fact]
        public void PropertySetters_WithValidValues_UpdateFields()
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

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("\t")]
        public void PropertySetters_WithEmptyOrWhitespace_CoerceToUnknown(string badValue)
        {
            var appInfo = new AppInfo
            {
                AppName = badValue,
                AppVersion = badValue,
                AppBuildDate = badValue,
                AppBuildTime = badValue,
                AppRuntimeEnvironment = badValue
            };

            Assert.Equal("unknown", appInfo.AppName);
            Assert.Equal("unknown", appInfo.AppVersion);
            Assert.Equal("unknown", appInfo.AppBuildDate);
            Assert.Equal("unknown", appInfo.AppBuildTime);
            Assert.Equal("unknown", appInfo.AppRuntimeEnvironment);
        }

        [Fact]
        public void PropertySetters_WithNull_CoerceToUnknown()
        {
            var appInfo = new AppInfo
            {
                AppName = null!,
                AppVersion = null!,
                AppBuildDate = null!,
                AppBuildTime = null!,
                AppRuntimeEnvironment = null!
            };

            Assert.Equal("unknown", appInfo.AppName);
            Assert.Equal("unknown", appInfo.AppVersion);
            Assert.Equal("unknown", appInfo.AppBuildDate);
            Assert.Equal("unknown", appInfo.AppBuildTime);
            Assert.Equal("unknown", appInfo.AppRuntimeEnvironment);
        }

        [Fact]
        public void PropertySetters_MutateAfterConstruction()
        {
            var appInfo = new AppInfo("OldName", "OldVer", "OldDate", "OldTime", "OldEnv");
            appInfo.AppName = "NewName";
            appInfo.AppVersion = "NewVer";

            Assert.Equal("NewName", appInfo.AppName);
            Assert.Equal("NewVer", appInfo.AppVersion);
            Assert.Equal("OldDate", appInfo.AppBuildDate);
            Assert.Equal("OldTime", appInfo.AppBuildTime);
            Assert.Equal("OldEnv", appInfo.AppRuntimeEnvironment);
        }

        #endregion

        #region ToString

        [Fact]
        public void ToString_DefaultInstance_ReturnsAllUnknown()
        {
            var appInfo = new AppInfo();
            Assert.Equal("unknown [Version: unknown - unknown @ unknown | Env: unknown]", appInfo.ToString());
        }

        [Fact]
        public void ToString_WithCustomValues_FormatsCorrectly()
        {
            var appInfo = new AppInfo("MyApp", "2.0.0", "2024-06-01", "08:30:00", "Staging");
            Assert.Equal("MyApp [Version: 2.0.0 - 2024-06-01 @ 08:30:00 | Env: Staging]", appInfo.ToString());
        }

        #endregion

        #region equality

        [Fact]
        public void Equals_SameValues_ReturnsTrue()
        {
            var a = new AppInfo("N", "V", "D", "T", "E");
            var b = new AppInfo("N", "V", "D", "T", "E");

            Assert.True(a.Equals(b));
            Assert.True(a == b);
            Assert.False(a != b);
        }

        [Fact]
        public void Equals_DifferentValues_ReturnsFalse()
        {
            var a = new AppInfo("N1", "V", "D", "T", "E");
            var b = new AppInfo("N2", "V", "D", "T", "E");

            Assert.False(a.Equals(b));
            Assert.False(a == b);
            Assert.True(a != b);
        }

        [Fact]
        public void Equals_SameReference_ReturnsTrue()
        {
            var a = new AppInfo("N", "V", "D", "T", "E");
            Assert.True(a.Equals(a));
            // use object.ReferenceEquals to avoid the CS1718 self-comparison warning
            Assert.True(object.ReferenceEquals(a, a));
        }

        [Fact]
        public void Equals_NullOther_ReturnsFalse()
        {
            var a = new AppInfo();
            Assert.False(a.Equals(null));
            Assert.False(a == null);
            Assert.True(a != null);
        }

        [Fact]
        public void Equals_BothNull_ReturnsTrue()
        {
            AppInfo? a = null;
            AppInfo? b = null;
            Assert.True(a == b);
            Assert.False(a != b);
        }

        [Fact]
        public void Equals_BoxedObject_ReturnsTrue()
        {
            var a = new AppInfo("N", "V", "D", "T", "E");
            object b = new AppInfo("N", "V", "D", "T", "E");
            Assert.True(a.Equals(b));
        }

        [Fact]
        public void Equals_BoxedNonAppInfoObject_ReturnsFalse()
        {
            var a = new AppInfo();
            Assert.False(a.Equals("not an AppInfo"));
        }

        [Fact]
        public void GetHashCode_EqualInstances_ReturnSameHash()
        {
            var a = new AppInfo("N", "V", "D", "T", "E");
            var b = new AppInfo("N", "V", "D", "T", "E");
            Assert.Equal(a.GetHashCode(), b.GetHashCode());
        }

        [Fact]
        public void GetHashCode_DefaultInstances_ReturnSameHash()
        {
            var a = new AppInfo();
            var b = new AppInfo();
            Assert.Equal(a.GetHashCode(), b.GetHashCode());
        }

        #endregion

        #endregion
    }
}
