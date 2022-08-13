using CSharpFunctionalExtensions;
using OSRS.Bot.Application.Dtos;

namespace OSRS.Bot.Application.Interfaces.Services;

public interface IHiScoreService
{
    Task<Result<PlayerHiScoreDto>> GetHiScoresByUsernameAsync(string username, CancellationToken ct);
}
