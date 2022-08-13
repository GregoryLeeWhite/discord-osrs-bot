using CSharpFunctionalExtensions;
using OSRS.Bot.Application.Dtos;
using OSRS.Bot.Application.Enums;
using OSRS.Bot.Application.Interfaces.Services;
using OSRS.Bot.Persistence.Interfaces;

namespace OSRS.Bot.Application.Services;

public class HiScoreService : IHiScoreService
{
    private readonly IRunescapeHttpRepository _runescapeHttpRepository;

    public HiScoreService(IRunescapeHttpRepository runescapeHttpRepository)
    {
        _runescapeHttpRepository = runescapeHttpRepository;
    }

    public async Task<Result<PlayerHiScoreDto>> GetHiScoresByUsernameAsync(string username, CancellationToken ct)
    {
        var hiScoresResult = await _runescapeHttpRepository.GetHiScoresByUsernameAsync(username, ct);

        if (hiScoresResult.IsFailure)
            return Result.Failure<PlayerHiScoreDto>(hiScoresResult.Error);

        var hiScoreItemTypes = HiScoreItemEnumeration.GetAll<HiScoreItems>().ToList();

        var splitHiScores = hiScoresResult.Value.Split("\n").ToList();

        // Doing a split on a line break causes one more added item with no data
        splitHiScores.Remove(string.Empty);

        if (splitHiScores.Count != hiScoreItemTypes.Count)
            return Result.Failure<PlayerHiScoreDto>($"OSRS API returned more Hiscores than expected.  {nameof(HiScoreItems)} Enumeration class may need to be updated.");

        var playerHiScoreDto = new PlayerHiScoreDto();
        for (var i = 0; i < splitHiScores.Count; i++)
        {
            var splitHiScore = splitHiScores[i].Split(",");
            if (splitHiScore.Length != 3)
            {
                playerHiScoreDto.HiScores.Add(new HiScoreDto(hiScoreItemTypes[i].Name, hiScoreItemTypes[i].HiScoreType, splitHiScore[0], string.Empty, splitHiScore[1]));
                continue;
            }

            playerHiScoreDto.HiScores.Add(new HiScoreDto(hiScoreItemTypes[i].Name, hiScoreItemTypes[i].HiScoreType, splitHiScore[0], splitHiScore[1], splitHiScore[2]));
        }

        return Result.Success(playerHiScoreDto);
    }
}
