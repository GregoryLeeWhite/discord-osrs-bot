using OSRS.Bot.Application.Enums;

namespace OSRS.Bot.Application.Dtos;

public class HiScoreDto
{
    public HiScoreDto(string name, HiScoreTypeEnum hiScoreType, string rank, string level, string xp)
    {
        HiScoreName = name;
        HiScoreType = hiScoreType;
        Rank = rank;
        Level = level;
        XP = xp;
    }

    public string HiScoreName { get; private set; }
    public HiScoreTypeEnum HiScoreType { get; private set; }
    public string Rank { get; private set; }

    public string Level { get; private set; }

    public string XP { get; private set; }
}
