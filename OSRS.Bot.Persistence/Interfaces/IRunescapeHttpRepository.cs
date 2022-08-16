using CSharpFunctionalExtensions;

namespace OSRS.Bot.Persistence.Interfaces;

public interface IRunescapeHttpRepository
{
    Task<Result<string>> GetHiScoresByUsernameAsync(string username, CancellationToken ct);
    Task<Result<string>> GetGroupIronmanHiscoresByGroupNameAsync(string name, CancellationToken ct);
}
