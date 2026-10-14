using UnitConversionApi.Services;
using Xunit;

namespace UnitConversionApi.Tests;

public sealed class ConversionServiceTests
{
    private readonly ConversionService _service = new();

    [Theory]
    [InlineData(100, "meters", "feet", 328.0839895)]
    [InlineData(1, "kilometers", "meters", 1000)]
    [InlineData(1, "kilograms", "pounds", 2.2046226218)]
    [InlineData(0, "celsius", "fahrenheit", 32)]
    [InlineData(100, "celsius", "fahrenheit", 212)]
    [InlineData(32, "fahrenheit", "celsius", 0)]
    public void Convert_ValidUnits_ReturnsExpectedValue(
        double value, string fromUnit, string toUnit, double expected)
    {
        var result = _service.Convert(value, fromUnit, toUnit);

        Assert.Equal(expected, result.Value, 4);
    }

    [Fact]
    public void Convert_DifferentCategories_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            _service.Convert(1, "meters", "kilograms"));
    }

    [Fact]
    public void Convert_UnknownUnit_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            _service.Convert(1, "furlongs", "meters"));
    }

    [Fact]
    public void Convert_NegativeKelvin_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            _service.Convert(-300, "celsius", "kelvin"));
    }
}
