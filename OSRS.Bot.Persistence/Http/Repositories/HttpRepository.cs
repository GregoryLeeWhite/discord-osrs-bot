using CSharpFunctionalExtensions;
using OSRS.Bot.Persistence.Http.Extensions;
using OSRS.Bot.Persistence.Interfaces;
using System.Net.Http.Json;

namespace OSRS.Bot.Persistence.Http.Repositories;

public class HttpRepository : IHttpRepository
{
    private readonly HttpClient _httpClient;

    public HttpRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // TODO: add polly support
    public async Task<Result<T?>> GetAsync<T>(string endpoint, CancellationToken ct)
    {
        var response = await _httpClient.GetAsync(endpoint, ct);

        if (response.IsSuccessStatusCode)
            return Result.Success(await response.ReadAsAsync<T>());

        return Result.Failure<T?>(await response.HandleFailureAsync());
    }

    public async Task<Result<T?>> GetAsync<T>(string endpoint, CancellationToken ct, params KeyValuePair<string, string>[] headers)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

        foreach (var header in headers)
            request.Headers.Add(header.Key, header.Value);

        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Other");

        var response = await _httpClient.SendAsync(request, ct);

        if (response.IsSuccessStatusCode)
            return Result.Success(await response.ReadAsAsync<T>());

        return Result.Failure<T?>(await response.HandleFailureAsync());
    }

    public async Task<Result<string>> GetTextAsync(string endpoint, CancellationToken ct)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

        request.Headers.Add("Accept", "text/html");
        request.Headers.Add("User-Agent", "Other");

        var response = await _httpClient.SendAsync(request, ct);

        if (response.IsSuccessStatusCode)
            return Result.Success(await response.Content.ReadAsStringAsync());

        return Result.Failure<string>(response.StatusCode.ToString());
    }

    public async Task<Result<TResponse?>> PostAsync<TResponse, TPost>(string endpoint, TPost postObject, CancellationToken ct)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        request.Content = JsonContent.Create(postObject);
        var response = await _httpClient.SendAsync(request, ct);

        if (response.IsSuccessStatusCode)
            return Result.Success(await response.ReadAsAsync<TResponse?>());

        return Result.Failure<TResponse?>(await response.HandleFailureAsync());
    }

    public async Task<Result<TResponse?>> PutAsync<TResponse, TPut>(string endpoint, TPut putObject, CancellationToken ct)
    {
        var response = await _httpClient.PutAsync(endpoint, JsonContent.Create(putObject), ct);

        if (response.IsSuccessStatusCode)
            return Result.Success(await response.ReadAsAsync<TResponse?>());

        return Result.Failure<TResponse?>(await response.HandleFailureAsync());
    }

    public async Task<Result> DeleteAsync(string endpoint, CancellationToken ct)
    {
        var response = await _httpClient.DeleteAsync(endpoint, ct);

        if (response.IsSuccessStatusCode)
            return Result.Success();

        return Result.Failure(await response.HandleFailureAsync());
    }
}
