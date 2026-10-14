using System.ComponentModel.DataAnnotations;

namespace UnitConversionApi.Models;

public sealed class ConversionRequest
{
    [Required]
    public double? Value { get; init; }

    [Required]
    [MinLength(1)]
    public string FromUnit { get; init; } = string.Empty;

    [Required]
    [MinLength(1)]
    public string ToUnit { get; init; } = string.Empty;
}
