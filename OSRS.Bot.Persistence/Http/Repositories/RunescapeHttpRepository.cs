using CSharpFunctionalExtensions;
using OSRS.Bot.Persistence.Http.Extensions;
using OSRS.Bot.Persistence.Interfaces;

namespace OSRS.Bot.Persistence.Http.Repositories;

public class RunescapeHttpRepository : IRunescapeHttpRepository
{
    private readonly IHttpRepository _httpRepository;

    public RunescapeHttpRepository(IHttpRepository httpRepository)
    {
        _httpRepository = httpRepository;
    }

    public async Task<Result<string>> GetHiScoresByUsernameAsync(string username, CancellationToken ct)
    {
        var endpoint = new Uri("https://secure.runescape.com/m=hiscore_oldschool/index_lite.ws");
        endpoint = endpoint.AddParameter("player", username);

        var response = await _httpRepository.GetTextAsync(endpoint.AbsoluteUri, ct);

        if (response.IsFailure)
            return Result.Failure<string>(response.Error);

        return Result.Success(response.Value);
    }

    public async Task<Result<string>> GetGroupIronmanHiscoresByGroupNameAsync(string name, CancellationToken ct)
    {
        var endpoint = new Uri("https://secure.runescape.com/m=hiscore_oldschool_ironman/a=135/group-ironman/");
        endpoint = endpoint.AddParameter("groupName", name);

        var response = await _httpRepository.GetTextAsync(endpoint.AbsoluteUri, ct);

        if (response.IsFailure)
            return Result.Failure<string>(response.Error);

        return Result.Success(response.Value);
    }
}
