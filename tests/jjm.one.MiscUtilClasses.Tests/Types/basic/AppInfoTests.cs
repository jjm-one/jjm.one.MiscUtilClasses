using jjm.one.MiscUtilClasses.Types.basic;

namespace jjm.one.MiscUtilClasses.Tests.Types.basic;

/// <summary>
///     This class contains the unit tests for the <see cref="AppInfo" /> class.
/// </summary>
public class AppInfoTests
{
    #region tests

    #region default constructor

    /// <summary>
    ///     Verifies that the default (parameterless) constructor initializes every field to
    ///     the sentinel string <c>"unknown"</c>.
    /// </summary>
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

    /// <summary>
    ///     Verifies that the parameterized constructor stores all five non-null, non-empty
    ///     arguments exactly as supplied.
    /// </summary>
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

    /// <summary>
    ///     Verifies that passing <c>null</c> for every argument falls back to <c>"unknown"</c>
    ///     for each corresponding field.
    /// </summary>
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

    /// <summary>
    ///     Verifies that empty strings and whitespace-only strings (space, tab, newline)
    ///     are treated the same as <c>null</c> and replaced by <c>"unknown"</c>.
    /// </summary>
    /// <param name="badValue">The degenerate string value under test.</param>
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

    /// <summary>
    ///     Verifies that assigning valid (non-null, non-empty) strings via object-initializer
    ///     syntax stores the exact values provided.
    /// </summary>
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

    /// <summary>
    ///     Verifies that assigning an empty or whitespace-only string to a property coerces
    ///     the stored value to <c>"unknown"</c> rather than retaining the invalid input.
    /// </summary>
    /// <param name="badValue">The degenerate string value under test.</param>
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

    /// <summary>
    ///     Verifies that assigning <c>null</c> to a property (suppressing the nullable
    ///     warning with <c>!</c>) coerces the stored value to <c>"unknown"</c>.
    /// </summary>
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

    /// <summary>
    ///     Verifies that property values can be updated after initial construction and that
    ///     only the mutated properties change — others remain at their original values.
    /// </summary>
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

    /// <summary>
    ///     Verifies that <see cref="AppInfo.ToString" /> on a default instance produces the
    ///     expected all-<c>"unknown"</c> formatted string.
    /// </summary>
    [Fact]
    public void ToString_DefaultInstance_ReturnsAllUnknown()
    {
        var appInfo = new AppInfo();
        Assert.Equal("unknown [Version: unknown - unknown @ unknown | Env: unknown]",
            appInfo.ToString());
    }

    /// <summary>
    ///     Verifies that <see cref="AppInfo.ToString" /> correctly interpolates all five custom
    ///     field values into the expected format string.
    /// </summary>
    [Fact]
    public void ToString_WithCustomValues_FormatsCorrectly()
    {
        var appInfo = new AppInfo("MyApp", "2.0.0", "2024-06-01", "08:30:00", "Staging");
        Assert.Equal("MyApp [Version: 2.0.0 - 2024-06-01 @ 08:30:00 | Env: Staging]",
            appInfo.ToString());
    }

    #endregion

    #region equality

    /// <summary>
    ///     Verifies that two distinct instances with identical field values are considered equal
    ///     by both <see cref="AppInfo.Equals(AppInfo)" /> and the <c>==</c> operator.
    /// </summary>
    [Fact]
    public void Equals_SameValues_ReturnsTrue()
    {
        var a = new AppInfo("N", "V", "D", "T", "E");
        var b = new AppInfo("N", "V", "D", "T", "E");

        Assert.True(a.Equals(b));
        Assert.True(a == b);
        Assert.False(a != b);
    }

    /// <summary>
    ///     Verifies that two instances that differ in at least one field are not considered equal.
    /// </summary>
    [Fact]
    public void Equals_DifferentValues_ReturnsFalse()
    {
        var a = new AppInfo("N1", "V", "D", "T", "E");
        var b = new AppInfo("N2", "V", "D", "T", "E");

        Assert.False(a.Equals(b));
        Assert.False(a == b);
        Assert.True(a != b);
    }

    /// <summary>
    ///     Verifies that comparing an instance with itself via <see cref="AppInfo.Equals(AppInfo)" />
    ///     returns <c>true</c> (reflexivity).
    /// </summary>
    [Fact]
    public void Equals_SameReference_ReturnsTrue()
    {
        var a = new AppInfo("N", "V", "D", "T", "E");
        Assert.True(a.Equals(a));
        // use object.ReferenceEquals to avoid the CS1718 self-comparison warning
        Assert.True(ReferenceEquals(a, a));
    }

    /// <summary>
    ///     Verifies that comparing a non-null instance with <c>null</c> returns <c>false</c>.
    /// </summary>
    [Fact]
    public void Equals_NullOther_ReturnsFalse()
    {
        var a = new AppInfo();
        Assert.False(a.Equals(null));
        Assert.False(a == null);
        Assert.True(a != null);
    }

    /// <summary>
    ///     Verifies that comparing two <c>null</c> references with <c>==</c> returns <c>true</c>.
    /// </summary>
    [Fact]
    public void Equals_BothNull_ReturnsTrue()
    {
        AppInfo? a = null;
        AppInfo? b = null;
        Assert.True(a == b);
        Assert.False(a != b);
    }

    /// <summary>
    ///     Verifies that <see cref="AppInfo.Equals(object?)" /> returns <c>true</c> when passed
    ///     a boxed <see cref="AppInfo" /> with identical field values.
    /// </summary>
    [Fact]
    public void Equals_BoxedObject_ReturnsTrue()
    {
        var a = new AppInfo("N", "V", "D", "T", "E");
        object b = new AppInfo("N", "V", "D", "T", "E");
        Assert.True(a.Equals(b));
    }

    /// <summary>
    ///     Verifies that <see cref="AppInfo.Equals(object?)" /> returns <c>false</c> when passed
    ///     an object of an unrelated type.
    /// </summary>
    [Fact]
    public void Equals_BoxedNonAppInfoObject_ReturnsFalse()
    {
        var a = new AppInfo();
        Assert.False(a.Equals("not an AppInfo"));
    }

    /// <summary>
    ///     Verifies that two equal <see cref="AppInfo" /> instances produce the same hash code,
    ///     satisfying the contract between <see cref="AppInfo.Equals(AppInfo)" /> and
    ///     <see cref="AppInfo.GetHashCode" />.
    /// </summary>
    [Fact]
    public void GetHashCode_EqualInstances_ReturnSameHash()
    {
        var a = new AppInfo("N", "V", "D", "T", "E");
        var b = new AppInfo("N", "V", "D", "T", "E");
        Assert.Equal(a.GetHashCode(), b.GetHashCode());
    }

    /// <summary>
    ///     Verifies that two independently created default instances produce the same hash code.
    /// </summary>
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
