namespace UnitConversionApi.Services;

public interface IConversionService
{
    ConversionResult Convert(double value, string fromUnit, string toUnit);
}

public sealed record ConversionResult(double Value, string Category);
