using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OSRS.Bot.Application.Interfaces.Services;
using OSRS.Bot.Application.Services;
using OSRS.Bot.Handlers;
using OSRS.Bot.Persistence.Http.Repositories;
using OSRS.Bot.Persistence.Interfaces;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(logging => logging.SetMinimumLevel(LogLevel.Debug))
    .ConfigureServices((_, services) =>
    {
        services.AddSingleton<DiscordSocketClient>();
        services.AddSingleton<CommandHandlingService>();
        services.AddSingleton<CommandService>();
        services.AddHttpClient<IHttpRepository, HttpRepository>();
        services.AddTransient<IRunescapeHttpRepository, RunescapeHttpRepository>();
        services.AddTransient<IHiScoreService, HiScoreService>();
    })
    .Build();

RunAsync(args).GetAwaiter().GetResult();

Task LogAsync(LogMessage log)
{
    Console.WriteLine(log.ToString());

    return Task.CompletedTask;
}

async Task RunAsync(string[] args)
{
    // Request the instance from the client.
    // Because we're requesting it here first, its targetted constructor will be called and we will receive an active instance.
    var client = host.Services.GetRequiredService<DiscordSocketClient>();

    client.Log += async (msg) =>
    {
        await Task.CompletedTask;
        Console.WriteLine(msg);
    };

    await client.LoginAsync(TokenType.Bot, config["DiscordBotToken"]);
    await client.StartAsync();

    await host.Services.GetRequiredService<CommandHandlingService>().InitializeAsync();

    await Task.Delay(Timeout.Infinite);
}