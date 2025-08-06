using System.Threading.Tasks;

namespace UseCases;

/// <summary>
/// A interface for all use case with a request (input) and response (output).
/// For empty requests/responses consider create empty records like:
/// 
/// public record CreateProfileRequest;
/// or
/// public record CreateProfileResponse;
/// </summary>
public interface IUseCase<T, R>
{
    Task<Response<R>> ExecuteUseCaseAsync(T request);
}