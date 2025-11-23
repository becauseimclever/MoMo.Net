namespace MoMo.Net.Tokens;

/// <summary>
/// Represents an immutable design token for spacing values.
/// </summary>
/// <param name="Value">The CSS spacing value (e.g., "16px", "1rem", "2em").</param>
/// <param name="Name">The semantic name of the spacing token (e.g., "MediumSpacing", "PaddingDefault").</param>
public record SpacingToken(string Value, string Name)
{
    /// <summary>
    /// Gets the CSS spacing value.
    /// </summary>
    public string Value { get; init; } = ValidateParameter(Value, nameof(Value));

    /// <summary>
    /// Gets the semantic name of the spacing token.
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
