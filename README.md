# Unit Conversion API

A small REST API built with ASP.NET Core Web API (.NET 10) that converts values between length, weight/mass, and temperature units.

## Requirements

- .NET 10 SDK
- An HTTP client such as Postman or curl (optional)

## Run locally

From the repository root:

```bash
dotnet restore
dotnet build
dotnet run --project UnitConversionApi.csproj
```

The terminal prints the local HTTP/HTTPS addresses. In Development, Swagger UI is available at `/swagger` on the selected address.

## Endpoint

`POST /api/conversion/convert`

Example request:

```json
{
  "value": 100,
  "fromUnit": "meters",
  "toUnit": "feet"
}
```

Example response:

```json
{
  "originalValue": 100,
  "fromUnit": "meters",
  "toUnit": "feet",
  "convertedValue": 328.083989,
  "category": "Length"
}
```

## Supported units

- **Length:** `meters`, `kilometers`, `centimeters`, `millimeters`, `feet`, `inches`, `miles`
- **Weight/mass:** `kilograms`, `grams`, `milligrams`, `pounds`, `ounces`, `tonnes`
- **Temperature:** `celsius`, `fahrenheit`, `kelvin`

Unit names are case-insensitive. Convert only between units in the same category.

## Error handling

Invalid input, unknown units, or conversions between different categories return HTTP 400 with a JSON `error` message. Temperature values below absolute zero are rejected.

## Run tests

```bash
dotnet test
```

The test project covers representative conversions and invalid inputs.

## Design decisions and trade-offs

- The controller handles HTTP concerns; `IConversionService` and `ConversionService` hold conversion logic.
- Dependency injection and an interface make the conversion service easier to test and replace.
- Length and mass factors map to a common base unit, which avoids needing a separate formula for every unit pair.
- Temperature uses explicit formulas because it requires offsets, not just multiplication.
- Unit data is hardcoded to keep the assessment self-contained. If the unit catalogue grows, move definitions into configuration or a database and use conversion strategies for more complex unit types.
- Results are rounded to six decimal places for a readable API response.
- No database or external service is required.

## Repository hygiene

Build output folders such as `bin/` and `obj/` should not be committed. Keep environment-specific settings and secrets out of source control.
