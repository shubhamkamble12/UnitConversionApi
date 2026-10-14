using Microsoft.AspNetCore.Mvc;
using UnitConversionApi.Models;
using UnitConversionApi.Services;

namespace UnitConversionApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ConversionController : ControllerBase
{
    private readonly IConversionService _conversionService;

    public ConversionController(IConversionService conversionService)
    {
        _conversionService = conversionService;
    }

    [HttpPost("convert")]
    [ProducesResponseType<ConversionResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ConversionResponse> Convert([FromBody] ConversionRequest request)
    {
        try
        {
            var result = _conversionService.Convert(
                request.Value!.Value,
                request.FromUnit,
                request.ToUnit);

            var response = new ConversionResponse
            {
                OriginalValue = request.Value.Value,
                FromUnit = request.FromUnit.Trim(),
                ToUnit = request.ToUnit.Trim(),
                ConvertedValue = Math.Round(result.Value, 6, MidpointRounding.AwayFromZero),
                Category = result.Category
            };

            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
