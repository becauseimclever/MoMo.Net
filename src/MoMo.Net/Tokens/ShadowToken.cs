namespace MoMo.Net.Tokens;

/// <summary>
/// Represents an immutable design token for box-shadow values.
/// </summary>
/// <param name="Value">The CSS box-shadow value (e.g., "0 2px 4px rgba(0,0,0,0.2)").</param>
/// <param name="Name">The semantic name of the shadow token (e.g., "ElevationLow", "DropShadow").</param>
public record ShadowToken(string Value, string Name)
{
    /// <summary>
    /// Gets the CSS box-shadow value.
    /// </summary>
    public string Value { get; init; } = ValidateParameter(Value, nameof(Value));

    /// <summary>
    /// Gets the semantic name of the shadow token.
    /// </summary>
    public string Name { get; init; } = ValidateParameter(Name, nameof(Name));

    private static string ValidateParameter(string value, string paramName)
    {
        if (value is null)
        {
            throw new ArgumentNullException(paramName);
        }

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{paramName} cannot be empty or whitespace.", paramName);
        }

        return value;
    }
}
