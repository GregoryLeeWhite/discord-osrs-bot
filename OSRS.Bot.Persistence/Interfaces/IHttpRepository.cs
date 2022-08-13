using CSharpFunctionalExtensions;

namespace OSRS.Bot.Persistence.Interfaces;

public interface IHttpRepository
{
    Task<Result<T?>> GetAsync<T>(string endpoint, CancellationToken ct);
    Task<Result<T?>> GetAsync<T>(string endpoint, CancellationToken ct, params KeyValuePair<string, string>[] headers);
    Task<Result<string>> GetTextAsync(string endpoint, CancellationToken ct);
    Task<Result<TResponse?>> PostAsync<TResponse, TPost>(string endpoint, TPost postObject, CancellationToken ct);
    Task<Result<TResponse?>> PutAsync<TResponse, TPut>(string endpoint, TPut putObject, CancellationToken ct);
    Task<Result> DeleteAsync(string endpoint, CancellationToken ct);
}
