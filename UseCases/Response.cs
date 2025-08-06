using System;

namespace UseCases;

using Responses;
using Exceptions;

/// <summary>
/// Static class with util methods to create responses.
/// </summary>
public static class Response
{
    public static Response<T> Success<T>(T value)
        => new(true, value, null);

    public static NonInitializatedResponse Success()
        => new(true, null);
    
    public static NonInitializatedResponse Fail(string reason)
        => new(false, reason); 
    
    public static NonInitializatedResponse Fail()
        => new(false, "Use case failed without a specific reason."); 
}

/// <summary>
/// Represents a response with success status, error reason and value.
/// </summary>
public record Response<T>(
    bool Successfull,
    T? Value,
    string? Reason
)
{
    public static implicit operator Response<T>(NonInitializatedResponse nonInitResponse)
        => (nonInitResponse.Successfull, nonInitResponse.Reason) switch
        {
            (true, _) => Response.Success(GetEmptyResponse()),
            (false, null) => Response.Fail(),
            (false, string reason) => Response.Fail(reason)
        };

    static T GetEmptyResponse()
    {
        try
        {
            return Activator.CreateInstance<T>();
        }
        catch
        {
            throw new NonEmptyResponseException();
        }
    }
}