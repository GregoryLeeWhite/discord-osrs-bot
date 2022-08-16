# discord-osrs-bot
Discord bot for fetching Old School Runescape data based on a variety of commands using the [Discord.NET](https://discordnet.dev/) Library.

# Setup
1.  Clone repository.
2.  Create your Discord bot.  
    - Instructions for creating the bot can be referenced in the Discord.NET documentation.
        - [Creating a Discord Bot](https://discordnet.dev/guides/getting_started/first-bot.html#creating-a-discord-bot)
        - [Adding your bot to a server](https://discordnet.dev/guides/getting_started/first-bot.html#adding-your-bot-to-a-server)
3. Add your Discord Bot's token to the appsettings.json file.
    - In the [Discord Developer Portal](https://discord.com/developers/applications), navigate to your `application > settings > Bot` and copy the Token.
    ![DiscordToken](https://discordnet.dev/guides/getting_started/images/intro-token.png)
    - Paste your token in the appsettings.json file.
        ```json
        {
            "DiscordBotToken": "TOKEN_HERE"
        }
        ```

# Running the application
After finishing the setup section, there are a couple of options for running the application.
1.  Run the application in Visual Studio.
2.  Run the application using the .NET CLI
    - **NOTE**: *With this approach, your Discord Bot Token needs to be populated in the `/OSRS.Bot/appsettings.json` file*.
    - Open a terminal window.
    - `cd` to the `OSRS.Bot` directory.
    - Run the `dotnet build` command.
    - Run the `dotnet run` command.
3.  Run the application with the executable file.
    - Navigate to the [GitHub Releases Page](https://github.com/GregoryLeeWhite/discord-osrs-bot/releases).
    - Click on the most up to date version.
    - Download the `win-x64.zip` file under Assets.
    - Unzip the file.
    - Add your Discord Bot Token in the `appsettings.json` file.
    - Run the `OSRS.Bot.exe` file.

# Current List of Commands
- `!hiscores PlayerName`
    - This command will return all of a players levels, ranks, and XP for each level.
    ![image](https://user-images.githubusercontent.com/7416103/184512186-f77c76ab-b711-400b-982d-80a5b7904dc9.png)
- `!GIMHiscores GroupName`
    - Returns a group's rank, level, and contributed XP.  If a star emoji is shown, the group is Group Prestiged.




