namespace MoMo.Net.Tokens;

/// <summary>
/// Represents an immutable design token for typography specifications.
/// </summary>
/// <param name="FontFamily">The CSS font-family value (e.g., "Segoe UI", "Arial, sans-serif").</param>
/// <param name="FontSize">The CSS font-size value (e.g., "14px", "1rem").</param>
/// <param name="FontWeight">The CSS font-weight value (e.g., "400", "bold", "600").</param>
/// <param name="Name">The semantic name of the typography token (e.g., "BodyText", "Heading1").</param>
public record TypographyToken(string FontFamily, string FontSize, string FontWeight, string Name)
{
    /// <summary>
    /// Gets the CSS font-family value.
    /// </summary>
    public string FontFamily { get; init; } = ValidateParameter(FontFamily, nameof(FontFamily));

    /// <summary>
    /// Gets the CSS font-size value.
    /// </summary>
    public string FontSize { get; init; } = ValidateParameter(FontSize, nameof(FontSize));

    /// <summary>
    /// Gets the CSS font-weight value.
    /// </summary>
    public string FontWeight { get; init; } = ValidateParameter(FontWeight, nameof(FontWeight));

    /// <summary>
    /// Gets the semantic name of the typography token.
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
