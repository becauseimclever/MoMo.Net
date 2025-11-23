namespace MoMo.Net.Tokens;

/// <summary>
/// Represents an immutable design token for color values.
/// </summary>
/// <param name="Value">The CSS color value (e.g., "#FF5733", "rgba(255, 87, 51, 0.8)").</param>
/// <param name="Name">The semantic name of the color token (e.g., "PrimaryColor", "AccentBackground").</param>
public record ColorToken(string Value, string Name)
{
    /// <summary>
    /// Gets the CSS color value.
    /// </summary>
    public string Value { get; init; } = ValidateParameter(Value, nameof(Value));

    /// <summary>
    /// Gets the semantic name of the color token.
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
