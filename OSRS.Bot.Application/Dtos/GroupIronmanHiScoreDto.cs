using OSRS.Bot.Application.Enums;

namespace OSRS.Bot.Application.Dtos;
public class GroupIronmanHiScoreDto : HiScoreDto
{
	public GroupIronmanHiScoreDto(string groupName, HiScoreTypeEnum hiScoreType, string rank, string level, string xp, bool isPrestige) 
		: base("Overall", hiScoreType, rank, level, xp)
	{
		GroupName = groupName;
        IsPrestige = isPrestige;
	}

	public string GroupName { get; private set; }
	public bool IsPrestige { get; private set; }
}
