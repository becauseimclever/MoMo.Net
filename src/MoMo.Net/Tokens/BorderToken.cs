namespace MoMo.Net.Tokens;

/// <summary>
/// Represents an immutable design token for border specifications.
/// </summary>
/// <param name="Width">The CSS border-width value (e.g., "1px", "2px").</param>
/// <param name="Style">The CSS border-style value (e.g., "solid", "dashed", "dotted").</param>
/// <param name="Color">The CSS border-color value (e.g., "#000000", "rgba(0,0,0,0.1)").</param>
/// <param name="Name">The semantic name of the border token (e.g., "DefaultBorder", "FocusOutline").</param>
public record BorderToken(string Width, string Style, string Color, string Name)
{
    /// <summary>
    /// Gets the CSS border-width value.
    /// </summary>
    public string Width { get; init; } = ValidateParameter(Width, nameof(Width));

    /// <summary>
    /// Gets the CSS border-style value.
    /// </summary>
    public string Style { get; init; } = ValidateParameter(Style, nameof(Style));

    /// <summary>
    /// Gets the CSS border-color value.
    /// </summary>
    public string Color { get; init; } = ValidateParameter(Color, nameof(Color));

    /// <summary>
    /// Gets the semantic name of the border token.
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
