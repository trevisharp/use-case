namespace UseCases.Responses;

/// <summary>
/// Represents a Response without a value yet.
/// </summary>
public record NonInitializatedResponse(
    bool Successfull,
    string? Reason
);