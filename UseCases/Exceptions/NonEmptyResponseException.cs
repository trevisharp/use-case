using System;

namespace UseCases.Exceptions;

public class NonEmptyResponseException : Exception
{
    public override string Message =>
    """
    A function like Response.Success() create a NonInitializatedResponse that
    creates the Response object considering a empty object like:

    public record CreateProfileResponse;

    Consider using Response.Success(object) instead.
    """;
}