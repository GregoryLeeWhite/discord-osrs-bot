using CSharpFunctionalExtensions;
using HtmlAgilityPack;
using OSRS.Bot.Application.Dtos;
using OSRS.Bot.Application.Enums;
using OSRS.Bot.Application.Interfaces.Services;
using OSRS.Bot.Persistence.Interfaces;

namespace OSRS.Bot.Application.Services;

public class HiScoreService : IHiScoreService
{
    private readonly IRunescapeHttpRepository _runescapeHttpRepository;

    private const string GroupIronmanNotFoundMessage = "Could not find the group";

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

    public async Task<Result<GroupIronmanHiScoreDto>> GetGroupIronmanHiScoresByGroupNameAsync(string groupName, CancellationToken ct)
    {
        var hiScoresResult = await _runescapeHttpRepository.GetGroupIronmanHiscoresByGroupNameAsync(groupName, ct);

        if (hiScoresResult.IsFailure)
            return Result.Failure<GroupIronmanHiScoreDto>(hiScoresResult.Error);

        var htmlResponse = new HtmlDocument();
        htmlResponse.LoadHtml(hiScoresResult.Value);

        if (htmlResponse.DocumentNode.InnerHtml.Contains(GroupIronmanNotFoundMessage))
            return Result.Failure<GroupIronmanHiScoreDto>(GroupIronmanNotFoundMessage);

        var htmlNodeWithGroupName = htmlResponse.DocumentNode.SelectNodes("//a[@class='uc-scroll__link']")
        .SingleOrDefault(p => p.InnerText.Equals(groupName, StringComparison.InvariantCultureIgnoreCase));

        if (htmlNodeWithGroupName == null)
            return Result.Failure<GroupIronmanHiScoreDto>("Unable to locate group in the response from OSRS.");

        var parentNode = htmlNodeWithGroupName.ParentNode;

        var isPrestige = parentNode.InnerHtml.Contains("prestige-icon");
        var rank = parentNode.PreviousSibling.PreviousSibling.InnerText.Trim();
        var level = parentNode.NextSibling.NextSibling.InnerText.Trim().Replace("\\n", string.Empty);
        var xp = parentNode.NextSibling.NextSibling.NextSibling.NextSibling.InnerText.Trim();

        return Result.Success(new GroupIronmanHiScoreDto(groupName, HiScoreTypeEnum.GroupIronman, rank, level, xp, isPrestige));
    }
}
