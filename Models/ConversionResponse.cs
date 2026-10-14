namespace UnitConversionApi.Models;

public sealed class ConversionResponse
{
    public double OriginalValue { get; init; }
    public string FromUnit { get; init; } = string.Empty;
    public string ToUnit { get; init; } = string.Empty;
    public double ConvertedValue { get; init; }
    public string Category { get; init; } = string.Empty;
}
