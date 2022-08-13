using Discord;
using Discord.Commands;
using Discord.WebSocket;
using OSRS.Bot.Application.Interfaces.Services;
using OSRS.Bot.MessageBuilders;

namespace OSRS.Bot.Modules;

public class PublicModule : ModuleBase<SocketCommandContext>
{
    private readonly IHiScoreService _hiScoreService;
    private readonly DiscordSocketClient _client;

    public PublicModule(IHiScoreService hiScoreService, DiscordSocketClient client)
    {
        _hiScoreService = hiScoreService;
        _client = client;
    }

    [Command("ping")]
    [Alias("pong", "hello")]
    public Task PingAsync()
    {
        return ReplyAsync("pong!");
    }

    [Command("hiscores")]
    public async Task GetHiScoresByUsernameAsync([Remainder] string username)
    {
        // Get a stream containing an image of a cat
        var result = await _hiScoreService.GetHiScoresByUsernameAsync(username.Trim(), CancellationToken.None);

        if (result.IsFailure)
        {
            var errorMessage = OsrsFailureMessageBuilder.BuildOsrsApiErrorMessage(result.Error);
            await ReplyAsync(errorMessage);

            return;
        }

        var message = HiScoreMessageBuilder.BuildHiScoreEmbed(result.Value, username, GetEmoteByName);

        await ReplyAsync(embed: message);
    }

    // Get info on a user, or the user who invoked the command if one is not specified
    [Command("userinfo")]
    public async Task UserInfoAsync(IUser user = null)
    {
        user ??= Context.User;

        await ReplyAsync(user.ToString());
    }

    private GuildEmote? GetEmoteByName(string name)
        => _client.Guilds
            .SelectMany(x => x.Emotes)
            .FirstOrDefault(x => x.Name.IndexOf(
                name, StringComparison.OrdinalIgnoreCase) != -1);
}
