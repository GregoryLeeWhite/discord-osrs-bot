using System.Text;

namespace OSRS.Bot.MessageBuilders;

internal static class OsrsFailureMessageBuilder
{
    internal static string BuildOsrsApiErrorMessage(string statusCode)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine("```diff");
        stringBuilder.AppendLine($"- OSRS service returned {statusCode}");
        stringBuilder.AppendLine("```");

        return stringBuilder.ToString();
    }
}
