using System;
using System.Threading.Tasks;

namespace UseCases;

using Exceptions;

public static class UseCaseExtension
{
    public record CreateProfile;

    /// <summary>
    /// Execute a use case with empty response.
    /// </summary>
    public static async Task<Response<R>> ExecuteAsync<T, R>(this IUseCase<T, R> useCase)
        where T : new()
    {
        var request = new T();
        return await useCase.ExecuteAsync(request);
    }

    /// <summary>
    /// Execute a use case with a request object.
    /// </summary>
    public static async Task<Response<R>> ExecuteAsync<T, R>(this IUseCase<T, R> useCase, T request)
    {
        try
        {
            return await useCase.ExecuteUseCaseAsync(request);
        }
        catch (Exception ex) when (ex is not NonEmptyResponseException)
        {
            return Response.Fail($"The use case failed with a exception: {ex.Message}. {ex.StackTrace}");
        }
    }
}