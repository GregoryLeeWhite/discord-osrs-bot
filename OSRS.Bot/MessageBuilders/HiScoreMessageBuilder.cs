using Discord;
using OSRS.Bot.Application.Dtos;
using OSRS.Bot.Application.Enums;

namespace OSRS.Bot.MessageBuilders;

internal static class HiScoreMessageBuilder
{
    internal static Embed BuildHiScoreEmbed(PlayerHiScoreDto playerHiScoreDto, string username, Func<string, GuildEmote?> getEmoteByName)
    {
        var hiScoresEmote = getEmoteByName("HiScores");

        var embed = new EmbedBuilder();
        embed.Title = $"{$"<:{hiScoresEmote.Name}:{hiScoresEmote.Id}>"} **{username}**";
        
        foreach (var hiScore in playerHiScoreDto.HiScores)
        {
            var emote = getEmoteByName(hiScore.HiScoreName);

            var level = hiScore.Level == "1" ? "?" : hiScore.Level;
            var rank = hiScore.Rank == "-1" ? "Unranked" : hiScore.Rank;
            var xp = hiScore.XP == "-1" ? "Unknown" : hiScore.XP;

            if (hiScore.HiScoreType == HiScoreTypeEnum.Skill || hiScore.HiScoreType == HiScoreTypeEnum.Overall)
                embed.AddField($"<:{emote.Name}:{emote.Id}> **{level}**", $"#{rank}, {xp} XP", true);
        }

        var richEmbed = embed.Build();

        return richEmbed;
    }

    internal static Embed BuildGroupIronmanHiScoreEmbed(GroupIronmanHiScoreDto groupIronmanHiScoreDto, Func<string, GuildEmote?> getEmoteByName)
    {
        var embed = new EmbedBuilder();
        embed.Title = groupIronmanHiScoreDto.IsPrestige 
            ? $"\u2B50 **{groupIronmanHiScoreDto.GroupName}**" 
            : $"**{groupIronmanHiScoreDto.GroupName}**";

        var emote = getEmoteByName(groupIronmanHiScoreDto.HiScoreName);

        var level = groupIronmanHiScoreDto.Level == "1" ? "?" : groupIronmanHiScoreDto.Level;
        var rank = groupIronmanHiScoreDto.Rank == "-1" ? "Unranked" : groupIronmanHiScoreDto.Rank;
        var xp = groupIronmanHiScoreDto.XP == "-1" ? "Unknown" : groupIronmanHiScoreDto.XP;

        embed.AddField($"<:{emote.Name}:{emote.Id}> **{level}**", $"#{rank}, {xp} XP", true);

        var richEmbed = embed.Build();

        return richEmbed;
    }
}
